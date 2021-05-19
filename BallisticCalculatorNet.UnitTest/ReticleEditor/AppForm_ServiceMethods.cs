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
    }
}
