using BallisticCalculator;
using BallisticCalculatorNet.Api;
using Gehtsoft.Measurements;
using System.IO;
using System.Linq;

namespace BallisticCalculatorNet.InputPanels
{
    public static class TrajectoryPointsCalculator
    {
        public static TrajectoryPoint[] Calculate(ShotData shotData, Measurement<DistanceUnit>? overrideStep = null, Measurement<DistanceUnit>? overrideMaximumDistance = null)
        {
            var calc = new TrajectoryCalculator();

            var calculationParameters = new ShotParameters()
            {
                BarrelAzymuth = shotData.Parameters.BarrelAzymuth,
                CantAngle = shotData.Parameters.CantAngle,
                MaximumDistance = overrideMaximumDistance ?? shotData.Parameters.MaximumDistance,
                ShotAngle = shotData.Parameters.ShotAngle,
                Step = overrideStep ?? shotData.Parameters.Step,
            };

            var zeroAmmo = shotData.Weapon.Zero.Ammunition ?? shotData.Ammunition.Ammunition;

            calculationParameters.SightAngle = calc.SightAngle(zeroAmmo,
                                        shotData.Weapon,
                                        (shotData.Weapon.Zero.Atmosphere ?? shotData.Atmosphere) ?? new Atmosphere(),
                                        GetDragTable(zeroAmmo));

            var trajectory = calc.Calculate(shotData.Ammunition.Ammunition, shotData.Weapon,
                shotData.Atmosphere ?? new Atmosphere(), calculationParameters, shotData.Wind?.ToArray(),
                GetDragTable(shotData.Ammunition.Ammunition));

            return trajectory;
        }

        private static DragTable GetDragTable(Ammunition ammo)
        {
            if (ammo == null || ammo.BallisticCoefficient.Table != DragTableId.GC ||
                string.IsNullOrEmpty(ammo.CustomTableFileName) || !File.Exists(ammo.CustomTableFileName))
                return null;
            return DrgDragTable.Open(ammo.CustomTableFileName);
        }
    }
}
