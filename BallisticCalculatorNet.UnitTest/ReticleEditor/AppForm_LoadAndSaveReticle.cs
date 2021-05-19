using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallisticCalculator.Reticle;
using BallisticCalculatorNet.ReticleEditor;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.ReticleEditor
{
    public class AppForm_LoadAndSaveReticle
    {
        [Fact]
        public void NewReticle()
        {
            AppForm appForm = new AppForm();

            //make sure reticle is loaded
            appForm.TextBox("reticleName").Should().HaveNoText();
            appForm.MeasurementControl("reticleWidth").Should().HaveExactValue(AngularUnit.Mil.New(10));
            appForm.MeasurementControl("reticleHeight").Should().HaveExactValue(AngularUnit.Mil.New(10));
            appForm.MeasurementControl("zeroOffsetX").Should().HaveExactValue(AngularUnit.Mil.New(5));
            appForm.MeasurementControl("zeroOffsetY").Should().HaveExactValue(AngularUnit.Mil.New(5));

            appForm.ListBox("reticleItems").Should().HaveNoItems();
        }

        [Fact]
        public void LoadReticle()
        {
            AppForm appForm = new AppForm();

            MilDotReticle r1 = new MilDotReticle();
            using (var ms1 = new MemoryStream())
            {
                r1.BallisticXmlSerialize(ms1);
                using var ms2 = new MemoryStream(ms1.ToArray());
                appForm.LoadReticle(ms2, "reticle1");
            }

            //make sure reticle is loaded
            appForm.ReticleFileName.Should().Be("reticle1");
            appForm.Reticle.Name.Should().Be(r1.Name);

            appForm.TextBox("reticleName").Should().HaveText(r1.Name);
            appForm.MeasurementControl("reticleWidth").Should().HaveExactValue(r1.Size.X);
            appForm.MeasurementControl("reticleHeight").Should().HaveExactValue(r1.Size.Y);
            appForm.MeasurementControl("zeroOffsetX").Should().HaveExactValue(r1.Zero.X);
            appForm.MeasurementControl("zeroOffsetY").Should().HaveExactValue(r1.Zero.Y);

            appForm.ListBox("reticleItems").Should().HaveItemsCount(r1.Elements.Count);
            appForm.ListBox("reticleItems").Should().HaveIndexSelected(-1);
        }
    }
}
