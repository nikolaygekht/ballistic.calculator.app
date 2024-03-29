﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.Api;
using BallisticCalculatorNet.Api.Interop;
using BallisticCalculatorNet.Common;
using BallisticCalculatorNet.InputPanels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace BallisticCalculatorNet
{
    internal static class Program
    {
        public static Logger Logger { get; private set; }

        public static string ApplicationFolder { get; private set; }

        public static IConfiguration Configuration { get; private set; }

        private static InteropServer gInteropServer;

        internal static ExtensionsManager ExtensionsManager { get; private set; }

        public static string DataFolder
        {
            get
            {
                var startFolder = new FileInfo(Application.ExecutablePath).Directory;
                return SeekForData(startFolder);
            }
        }

        private static string SeekForData(DirectoryInfo baseFolder)
        {
            var candidate = Path.Combine(baseFolder.FullName, "data");
            if (Directory.Exists(candidate))
                return Path.Combine(baseFolder.FullName, "data");
            if (baseFolder.Parent == null)
                return null;
            else
                return SeekForData(baseFolder.Parent);
        }

        private static LogEventLevel MinimumLogLevel
        {
            get
            {
                var levelName = Configuration?["log:level"] ?? "error";
                return levelName switch
                {
                    "info" => LogEventLevel.Information,
                    "information" => LogEventLevel.Information,
                    "warning" => LogEventLevel.Warning,
                    "error" => LogEventLevel.Error,
                    "fatal" => LogEventLevel.Fatal,
                    _ => LogEventLevel.Error
                };
            }
        }

        private static string LogTarget
        {
            get
            {
                var path = Configuration?["log:destination"] ?? "./ballistic-calculator-.log";
                if (!Path.IsPathRooted(path))
                    path = Path.Combine(ApplicationFolder, path);
                return path;
            }
        }

        internal static void Initialize(string[] args)
        {
            ApplicationFolder = new FileInfo(typeof(Program).Assembly.Location).Directory.FullName;

            var switchMappings = new Dictionary<string, string>()
            {
               { "--open", "command-line:open" },
               { "--log-level", "log:level" },
               { "--log-destination", "log:destination" },
            };

            Configuration = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(ApplicationFolder, "commonConfiguration.json"), true)
                        .AddJsonFile(Path.Combine(ApplicationFolder, "ballisticCalculator.json"), true)
                        .AddJsonFile(Path.Combine(ApplicationFolder, "ballisticCalculator.state.json"), true)
                        .AddCommandLine(args, switchMappings)
                        .Build();

            Logger = new LoggerConfiguration()
                .MinimumLevel.Is(MinimumLogLevel)
                .WriteTo.File(LogTarget, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
                .CreateLogger();

            var datafolder = DataFolder;
            if (datafolder != null)
                Configuration["datafolder"] = datafolder;

            ControlConfiguration.Initialize(Configuration, Logger);
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            Initialize(args);

            ExtensionsManager = new ExtensionsManager();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += ThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new AppForm();
            //if (ExtensionsManager.Commands.Count > 0)
            //{
                var s = Configuration["interop:port"];
                if (s == null || !int.TryParse(s, out var port))
                    port = 32800;
                gInteropServer = new InteropServer(form, port);
                gInteropServer.Start();
            //}
            Application.Run(form);

            Configuration.SaveStateToFile(Path.Combine(ApplicationFolder, "ballisticCalculator.state.json"), "state");
            if (gInteropServer != null && gInteropServer.Started)
            {
                gInteropServer.Stop();
                gInteropServer.Dispose();
            }
            ExtensionsManager.Dispose();
        }

        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Logger?.Fatal(e.Exception, "Unhandled Exception");
            ExceptionForm f = new ExceptionForm(e.Exception);
            f.ShowDialog();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            if (args.ExceptionObject is System.Exception e)
                Logger?.Fatal(e, "Unhandled exception");
            else
                Logger?.Fatal(args.ExceptionObject.ToString(), "Unhandled exception");
            ExceptionForm f = new ExceptionForm(args.ExceptionObject);
            f.ShowDialog();
        }
    }
}
