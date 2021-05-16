using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.MeasurementControl
{
    public sealed class MeasurementTools
    {
        private static MeasurementTools gInst = null;

        public static MeasurementTools Instance
        {
            get => gInst ?? (gInst = new MeasurementTools());
        }

        private MeasurementTools()
        {
        }

        private readonly ConcurrentDictionary<MeasurementType, MeasurementUtility> mUtilitiesDictionary = new ConcurrentDictionary<MeasurementType, MeasurementUtility>();

        public MeasurementUtility GetUtility(MeasurementType unitType)
        {
            return mUtilitiesDictionary.GetOrAdd(unitType, type => CreateUtility(GetMeasurementEnumType(type)));
        }

        private static Type GetMeasurementEnumType(MeasurementType measurementType)
        {
            switch (measurementType)
            {
                case MeasurementType.Angular:
                    return typeof(AngularUnit);
                case MeasurementType.Distance:
                    return typeof(DistanceUnit);
                case MeasurementType.Velocity:
                    return typeof(VelocityUnit);
                case MeasurementType.Pressure:
                    return typeof(PressureUnit);
                case MeasurementType.Temperature:
                    return typeof(TemperatureUnit);
                case MeasurementType.Volume:
                    return typeof(VolumeUnit);
                case MeasurementType.Weight:
                    return typeof(WeightUnit);
                default:
                    throw new ArgumentException($"Value {measurementType} is unknown", nameof(measurementType));
            }
        }

        private MeasurementUtility CreateUtility(Type measurementUnit)
        {
            Type measurementType = typeof(Measurement<>).MakeGenericType(measurementUnit);

            return new MeasurementUtility(
                measurementUnit, measurementType,
                GetUnits(measurementType, measurementUnit),
                CreateActivator(measurementUnit),
                CreateValueGetter(measurementType),
                CreateUnitGetter(measurementType),
                CreateTextGetter(measurementType),
                CreateParser(measurementType));
        }

        private static IReadOnlyList<MeasurementUtility.Unit> GetUnits(Type measurementType, Type unitType)
        {
            var r = new List<MeasurementUtility.Unit>();
            var mi = measurementType.GetMethod(nameof(Measurement<AngularUnit>.GetUnitNames), BindingFlags.Public | BindingFlags.Static);
            var tupleType = typeof(Tuple<,>).MakeGenericType(new Type[] { unitType, typeof(string) });
            var unitField = tupleType.GetProperty("Item1");
            var nameField = tupleType.GetProperty("Item2");
            foreach (object tuple in mi.Invoke(null, Array.Empty<object>()) as IEnumerable)
            {
                r.Add(new MeasurementUtility.Unit(
                        nameField.GetValue(tuple) as string,
                        unitField.GetValue(tuple)
                    ));
            }
            return r;
        }

        private static Func<double, object, object> CreateActivator(Type measurementUnit)
        {
            var genericMethod = typeof(UnitExtensions).GetMethod(nameof(UnitExtensions.New), BindingFlags.Public | BindingFlags.Static);
            var method = genericMethod.MakeGenericMethod(new Type[] { measurementUnit });

            var paramValue = Expression.Parameter(typeof(double));
            var paramUnit = Expression.Parameter(typeof(object));

            var labelReturn = Expression.Label(typeof(object));
            var returnStmt = Expression.Return(labelReturn, Expression.Convert(Expression.Call(null, method, new Expression[] { Expression.Convert(paramUnit, measurementUnit), paramValue }), typeof(object)));

            var body = Expression.Block(typeof(object), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(null)) });

            var lambda = Expression.Lambda<Func<double, object, object>>(body, new ParameterExpression[] { paramValue, paramUnit });
            return lambda.Compile();
        }

        private static Func<object, double> CreateValueGetter(Type measurementType)
        {
            var field = measurementType.GetField(nameof(Measurement<DistanceUnit>.Value));
            var paramValue = Expression.Parameter(typeof(object));
            var labelReturn = Expression.Label(typeof(double));
            var returnStmt = Expression.Return(labelReturn, Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field));
            var body = Expression.Block(typeof(double), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(0.0)) });
            var lambda = Expression.Lambda<Func<object, double>>(body, new ParameterExpression[] { paramValue });
            return lambda.Compile();
        }

        private static Func<object, object> CreateUnitGetter(Type measurementType)
        {
            var field = measurementType.GetField(nameof(Measurement<DistanceUnit>.Unit));
            var paramValue = Expression.Parameter(typeof(object));
            var labelReturn = Expression.Label(typeof(object));
            var returnStmt = Expression.Return(labelReturn, Expression.Convert(Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field), typeof(object)));
            var body = Expression.Block(typeof(object), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(null)) });
            var lambda = Expression.Lambda<Func<object, object>>(body, new ParameterExpression[] { paramValue });
            return lambda.Compile();
        }

        private static Func<object, string> CreateTextGetter(Type measurementType)
        {
            var field = measurementType.GetProperty(nameof(Measurement<DistanceUnit>.Text));
            var paramValue = Expression.Parameter(typeof(object));
            var labelReturn = Expression.Label(typeof(string));
            var returnStmt = Expression.Return(labelReturn, Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field));
            var body = Expression.Block(typeof(string), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant("")) });
            var lambda = Expression.Lambda<Func<object, string>>(body, new ParameterExpression[] { paramValue });
            return lambda.Compile();
        }

        private static Func<string, object> CreateParser(Type measurementType)
        {
            var constructors = measurementType.GetConstructors();
            ConstructorInfo constructor = null;
            foreach (var candidate in constructors)
            {
                var candidateParams = candidate.GetParameters();
                if (candidate.GetCustomAttribute<JsonConstructorAttribute>() != null &&
                    candidateParams.Length == 1 &&
                    candidateParams[0].ParameterType == typeof(string))
                {
                    constructor = candidate;
                    break;
                }
            }

            if (constructor == null)
                throw new ArgumentException($"Type {measurementType.FullName} does not have a json constructor with one text field", nameof(measurementType));

            var paramValue = Expression.Parameter(typeof(string));
            var labelReturn = Expression.Label(typeof(object));
            var returnStmt = Expression.Return(labelReturn, Expression.Convert(Expression.New(constructor, new Expression[] {  paramValue } ), typeof(object)));
            var body = Expression.Block(typeof(object), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(null)) });
            var lambda = Expression.Lambda<Func<string, object>>(body, new ParameterExpression[] { paramValue });
            return lambda.Compile();
        }
    }
}
