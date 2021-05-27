using System;

namespace BallisticCalculatorNet.Common.PersistentState
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]
    public sealed class JsonAssignDefaultIfNullAttribute : Attribute
    {
    }
}
