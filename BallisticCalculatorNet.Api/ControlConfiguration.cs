using Microsoft.Extensions.Configuration;
using Serilog.Core;
using System.Runtime.CompilerServices;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The class that provides access to the host configuration
    /// </summary>
    public static class ControlConfiguration
    {
        /// <summary>
        /// The configuration object
        /// </summary>
        public static IConfiguration Configuration { get; private set;}
        /// <summary>
        /// The logger
        /// </summary>
        public static Logger Logger { get; private set; }

        /// <summary>
        /// Initialization.
        /// 
        /// The method shall be called by the host app only
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public static void Initialize(IConfiguration configuration, Logger logger)
        {
            Configuration = configuration;
            Logger = logger;
        }
    }
}
