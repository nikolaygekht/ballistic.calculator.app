using BallisticCalculator;
using Gehtsoft.Measurements;
using System.Collections;
using System.Collections.Generic;

namespace BallisticCalculatorNet.InputPanels
{
    public class WindCollection : IReadOnlyList<Wind>
    {
        private readonly List<Wind> mList = new List<Wind>();

        public Wind this[int index] => mList[index];

        public int Count => mList.Count;

        public void Add(Wind wind) => mList.Add(wind);

        public void Clear() => mList.Clear();

        public void RemoveAt(int index) => mList.RemoveAt(index);

        public IEnumerator<Wind> GetEnumerator() => mList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Wind[] ToShotParameters()
        {
            if (mList.Count == 0 || 
                mList.Count == 1 && mList[0].Velocity < 0.001.As(VelocityUnit.MetersPerSecond))
                return null;

            mList.Sort((a, b) =>
            {
                var av = a?.MaximumRange == null ? 0 : a.MaximumRange.Value.In(DistanceUnit.Meter);
                var bv = b?.MaximumRange == null ? 0 : b.MaximumRange.Value.In(DistanceUnit.Meter);
                return av.CompareTo(bv);
            });

            bool firstWindIsFar = mList[0].MaximumRange != null && mList[0].MaximumRange.Value > 1.As(DistanceUnit.Millimeter);

            Wind[] r = new Wind[firstWindIsFar ? mList.Count + 1 : mList.Count];

            if (firstWindIsFar)
            {
                r[0] = new Wind()
                {
                    MaximumRange = mList[0].MaximumRange,
                    Velocity = 0.As(VelocityUnit.MetersPerSecond),
                    Direction = 0.As(AngularUnit.Degree),
                };
            }

            for (int i = 0; i < mList.Count; i++)
            {
                Wind w = new Wind()
                {
                    Direction = mList[i].Direction,
                    Velocity = mList[i].Velocity
                };

                if (i < mList.Count - 1)
                    w.MaximumRange = mList[i + 1].MaximumRange;

                r[firstWindIsFar ? i + 1 : i] = w;
            }

            return r;
        }
    }
}
