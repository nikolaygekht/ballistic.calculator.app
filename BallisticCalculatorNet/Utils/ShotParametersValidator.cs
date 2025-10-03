using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Types;
using BallisticCalculatorNet.InputPanels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.Utils
{
    public class ShotParametersValidator
    {
        public List<string> Errors { get; } = new List<string>();

        public ShotParametersValidator()
        {
        }

        public bool Validate(ShotData shotParameters)
        {
            if (shotParameters == null)
            {
                Errors.Add("The shot parameters aren't defined");
                return false;
            }

            if (shotParameters.Ammunition == null ||
                shotParameters.Ammunition.Ammunition.BallisticCoefficient.Value <= 0 ||
                shotParameters.Ammunition.Ammunition.Weight.Value <= 0 ||
                shotParameters.Ammunition.Ammunition.MuzzleVelocity.Value <= 0)
                Errors.Add("The ammunition isn't defined (ballistic coefficient, weight or velocity)");

            if (shotParameters.Ammunition.Ammunition.BallisticCoefficient.Table == BallisticCalculator.DragTableId.GC &&
                (string.IsNullOrEmpty(shotParameters.Ammunition.Ammunition.CustomTableFileName) || !File.Exists(shotParameters.Ammunition.Ammunition.CustomTableFileName)))
                Errors.Add("The custom drag function isn't set or doesn't exist");

            if (shotParameters.Weapon == null ||
                shotParameters.Weapon.Zero.Distance.Value <= 0 ||
                shotParameters.Weapon.Sight.SightHeight.Value <= 0)
                Errors.Add("The weapon isn't defined (zero distance or sight height)");

            return Errors.Count == 0;
        }
    }
}
