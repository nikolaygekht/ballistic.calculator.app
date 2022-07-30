using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Text.Json.Nodes;


namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class JsonObjectAssertions : ReferenceTypeAssertions<JsonObject, JsonObjectAssertions>
    {
        public JsonObjectAssertions(JsonObject subject) : base(subject)
        {
        }

        protected override string Identifier => "json";

        public AndConstraint<JsonObjectAssertions> HaveProperty(string name, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] != null)
                .FailWith("Expected {context:json} to have property {0} but it does not have", name);
            return new AndConstraint<JsonObjectAssertions>(this);
        }

        public AndConstraint<JsonObjectAssertions> HaveNoProperty(string name, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] == null)
                .FailWith("Expected {context:json} to have no property {0} but it does has", name);
            return new AndConstraint<JsonObjectAssertions>(this);
        }

        public AndConstraint<JsonObjectAssertions> HaveValueProperty(string name, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] != null)
                .FailWith("Expected {context:json} to have property {0} but it does not have", name)
                .Then
                .ForCondition(j => j[name] is JsonValue)
                .FailWith("Expected {context:json} to have property {0} which is value, but it is not", name);
            return new AndConstraint<JsonObjectAssertions>(this);
        }

        public AndConstraint<JsonObjectAssertions> HaveValuePropertyEqualTo(string name, string value, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] != null)
                .FailWith("Expected {context:json} to have property {0} but it does not have", name)
                .Then
                .ForCondition(j => j[name] is JsonValue)
                .FailWith("Expected {context:json} to have property {0} which is value, but it is not", name)
                .Then
                .ForCondition(j => j[name].GetValue<string>() == value)
                .FailWith("Expected {context:json} to have property {0} value {1} but it is not", name, value);
            return new AndConstraint<JsonObjectAssertions>(this);
        }

        public AndConstraint<JsonObjectAssertions> HaveObjectProperty(string name, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] != null)
                .FailWith("Expected {context:json} to have property {0} but it does not have", name)
                .Then
                .ForCondition(j => j[name] is JsonObject)
                .FailWith("Expected {context:json} to have property {0} which is an object, but it is not", name);
            return new AndConstraint<JsonObjectAssertions>(this);
        }

        public AndConstraint<JsonObjectAssertions> HaveArrayProperty(string name, string because = null, params object[] becauseParameters)
        {
            Execute.Assertion
                .BecauseOf(because, becauseParameters)
                .Given(() => Subject)
                .ForCondition(j => j[name] != null)
                .FailWith("Expected {context:json} to have property {0} but it does not have", name)
                .Then
                .ForCondition(j => j[name] is JsonArray)
                .FailWith("Expected {context:json} to have property {0} which is an array, but it is not", name);
            return new AndConstraint<JsonObjectAssertions>(this);
        }
    }
}
