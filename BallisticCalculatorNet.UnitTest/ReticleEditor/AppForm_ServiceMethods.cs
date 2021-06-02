using System;
using BallisticCalculator.Reticle;
using BallisticCalculator.Reticle.Data;
using BallisticCalculatorNet.ReticleEditor;
using BallisticCalculatorNet.ReticleEditor.Forms;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;
using Xunit;

namespace BallisticCalculatorNet.UnitTest.ReticleEditor
{
    public class AppForm_ServiceMethods
    {
        [Theory]
        [InlineData(100, 100, 8, 8, 100, 100, "square holder, square reticle")]
        [InlineData(100, 50, 8, 8, 50, 50, "holder width > height, square reticle")]
        [InlineData(50, 100, 8, 8, 50, 50, "holder width < height, square reticle")]
        [InlineData(100, 100, 6, 8, 75, 100, "square holder, vertical reticle")]
        [InlineData(60, 100, 6, 8, 60, 80, "vertical holder, vertical reticle")]
        [InlineData(100, 60, 6, 8, 45, 60, "horizontal holder, vertical reticle")]
        public void CalculateReticleImageSize(int controlWidth, int controlHeight, double reticleWidth, double reticleHeight, int imageWidth, int imageHeight, string situation)
        {
            BallisticCalculatorNet.ReticleEditor.AppForm.CalculateReticleImageSize(controlWidth, controlHeight,
                AngularUnit.Mil.New(reticleWidth),
                AngularUnit.Mil.New(reticleHeight),
                out int calculatedImageWidth, out int calculateImageHeight);

            calculatedImageWidth.Should().Be(imageWidth, $"expected in {situation}");
            calculateImageHeight.Should().Be(imageHeight, $"expected in {situation}");
        }

        [Fact]
        public void Delete_ReticleElement()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");

            var originalListBoxItemsCount = form.ListBox("reticleItems").Items.Count;

            var elementToDelete = form.Reticle.Elements[1];
            var originalElementsCount = form.Reticle.Elements.Count;

            form.Reticle.Elements.Should().Contain(elementToDelete);

            form.DeleteItem(elementToDelete);

            form.ListBox("reticleItems").Should()
                .HaveItemsCount(originalListBoxItemsCount - 1)
                .And
                .HaveNotItemsMatching<object>(i => ReferenceEquals(i, elementToDelete));

            form.Reticle.Elements.Should().HaveCount(originalElementsCount - 1);
            form.Reticle.Elements.Should().NotContain(elementToDelete);
        }

        [Fact]
        public void Duplicate_ReticleElement()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");
            var lb = form.ListBox("reticleItems");
            var originalListBoxItemsCount = lb.Items.Count;

            var elementToDuplicate = form.Reticle.Elements[1];
            var originalElementsCount = form.Reticle.Elements.Count;

            form.Reticle.Elements.Should().Contain(elementToDuplicate);

            form.DuplicateItem(elementToDuplicate);

            lb.Should()
                .HaveItemsCount(originalListBoxItemsCount + 1)
                .And.HaveItemMatching<object>(i => ReferenceEquals(i, elementToDuplicate))
                .And.HaveItemMatching<object>(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));

            form.Reticle.Elements.Should()
                .HaveCount(originalElementsCount + 1)
                .And.Contain(i => ReferenceEquals(i, elementToDuplicate))
                .And.Contain(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));

            lb.Items[^1].Should().Match(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));
        }

        [Fact]
        public void Delete_ReticleBdc()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");

            var originalListBoxItemsCount = form.ListBox("reticleItems").Items.Count;

            var bdcToDelete = form.Reticle.BulletDropCompensator[1];
            var originalBdcCount = form.Reticle.BulletDropCompensator.Count;

            form.Reticle.BulletDropCompensator.Should().Contain(bdcToDelete);

            form.DeleteItem(bdcToDelete);

            form.ListBox("reticleItems").Should()
                .HaveItemsCount(originalListBoxItemsCount - 1)
                .And
                .HaveNotItemsMatching<object>(i => ReferenceEquals(i, bdcToDelete));

            form.Reticle.BulletDropCompensator.Should().HaveCount(originalBdcCount - 1);
            form.Reticle.BulletDropCompensator.Should().NotContain(bdcToDelete);
        }

        [Fact]
        public void Duplicate_ReticleBdc()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");
            var lb = form.ListBox("reticleItems");
            var originalListBoxItemsCount = lb.Items.Count;

            var elementToDuplicate = form.Reticle.BulletDropCompensator[1];
            var originalElementsCount = form.Reticle.BulletDropCompensator.Count;

            form.DuplicateItem(elementToDuplicate);

            lb.Should()
                .HaveItemsCount(originalListBoxItemsCount + 1)
                .And
                .HaveItemMatching<object>(i => ReferenceEquals(i, elementToDuplicate))
                .And
                .HaveItemMatching<object>(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));

            form.Reticle.BulletDropCompensator.Should().HaveCount(originalElementsCount + 1);
            form.Reticle.BulletDropCompensator.Should().Contain(elementToDuplicate);
            form.Reticle.BulletDropCompensator.Should().Contain(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));

            lb.Items[^1].Should().Match(i => i.Equals(elementToDuplicate) && !ReferenceEquals(i, elementToDuplicate));
        }

        [Fact]
        public void Duplicate_ThenDeleteOriginal()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");
            var lb = form.ListBox("reticleItems");
            var org = lb.Items[0];
            form.DuplicateItem(org);
            lb.Items[^1].Should().Match(i => i.Equals(org) && !ReferenceEquals(i, org));
            form.DeleteItem(org);
            lb.Items[0].Should().Match(i => !i.Equals(org) && !ReferenceEquals(i, org));
            lb.Items[^1].Should().Match(i => i.Equals(org) && !ReferenceEquals(i, org));
        }

        [Fact]
        public void Duplicate_ThenDeleteCopy()
        {
            BallisticCalculatorNet.ReticleEditor.AppForm form = new BallisticCalculatorNet.ReticleEditor.AppForm();
            form.LoadReticle(new MilDotReticle(), "mildot");
            var lb = form.ListBox("reticleItems");
            var org = lb.Items[0];
            form.DuplicateItem(org);
            lb.Items[^1].Should().Match(i => i.Equals(org) && !ReferenceEquals(i, org));
            form.DeleteItem(lb.Items[^1]);
            lb.Items[0].Should().Match(i => i.Equals(org) && ReferenceEquals(i, org));
            lb.Items[^1].Should().Match(i => !i.Equals(org));
        }

        [Theory]
        [InlineData(typeof(ReticleCircle), typeof(EditCircleForm))]
        [InlineData(typeof(ReticleLine), typeof(EditLineForm))]
        [InlineData(typeof(ReticleRectangle), typeof(EditRectangleForm))]
        [InlineData(typeof(ReticleText), typeof(EditTextForm))]
        [InlineData(typeof(ReticlePath), typeof(EditPathForm))]
        [InlineData(typeof(ReticleBulletDropCompensatorPoint), typeof(EditBdcForm))]
        public void CorrectFormCreation(Type element, Type form)
        {
            BallisticCalculatorNet.ReticleEditor.AppForm f = new BallisticCalculatorNet.ReticleEditor.AppForm();
            f.FormForObject(Activator.CreateInstance(element)).Should().BeOfType(form);
        }
    }
}
