using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BallisticCalculatorNet.MeasurementControl;
using FluentAssertions;
using Gehtsoft.Measurements;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.MsrmentControl
{
    public class UtilTest
    {
        [Fact]
        public void MeasurementUtil_Created()
        {
            var util = MeasurementTools.Instance.GetUtility(MeasurementType.Angular);
            util.Should().NotBeNull();
            util.MeasurementUnit.Should().Be(typeof(AngularUnit));
            util.MeasurementType.Should().Be(typeof(Measurement<AngularUnit>));
        }

        [Fact]
        public void MeasurementUtil_IsCached()
        {
            var util1 = MeasurementTools.Instance.GetUtility(MeasurementType.Angular);
            var util2 = MeasurementTools.Instance.GetUtility(MeasurementType.Angular);
            util1.Should().BeSameAs(util2);
        }

        [Theory]
        [InlineData(MeasurementType.Angular, typeof(AngularUnit), typeof(Measurement<AngularUnit>))]
        [InlineData(MeasurementType.Distance, typeof(DistanceUnit), typeof(Measurement<DistanceUnit>))]
        [InlineData(MeasurementType.Weight, typeof(WeightUnit), typeof(Measurement<WeightUnit>))]
        [InlineData(MeasurementType.Pressure, typeof(PressureUnit), typeof(Measurement<PressureUnit>))]
        public void MeasurementUtil_Types(MeasurementType type, Type unit, Type value)
        {
            var util = MeasurementTools.Instance.GetUtility(type);
            util.MeasurementUnit.Should().Be(unit);
            util.MeasurementType.Should().Be(value);
        }

        [Theory]
        [InlineData(MeasurementType.Distance, "in", DistanceUnit.Inch)]
        [InlineData(MeasurementType.Distance, "mm", DistanceUnit.Millimeter)]
        [InlineData(MeasurementType.Distance, "cm", DistanceUnit.Centimeter)]
        [InlineData(MeasurementType.Weight, "g", WeightUnit.Gram)]
        [InlineData(MeasurementType.Pressure, "inHg", PressureUnit.InchesOfMercury)]
        public void MeasurementUtil_UnitList(MeasurementType type, string name, object unit)
        {
            var util = MeasurementTools.Instance.GetUtility(type);
            util.Units.Should().Contain(new MeasurementUtility.Unit(name, unit));
        }

        [Theory]
        [InlineData(MeasurementType.Distance, typeof(DistanceUnit))]
        [InlineData(MeasurementType.Angular, typeof(AngularUnit))]
        [InlineData(MeasurementType.Pressure, typeof(PressureUnit))]
        [InlineData(MeasurementType.Velocity, typeof(VelocityUnit))]
        [InlineData(MeasurementType.Weight, typeof(WeightUnit))]
        public void MeasurementUtil_UnitList_Completeness(MeasurementType type, Type unitType)
        {
            var util = MeasurementTools.Instance.GetUtility(type);

            var values = Enum.GetValues(unitType);
            util.Units.Should().HaveCount(values.Length);

            foreach (var value in values)
            {
                var mi = unitType.GetMember(value.ToString()).FirstOrDefault();
                mi.Should().NotBeNull();
                var attr = mi.GetCustomAttribute<UnitAttribute>();
                attr.Should().NotBeNull();

                string n = attr.Name;

                util.Units.Should().Contain(u => u.Value.Equals(value) && u.Name == n);
            }
        }

        private void MeasurementUtil_TestCreator_Validate<T>(object obj, double expectedValue, T expectedUnit)
             where T : Enum
        {
            obj.Should().BeOfType(typeof(Measurement<T>));

            Measurement<T> _obj = (Measurement<T>)obj;

            _obj.Value.Should().BeApproximately(expectedValue, 1e-7);
            _obj.Unit.Should().Be(expectedUnit);
        }

        [Theory]
        [InlineData(MeasurementType.Angular, typeof(AngularUnit), 5, AngularUnit.Degree, "5°")]
        [InlineData(MeasurementType.Distance, typeof(DistanceUnit), 1.2345, DistanceUnit.Centimeter, "1.2345cm")]
        public void MeasurementUtil_TestMethods(MeasurementType type, Type valueType, double value, object unit, string text)
        {
            unit.Should().BeOfType(valueType);
            var util = MeasurementTools.Instance.GetUtility(type);
            object obj = util.Activator(value, unit);
            obj.Should().NotBeNull();
            var mi = this.GetType().GetMethod(nameof(MeasurementUtil_TestCreator_Validate), BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(new Type[] { valueType });
            mi.Invoke(this, new object[] { obj, value, unit });

            util.ValueGetter(obj).Should().Be(value);
            util.UnitGetter(obj).Should().BeOfType(valueType);
            util.UnitGetter(obj).Should().Be(unit);
            util.TextGetter(obj).Should().Be(text);
        }
    }
}