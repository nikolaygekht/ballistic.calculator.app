using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal sealed class Defer : IDisposable
    {
        private readonly Action mAction;

        public Defer(Action action)
        {
            mAction = action;
        }

        public void Dispose()
        {
            mAction.Invoke();
        }

        public static Defer Action(Action action) => new Defer(action);
    }
}
