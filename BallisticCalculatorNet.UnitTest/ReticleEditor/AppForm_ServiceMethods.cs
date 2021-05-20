using BallisticCalculator.Reticle;
using BallisticCalculatorNet.ReticleEditor;
using BallisticCalculatorNet.UnitTest.Utils;
using FluentAssertions;
using Gehtsoft.Measurements;
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
            AppForm.CalculateReticleImageSize(controlWidth, controlHeight,
                AngularUnit.Mil.New(reticleWidth),
                AngularUnit.Mil.New(reticleHeight),
                out int calculatedImageWidth, out int calculateImageHeight);

            calculatedImageWidth.Should().Be(imageWidth, $"expected in {situation}");
            calculateImageHeight.Should().Be(imageHeight, $"expected in {situation}");
        }

        [Fact]
        public void Delete_ReticleElement()
        {
            AppForm form = new AppForm();
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
        public void Delete_ReticleBdc()
        {
            AppForm form = new AppForm();
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
    }
}
