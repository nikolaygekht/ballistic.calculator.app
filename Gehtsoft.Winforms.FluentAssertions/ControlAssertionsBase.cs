using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class ControlAssertionsBase<T, T1> : ReferenceTypeAssertions<T, T1>
        where T : Control
        where T1 : ControlAssertionsBase<T, T1>

    {
        public ControlAssertionsBase(T subject) : base(subject)
        {
        }

        protected override string Identifier => "control";

        public AndConstraint<T1> HaveControl(string name, Type type, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(control => control.Control(name, type) != null)
                .FailWith("Expected {context:control} contains a control {0} of type {1} but it does not", name, type.Name);
            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> HaveControl<TC>(string name, string because = null, params object[] becauseParameters)
            where TC : Control => HaveControl(name, typeof(TC), because, becauseParameters);

        public AndConstraint<T1> HaveControl(string name, string because = null, params object[] becauseParameters)
            => HaveControl(name, typeof(Control), because, becauseParameters);

        public AndConstraint<T1> Exist(string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                  .BecauseOf(because, becauseParameters)
                  .Given(() => Subject)
                  .ForCondition(control => control != null)
                  .FailWith("Expected {context:control} to exists but it does not");

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> HaveType(Type type, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                  .BecauseOf(because, becauseParameters)
                  .Given(() => Subject)
                  .ForCondition(control => control != null)
                  .FailWith("Expected {context:control} to exists but it does not")
                  .Then
                  .ForCondition(control => type.IsInstanceOfType(control))
                  .FailWith("Expected {context:control} is expected to be a {0} but it is {1}", type.Name, Subject?.GetType().Name);

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> HaveType<TC>(string because = null, params object[] becauseParameters)
            where TC : Control => HaveType(typeof(TC), because, becauseParameters);

        public AndConstraint<T1> MatchAs<TC>(Expression<Func<TC, bool>> predicate, string because = null, params object[] becauseParameters)
            where TC : Control
        {
            Execute.Assertion
                  .BecauseOf(because, becauseParameters)
                  .Given(() => Subject)
                  .ForCondition(control => control != null)
                  .FailWith("Expected {context:control} to exists but it does not")
                  .Then
                  .ForCondition(control => control is TC t && predicate.Compile().Invoke(t))
                  .FailWith("Expected {context:control} to match {0} but it does not", predicate);
            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeEnabled(bool enabled = true, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                   .BecauseOf(because, becauseParameters)
                   .Given(() => Subject)
                   .ForCondition(control => control != null)
                   .FailWith("Expected {context:control} to exists but it does not")
                   .Then
                   .ForCondition(control => control?.Enabled == enabled)
                   .FailWith("Expected {context:control} to have enabled flag {0} but it has {1}", enabled, Subject?.Enabled);

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeDisabled(string because = null, params object[] becauseParameters) => BeEnabled(false, because, becauseParameters);

        public AndConstraint<T1> HaveText(string text, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                   .BecauseOf(because, becauseParameters)
                   .Given(() => Subject)
                   .ForCondition(control => control != null)
                   .FailWith("Expected {context:control} to exists but it does not")
                   .Then
                   .ForCondition(control => control?.Text == text)
                   .FailWith("Expected {context:control} to have text {0} but it has {1}", text, Subject?.Text);

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeBefore(Control otherControl, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                              .BecauseOf(because, becauseParameters)
                              .Given(() => Subject)
                              .ForCondition(control => control != null && otherControl != null)
                              .FailWith("Expected {context:control} and the control to compare be not null, but one of them is null")
                              .Then
                              .ForCondition(control => ReferenceEquals(control.Parent, otherControl.Parent))
                              .FailWith("Expected {context:control} to belong to the same parent as the control to compare with")
                              .Then
                              .ForCondition(control => control.TabStop && otherControl.TabStop)
                              .FailWith("Expected {context:control} and the control to compare to have TabStop enabled")
                              .Then
                              .ForCondition(control => control.TabIndex < otherControl.TabIndex)
                              .FailWith("Expected {context:control} to be before the specified control, but it is not");

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeImmediatelyBefore(Control otherControl, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                              .BecauseOf(because, becauseParameters)
                              .Given(() => Subject)
                              .ForCondition(control => control != null && otherControl != null)
                              .FailWith("Expected {context:control} and the control to compare be not null, but one of them is null")
                              .Then
                              .ForCondition(control => ReferenceEquals(control.Parent, otherControl.Parent))
                              .FailWith("Expected {context:control} to belong to the same parent as the control to compare with")
                              .Then
                              .ForCondition(control => control.TabStop && otherControl.TabStop)
                              .FailWith("Expected {context:control} and the control to compare to have TabStop enabled")
                              .Then
                              .ForCondition(control => control.TabIndex == otherControl.TabIndex - 1)
                              .FailWith("Expected {context:control} to be immediately before the specified control, but it is not");

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeAfter(Control otherControl, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                              .BecauseOf(because, becauseParameters)
                              .Given(() => Subject)
                              .ForCondition(control => control != null && otherControl != null)
                              .FailWith("Expected {context:control} and the control to compare be not null, but one of them is null")
                              .Then
                              .ForCondition(control => ReferenceEquals(control.Parent, otherControl.Parent))
                              .FailWith("Expected {context:control} to belong to the same parent as the control to compare with")
                              .Then
                              .ForCondition(control => control.TabStop && otherControl.TabStop)
                              .FailWith("Expected {context:control} and the control to compare to have TabStop enabled")
                              .Then
                              .ForCondition(control => control.TabIndex > otherControl.TabIndex)
                              .FailWith("Expected {context:control} to be after the specified control, but it is not");

            return new AndConstraint<T1>(this as T1);
        }

        public AndConstraint<T1> BeImmediatelyAfter(Control otherControl, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                              .BecauseOf(because, becauseParameters)
                              .Given(() => Subject)
                              .ForCondition(control => control != null && otherControl != null)
                              .FailWith("Expected {context:control} and the control to compare be not null, but one of them is null")
                              .Then
                              .ForCondition(control => ReferenceEquals(control.Parent, otherControl.Parent))
                              .FailWith("Expected {context:control} to belong to the same parent as the control to compare with")
                              .Then
                              .ForCondition(control => control.TabStop && otherControl.TabStop)
                              .FailWith("Expected {context:control} and the control to compare to have TabStop enabled")
                              .Then
                              .ForCondition(control => control.TabIndex == otherControl.TabIndex + 1)
                              .FailWith("Expected {context:control} to be immediately after the specified control, but it is not");

            return new AndConstraint<T1>(this as T1);
        }
    }
}
