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
using Gehtsoft.Winforms.FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.ReticleEditor
{
    public class AppForm_LoadAndSaveReticle
    {
        [Fact]
        public void NewReticle()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm appForm = new BallisticCalculatorNet.ReticleEditor.AppForm();

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
            BallisticCalculatorNet.ReticleEditor.AppForm appForm = new BallisticCalculatorNet.ReticleEditor.AppForm();

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

            var lb = appForm.ListBox("reticleItems");
            lb.Should().Exist();
            lb.Should().HaveItemsCount(r1.Elements.Count + r1.BulletDropCompensator.Count);
            lb.Should().HaveIndexSelected(-1);

            //wrong reticle, take it from control!!!
            foreach (var element in appForm.Reticle.Elements)
                lb.Should().HaveItemMatching<object>(lbi => ReferenceEquals(lbi, element));

            foreach (var element in appForm.Reticle.BulletDropCompensator)
                lb.Should().HaveItemMatching<object>(lbi => ReferenceEquals(lbi, element));
        }

        [Fact]
        public void GatherReticle()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm f = new BallisticCalculatorNet.ReticleEditor.AppForm();
            f.TextBox("reticleName").Text = "NewName";
            f.MeasurementControl("reticleWidth").Value = AngularUnit.Mil.New(1);
            f.MeasurementControl("reticleHeight").Value = AngularUnit.Mil.New(2);
            f.MeasurementControl("zeroOffsetX").Value = AngularUnit.Mil.New(3);
            f.MeasurementControl("zeroOffsetY").Value = AngularUnit.Mil.New(4);

            f.GatherReticleDefinition();

            f.Reticle.Name.Should().Be("NewName");
            f.Reticle.Size.X.Should().Be(AngularUnit.Mil.New(1));
            f.Reticle.Size.Y.Should().Be(AngularUnit.Mil.New(2));
            f.Reticle.Zero.X.Should().Be(AngularUnit.Mil.New(3));
            f.Reticle.Zero.Y.Should().Be(AngularUnit.Mil.New(4));
        }
    }
}
