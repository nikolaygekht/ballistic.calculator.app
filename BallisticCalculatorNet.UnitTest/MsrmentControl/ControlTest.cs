using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.MsrmentControl
{
    public class ControlTest
    {
        [Fact]
        public void InitialStatus()
        {
            TestForm tf = new TestForm();
            var control = tf.AddControl<MeasurementControl.MeasurementControl>(1, 1, 200, 24);
            
            control.UnitPartControl.Should().NotBeNull();
            control.UnitPartControl.Should().BeOfType(typeof(ComboBox));

            control.NumericPartControl.Should().NotBeNull();
            control.NumericPartControl.Should().BeOfType(typeof(TextBox));
        }
    }
}
