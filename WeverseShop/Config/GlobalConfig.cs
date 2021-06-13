

using WeverseShop.Model;

namespace WeverseShop.Config
{
    /// <summary>
    /// Appium setting file bind용 class
    /// </summary>
    public class GlobalConfig
    {
        public string AutomationName { get; set; }
        public OperationSystem PlatformName { get; set; }
        public string DeviceName { get; set; }
        public string App { get; set; }
        public int TimeoutMilliseconds { get; set; }
    }
}