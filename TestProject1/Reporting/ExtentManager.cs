using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Threading;

namespace TestProject1.Reporting
{
    public static class ExtentManager
    {
        private static ExtentReports? _extent;
      
        private static AsyncLocal<ExtentTest?> _test = new();
      
        private static ExtentTest? _globalTest;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                var reportPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestResults",
                    "ExtentReport.html");

                Directory.CreateDirectory(
                    Path.GetDirectoryName(reportPath)!);

                var spark = new ExtentSparkReporter(reportPath);

                _extent = new ExtentReports();
                _extent.AttachReporter(spark);

                _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                _extent.AddSystemInfo("Machine", Environment.MachineName);
                _extent.AddSystemInfo("Framework", ".NET 8 + Playwright");
            }

            return _extent;
        }

        public static void CreateTest(string testName)
        {
            var t = GetExtent().CreateTest(testName);
            _test.Value = t;
            _globalTest = t;
        }

   
        public static ExtentTest? GetTest()
        {
            return _test.Value ?? _globalTest;
        }

        public static void Flush()
        {
            _extent?.Flush();
        }
    }
}
