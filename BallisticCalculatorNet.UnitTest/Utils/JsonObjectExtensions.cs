using System.Text.Json.Nodes;


namespace BallisticCalculatorNet.UnitTest.Utils
{
    public static class JsonObjectExtensions
    {
        public static JsonObjectAssertions Should(this JsonObject v) => new JsonObjectAssertions(v);
    }
}
