using Microsoft.Extensions.Configuration;
using Serilog.Core;

namespace BallisticCalculatorNet.InputPanels
{
    public static class ControlConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static Logger Logger { get; set; }
    }
}
