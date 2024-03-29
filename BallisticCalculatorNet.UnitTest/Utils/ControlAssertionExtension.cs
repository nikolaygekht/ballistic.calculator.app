﻿using System;
using System.Windows.Forms;
using Gehtsoft.Measurements;
using Gehtsoft.Winforms.FluentAssertions;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public static class ControlAssertionExtension
    {
        public static MeasurementControlAssertions Should(this MeasurementControl.MeasurementControl control) => new MeasurementControlAssertions(control);

        public static MeasurementControl.MeasurementControl MeasurementControl(this Control parent, string name) => parent.Control<MeasurementControl.MeasurementControl>(name);
    }
}
