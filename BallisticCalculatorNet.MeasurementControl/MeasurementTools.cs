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
using BallisticCalculator;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.MeasurementControl
{
    public sealed class MeasurementTools
    {
        private static MeasurementTools gInst = null;

        public static MeasurementTools Instance
        {
            get => gInst ??= new MeasurementTools();
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
            return measurementType switch
            {
                MeasurementType.Angular => typeof(AngularUnit),
                MeasurementType.Distance => typeof(DistanceUnit),
                MeasurementType.Velocity => typeof(VelocityUnit),
                MeasurementType.Pressure => typeof(PressureUnit),
                MeasurementType.Temperature => typeof(TemperatureUnit),
                MeasurementType.Volume => typeof(VolumeUnit),
                MeasurementType.Weight => typeof(WeightUnit),
                MeasurementType.BallisticCoefficient => typeof(DragTableId),
                _ => throw new ArgumentException($"Value {measurementType} is unknown", nameof(measurementType)),
            };
        }

        private static MeasurementUtility CreateUtility(Type measurementUnit)
        {
            Type measurementType;

            if (measurementUnit == typeof(DragTableId))
                measurementType = typeof(BallisticCoefficient);
            else
                measurementType = typeof(Measurement<>).MakeGenericType(measurementUnit);

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

            if (unitType == typeof(DragTableId))
            {
                r.Add(new MeasurementUtility.Unit("G1", DragTableId.G1));
                r.Add(new MeasurementUtility.Unit("G2", DragTableId.G2));
                r.Add(new MeasurementUtility.Unit("G5", DragTableId.G5));
                r.Add(new MeasurementUtility.Unit("G6", DragTableId.G6));
                r.Add(new MeasurementUtility.Unit("G7", DragTableId.G7));
                r.Add(new MeasurementUtility.Unit("G8", DragTableId.G8));
                r.Add(new MeasurementUtility.Unit("GI", DragTableId.GI));
                r.Add(new MeasurementUtility.Unit("GS", DragTableId.GS));
                r.Add(new MeasurementUtility.Unit("GC", DragTableId.GC));
            }
            else
            {
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
            }
            return r;
        }

        private static Func<double, object, object> CreateActivator(Type measurementUnit)
        {
            if (measurementUnit == typeof(DragTableId))
            {
                return (bc, t) => new BallisticCoefficient(bc, (DragTableId)t);
            }
            else
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
        }

        private static Func<object, double> CreateValueGetter(Type measurementType)
        {
            if (measurementType == typeof(BallisticCoefficient))
            {
                return v => ((BallisticCoefficient)v).Value;
            }
            else
            {
                var field = measurementType.GetField(nameof(Measurement<DistanceUnit>.Value));
                var paramValue = Expression.Parameter(typeof(object));
                var labelReturn = Expression.Label(typeof(double));
                var returnStmt = Expression.Return(labelReturn, Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field));
                var body = Expression.Block(typeof(double), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(0.0)) });
                var lambda = Expression.Lambda<Func<object, double>>(body, new ParameterExpression[] { paramValue });
                return lambda.Compile();
            }
        }

        private static Func<object, object> CreateUnitGetter(Type measurementType)
        {
            if (measurementType == typeof(BallisticCoefficient))
            {
                return v => ((BallisticCoefficient)v).Table;
            }
            else
            {
                var field = measurementType.GetField(nameof(Measurement<DistanceUnit>.Unit));
                var paramValue = Expression.Parameter(typeof(object));
                var labelReturn = Expression.Label(typeof(object));
                var returnStmt = Expression.Return(labelReturn, Expression.Convert(Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field), typeof(object)));
                var body = Expression.Block(typeof(object), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(null)) });
                var lambda = Expression.Lambda<Func<object, object>>(body, new ParameterExpression[] { paramValue });
                return lambda.Compile();
            }
        }

        private static Func<object, string> CreateTextGetter(Type measurementType)
        {
            if (measurementType == typeof(BallisticCoefficient))
            {
                return v => ((BallisticCoefficient)v).Text;
            }
            else
            {
                var field = measurementType.GetProperty(nameof(Measurement<DistanceUnit>.Text));
                var paramValue = Expression.Parameter(typeof(object));
                var labelReturn = Expression.Label(typeof(string));
                var returnStmt = Expression.Return(labelReturn, Expression.MakeMemberAccess(Expression.Convert(paramValue, measurementType), field));
                var body = Expression.Block(typeof(string), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant("")) });
                var lambda = Expression.Lambda<Func<object, string>>(body, new ParameterExpression[] { paramValue });
                return lambda.Compile();
            }
        }

        private static Func<string, object> CreateParser(Type measurementType)
        {
            if (measurementType == typeof(BallisticCoefficient))
            {
                return s =>
                {
                    if (BallisticCoefficient.TryParse(s, out BallisticCoefficient v))
                        return v;
                    throw new ArgumentException("The text to parse is in invalid format");
                };
            }
            else
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
                var returnStmt = Expression.Return(labelReturn, Expression.Convert(Expression.New(constructor, new Expression[] { paramValue }), typeof(object)));
                var body = Expression.Block(typeof(object), new Expression[] { returnStmt, Expression.Label(labelReturn, Expression.Constant(null)) });
                var lambda = Expression.Lambda<Func<string, object>>(body, new ParameterExpression[] { paramValue });
                return lambda.Compile();
            }
        }
    }
}
