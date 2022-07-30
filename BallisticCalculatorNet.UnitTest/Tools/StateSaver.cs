using BallisticCalculatorNet.Common;
using BallisticCalculatorNet.UnitTest.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace BallisticCalculatorNet.UnitTest.Tools
{
    public class StateSaver
    {
        [Fact]
        public void TestSaveContent()
        {
            using var tempFile = TemporaryFile.New();

            var config = (new ConfigurationBuilder())
                .AddCommandLine(Array.Empty<string>()).Build();

            config["section1:key1"] = "a";
            config["section1:key2"] = "b";

            config["state:status"] = "x";
            config["state:window1:top"] = "1";
            config["state:window1:left"] = "2";
            config["state:window2:top"] = "3";
            config["state:window2:left"] = "4";
            config["state:window2:subsection:x"] = "v1";
            config["state:window2:subsection:y"] = "v2";

            ConfigurationStateSaver.SaveStateToFile(config, tempFile.FileName, "state");

            var jsonText = File.ReadAllText(tempFile.FileName);
            var jsonObject = JsonSerializer.Deserialize<JsonObject>(jsonText);

            jsonObject.Should()
                .HaveProperty("state")
                .And
                .HaveNoProperty("section1");

            jsonObject.Should()
                .HaveObjectProperty("state");

            var state = jsonObject["state"].AsObject();

            state.Should()
                .HaveValuePropertyEqualTo("status", "x")
                .And
                .HaveObjectProperty("window1")
                .And
                .HaveObjectProperty("window2");

            var window1 = state["window1"].AsObject();

            window1.Should()
                .HaveValuePropertyEqualTo("top", "1")
                .And
                .HaveValuePropertyEqualTo("left", "2");

            var window2 = state["window2"].AsObject();

            window2.Should()
                .HaveValuePropertyEqualTo("top", "3")
                .And
                .HaveValuePropertyEqualTo("left", "4");

            window2.Should()
                .HaveObjectProperty("subsection");

            var ss = window2["subsection"].AsObject();

            ss.Should()
                .HaveValueProperty("x", "v1")
                .And
                .HaveValueProperty("y", "v2");
        }

        [Fact]
        public void TestJoinContent_NoState()
        {
            using var tempFile = TemporaryFile.New();

            File.WriteAllText(tempFile.FileName, "{ \"a\" : { \"b\" : \"1\" } }");

            var config = (new ConfigurationBuilder())
                .AddCommandLine(Array.Empty<string>()).Build();

            config["state:status"] = "x";

            ConfigurationStateSaver.SaveStateToFile(config, tempFile.FileName, "state");

            var jsonText = File.ReadAllText(tempFile.FileName);
            var jsonObject = JsonSerializer.Deserialize<JsonObject>(jsonText);

            jsonObject.Should()
                .HaveObjectProperty("a");

            jsonObject["a"].AsObject()
                .Should().HaveValuePropertyEqualTo("b", "1");

            jsonObject.Should()
                .HaveObjectProperty("state");

            var state = jsonObject["state"].AsObject();

            state.Should()
                .HaveProperty("status");
        }

        [Fact]
        public void TestJoinContent_HadState()
        {
            using var tempFile = TemporaryFile.New();

            File.WriteAllText(tempFile.FileName, "{ \"a\" : { \"b\" : \"1\" } , \"state\" : { \"y\" : \"z\" } }");

            var config = (new ConfigurationBuilder())
                .AddCommandLine(Array.Empty<string>()).Build();

            config["state:status"] = "x";

            ConfigurationStateSaver.SaveStateToFile(config, tempFile.FileName, "state");

            var jsonText = File.ReadAllText(tempFile.FileName);
            var jsonObject = JsonSerializer.Deserialize<JsonObject>(jsonText);

            jsonObject.Should()
                .HaveObjectProperty("a");

            jsonObject["a"].AsObject()
                .Should().HaveValuePropertyEqualTo("b", "1");

            jsonObject.Should()
                .HaveObjectProperty("state");
            
            var state = jsonObject["state"].AsObject();

            state.Should()
                .HaveProperty("status")
                .And
                .HaveNoProperty("y");
        }
    }
}
