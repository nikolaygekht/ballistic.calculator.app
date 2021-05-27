using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.Common;
using BallisticCalculatorNet.Common.PersistentState;
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

        private static ApplicationStateController<ApplicationState> mState;

        public static ApplicationState State => mState.State;

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
                        .AddCommandLine(args, switchMappings)
                        .Build();

            Logger = new LoggerConfiguration()
                .MinimumLevel.Is(MinimumLogLevel)
                .WriteTo.File(LogTarget, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
                .CreateLogger();

            try
            {
                mState = new ApplicationStateController<ApplicationState>(ApplicationFolder, "ballisticCalculator");
            }
            catch (Exception e)
            {
                Logger.Warning(e, "Can't read application state");
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            Initialize(args);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += ThreadExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm());

            try
            {
                mState.Save();
            }
            catch (Exception e)
            {
                Logger.Warning(e, "Can't write application state");
            }
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
