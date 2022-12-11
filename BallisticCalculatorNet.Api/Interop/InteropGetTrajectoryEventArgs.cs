using System;

namespace BallisticCalculatorNet.Api.Interop
{
    public class InteropGetTrajectoryEventArgs : EventArgs
    {
        public InteropGetTrajectoryResponse Response { get; set; }
    }
}
