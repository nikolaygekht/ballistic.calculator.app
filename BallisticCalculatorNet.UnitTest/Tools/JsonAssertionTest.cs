using System;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;
using Gehtsoft.Winforms.FluentAssertions;
using BallisticCalculatorNet.UnitTest.Utils;
using System.Text.Json.Nodes;

namespace BallisticCalculatorNet.UnitTest.Tools
{
    public class JsonAssertionTest
    {
        [Fact]
        public void HaveProperty_OK()
        {
            var json = new JsonObject();
            json.Add("property", "abcd");
            ((Action)(() => json.Should().HaveProperty("property"))).Should().NotThrow();
        }

        [Fact]
        public void HaveProperty_Fail()
        {
            var json = new JsonObject();
            json.Add("property1", "abcd");
            ((Action)(() => json.Should().HaveProperty("property2"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveValueProperty_OK()
        {
            var json = new JsonObject();
            json.Add("property", "abcd");
            ((Action)(() => json.Should().HaveValueProperty("property"))).Should().NotThrow();
        }

        [Fact]
        public void HaveValueProperty_Fail_NoProperty()
        {
            var json = new JsonObject();
            json.Add("property1", "abcd");
            ((Action)(() => json.Should().HaveValueProperty("property2"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveValueProperty_Fail_WrongType()
        {
            var json = new JsonObject();
            json.Add("property1", new JsonObject());
            ((Action)(() => json.Should().HaveValueProperty("property1"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveValuePropertyEqualTo_OK()
        {
            var json = new JsonObject();
            json.Add("property", "abcd");
            ((Action)(() => json.Should().HaveValuePropertyEqualTo("property", "abcd"))).Should().NotThrow();
        }

        [Fact]
        public void HaveValuePropertyEqualTo_Fail_NoProperty()
        {
            var json = new JsonObject();
            json.Add("property1", "abcd");
            ((Action)(() => json.Should().HaveValuePropertyEqualTo("property2", "abcd"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveValuePropertyEqualTo_Fail_WrongType()
        {
            var json = new JsonObject();
            json.Add("property1", new JsonObject());
            ((Action)(() => json.Should().HaveValuePropertyEqualTo("property1", "abcd"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveValuePropertyEqualTo_Fail_WrongValue()
        {
            var json = new JsonObject();
            json.Add("property", "abcd1");
            ((Action)(() => json.Should().HaveValuePropertyEqualTo("property", "abcd2"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveObjectProperty_OK()
        {
            var json = new JsonObject();
            json.Add("property", new JsonObject());
            ((Action)(() => json.Should().HaveObjectProperty("property"))).Should().NotThrow();
        }

        [Fact]
        public void HaveObjectProperty_Fail_NoProperty()
        {
            var json = new JsonObject();
            json.Add("property1", "abcd");
            ((Action)(() => json.Should().HaveObjectProperty("property2"))).Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveObjectProperty_Fail_WrongType()
        {
            var json = new JsonObject();
            json.Add("property1", "abcd");
            ((Action)(() => json.Should().HaveObjectProperty("property1"))).Should().Throw<XunitException>();
        }

    }
}
