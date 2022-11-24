using BallisticCalculator;
using BallisticCalculator.Reticle.Data;
using BallisticCalculatorNet.Api;
using Gehtsoft.Measurements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BallisticCalculatorNet.InputPanels
{
    public class TrajectoryToReticleCalculator
    {
        public enum PointLocation
        {
            Near,
            Far,
        }

        public class Point
        {
            public ReticleBulletDropCompensatorPoint BDCPoint { get; init; }
            public PointLocation PointLocation { get; init; }
            public Measurement<DistanceUnit> Distance { get; init; }
        }

        private readonly TrajectoryPoint[] mTrajectory;
        private readonly ReticleBulletDropCompensatorPointCollection mBulletDropCompensator;
        private readonly Measurement<DistanceUnit> mZeroDistance;

        public TrajectoryToReticleCalculator(TrajectoryPoint[] trajectory,
                                             ReticleBulletDropCompensatorPointCollection bulletDropCompensator,
                                             Measurement<DistanceUnit> zeroDistance)
        {
            mTrajectory = trajectory;
            mBulletDropCompensator = bulletDropCompensator;
            mZeroDistance = zeroDistance;
        }

        public TrajectoryToReticleCalculator(ShotData shotData,
                                             ReticleBulletDropCompensatorPointCollection bulletDropCompensator,
                                             Measurement<DistanceUnit> zeroDistance)
            : this(TrajectoryPointsCalculator.Calculate(shotData, (2.5).As(DistanceUnit.Meter), (1500.0).As(DistanceUnit.Meter)),
                   bulletDropCompensator, zeroDistance)
        {
        }

        private readonly List<Point> mPoints = new List<Point>();
        public IReadOnlyList<Point> Points => mPoints;

        /// <summary>
        /// Finds distances for BDC points for given trajectory and reticle scale 
        /// </summary>
        /// <param name="reticleScale">The scale of reticle. Always 1 for FFP scopes. The ratio of maximum zoom to current zoom for SFP scopes</param>
        public void UpdatePoints(double reticleScale = 1.0)
        {
            mPoints.Clear();

            for (int i = 2; i < mTrajectory.Length; i++)
            {
                var p1 = mTrajectory[i - 1];
                var p2 = mTrajectory[i];

                for (int j = 0; j < mBulletDropCompensator.Count; j++)
                {
                    var bdc = mBulletDropCompensator[j];
                    var drop = bdc.Position.Y * reticleScale;
                    if (drop >= p1.DropAdjustment && drop <= p2.DropAdjustment ||
                        drop <= p1.DropAdjustment && drop >= p2.DropAdjustment)
                    {
                        var dropDelta = (drop - p2.DropAdjustment).Abs();
                        var dropRange = (p1.DropAdjustment - p2.DropAdjustment).Abs();
                        var distanceRange = p2.Distance - p1.Distance;
                        var distance = p2.Distance - distanceRange * (dropDelta / dropRange);
                        var location = distance >= mZeroDistance ? PointLocation.Far : PointLocation.Near;
                        mPoints.Add(new Point()
                        {
                            BDCPoint = bdc,
                            PointLocation = location,
                            Distance = distance,
                        });
                    }
                }
            }
        }

        public TrajectoryPoint FindDistance(Measurement<DistanceUnit> distance)
        {
            if (mTrajectory == null || mTrajectory.Length == 0)
                return null;

            if (mTrajectory[0].Distance > distance)
                return null;
            if (mTrajectory[^1].Distance < distance)
                return null;
            if (mTrajectory[^2].Distance < distance)
                return mTrajectory[^1];


            int numpts = mTrajectory.Length - 1;

            int mlo = 0;
            int mhi = numpts - 1;
            int mid;

            while ((mhi - mlo) > 1)
            {
                mid = (int)Math.Floor((mhi + mlo) / 2.0);
                if (mTrajectory[mid].Distance < distance)
                    mlo = mid;
                else
                    mhi = mid;
            }

            int m;
            if ((mTrajectory[mhi].Distance - distance) > (distance - mTrajectory[mlo].Distance))
                m = mlo;
            else
                m = mhi;

            return mTrajectory[m];
        }
    }
}
