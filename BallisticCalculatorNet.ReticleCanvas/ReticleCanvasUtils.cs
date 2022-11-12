using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.ReticleCanvas
{
    public static class ReticleCanvasUtils
    {
        public static void CalculateReticleImageSize(int placeHolderWidth, int placeHolderHeight, Measurement<AngularUnit> reticleWidth, Measurement<AngularUnit> reticleHeight, out int imageWidth, out int imageHeight)
        {
            double reticleProprotion = reticleWidth / reticleHeight;

            if (placeHolderHeight * reticleProprotion > placeHolderWidth)
            {
                imageWidth = placeHolderWidth;
                imageHeight = (int)(placeHolderWidth / reticleProprotion);
            }
            else
            {
                imageHeight = placeHolderHeight;
                imageWidth = (int)(placeHolderHeight * reticleProprotion);
            }
        }
    }
}
