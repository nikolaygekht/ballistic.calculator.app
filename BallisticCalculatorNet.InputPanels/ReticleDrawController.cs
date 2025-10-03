using System.Windows.Forms;
using BallisticCalculator.Reticle.Data;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.ReticleCanvas;
using Gehtsoft.Measurements;

namespace BallisticCalculatorNet.InputPanels
{
    public static class ReticleControlHelper
    {
        public static void GetReticleCanvasSize(ReticleDefinition reticle, PictureBox pictureBox, out int width, out int height)
        {
            ReticleCanvasUtils.CalculateReticleImageSize(pictureBox.Size.Width, pictureBox.Size.Height,
                                      reticle.Size.X, reticle.Size.Y, out width, out height);
        }

        public static double GetReticleScaleFactor(NumericUpDown currentZoom, NumericUpDown maxZoom)
        {
            if (maxZoom.Value < 1 || currentZoom.Value < 1)
                return 1;

            return (double)(maxZoom.Value / currentZoom.Value);
        }

        public static ReticleElementsCollection CreateBdc(TrajectoryToReticleCalculator calculator, MeasurementSystem measurementSystem, RadioButton noneControl, RadioButton farControl, double zoom)
        {
            var elements = new ReticleElementsCollection();

            if (noneControl.Checked || calculator == null)
                return elements;

            bool far = farControl.Checked;
            var distanceUnits = measurementSystem == MeasurementSystem.Imperial ? DistanceUnit.Yard : DistanceUnit.Meter;

            calculator.UpdatePoints(zoom);
            for (int i = 0; i < calculator.Points.Count; i++)
            {
                var point = calculator.Points[i];
                if ((point.PointLocation == TrajectoryToReticleCalculator.PointLocation.Far) != far)
                    continue;

                var value = point.Distance.In(distanceUnits);
                var text = value.ToString("N0");
                var element = new ReticleText()
                {
                    Text = text,
                    Position = new ReticlePosition(point.BDCPoint.Position.X + point.BDCPoint.TextOffset, point.BDCPoint.Position.Y - point.BDCPoint.TextHeight / 2),
                    TextHeight = point.BDCPoint.TextHeight,
                    Color = "blue",
                };
                elements.Add(element);
            }
            return elements;
        }

        public static ReticleElement CreateTarget(TrajectoryToReticleCalculator calculator, CheckBox showTargetControl, NumericUpDown widthControl, NumericUpDown heightControl, ComboBox unitsControl, BallisticCalculatorNet.MeasurementControl.MeasurementControl distanceControl, double zoom)
        {
            if (!showTargetControl.Checked || calculator == null)
                return null;

            var targetSizeUnits = unitsControl.SelectedIndex == 0 ? DistanceUnit.Inch : DistanceUnit.Centimeter;
            var width = ((double)widthControl.Value).As(targetSizeUnits);
            var height = ((double)heightControl.Value).As(targetSizeUnits);

            if (width.Value < 0.01 || height.Value < 0.01)
                return null;

            var distance = distanceControl.ValueAsMeasurement<DistanceUnit>();
            var item = calculator.FindDistance(distance);
            if (item == null)
                return null;

            var angularHeight = CalculateSize(height, distance, zoom);
            var angularWidth = CalculateSize(width, distance, zoom);

            return new ReticleRectangle()
            {
                TopLeft = new ReticlePosition(-item.WindageAdjustment / zoom - angularWidth / 2, item.DropAdjustment / zoom + angularHeight / 2),
                Size = new ReticlePosition(angularWidth, angularHeight),
                Color = "red",
            };
        }

        /// <summary>
        /// Finds angular size of the object at the give distance for given reticle scale
        /// </summary>
        /// <param name="reticleScale">The scale of reticle. Always 1 for FFP scopes. The ratio of maximum zoom to current zoom for SFP scopes</param>
        public static Measurement<AngularUnit> CalculateSize(Measurement<DistanceUnit> targetSize, Measurement<DistanceUnit> targetDistance, double reticleScale = 1.0)
        {
            return (targetSize.In(DistanceUnit.Centimeter) / (targetDistance.In(DistanceUnit.Meter) / 100)).As(AngularUnit.CmPer100Meters) / reticleScale;
        }
    }
}
