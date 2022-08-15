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
using FluentAssertions;
using FluentAssertions.Extension.Json;

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

            var jsonObject = File.ReadAllText(tempFile.FileName).AsJson();

            jsonObject.Should()
                .HaveProperty("state");

            jsonObject.Should()
                .HaveNoProperty("section1")
                .And
                .HaveObjectProperty("state");

            var state = jsonObject.GetProperty("state");

            state.Should()
                .HaveStringProperty("status", s => s == "x")
                .And
                .HaveObjectProperty("window1")
                .And
                .HaveObjectProperty("window2");

            var window1 = state.GetProperty("window1");

            window1.Should()
                .HaveStringProperty("top", s => s == "1")
                .And
                .HaveStringProperty("left", s => s == "2");

            var window2 = state.GetProperty("window2");

            window2.Should()
                .HaveStringProperty("top", s => s == "3")
                .And
                .HaveStringProperty("left", s => s == "4")
                .And
                .HaveObjectProperty("subsection");

            var ss = window2.GetProperty("subsection");

            ss.Should()
                .HaveStringProperty("x", s => s == "v1")
                .And
                .HaveStringProperty("y", s => s == "v2");
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

            var jsonObject = File.ReadAllText(tempFile.FileName).AsJson();

            jsonObject.Should()
                .HaveProperty("a")
                .Which.Should()
                    .BeObject();

            jsonObject.GetProperty("a")
                .Should()
                .HaveProperty("b")
                    .Which.Should()
                    .Be("1");

            jsonObject.Should()
                .HaveProperty("state")
                .Which.Should()
                    .BeObject()
                    .And
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

            var jsonObject = File.ReadAllText(tempFile.FileName).AsJson();

            jsonObject.Should()
                .HaveProperty("a")
                .Which.Should()
                    .BeObject();

            jsonObject
                .GetProperty("a")
                .Should()
                .HaveStringProperty("b", s => s == "1");

            jsonObject.Should()
                .HaveProperty("state")
                .Which.Should()
                    .BeObject();

            jsonObject
                .GetProperty("state")
                .Should()
                .HaveNoProperty("y")
                .And
                .HaveStringProperty("status", s => s == "x");
        }
    }
}
