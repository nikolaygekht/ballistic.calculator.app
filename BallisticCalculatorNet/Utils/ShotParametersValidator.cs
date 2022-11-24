using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.InputPanels;
using System;
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
                Errors.Add("The ammunition isn't defined");

            if (shotParameters.Weapon == null ||
                shotParameters.Weapon.Zero.Distance.Value <= 0 ||
                shotParameters.Weapon.Sight.SightHeight.Value <= 0)
                Errors.Add("The weapon isn't defined");

            return Errors.Count == 0;
        }
    }
}
