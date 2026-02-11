using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject2.Reporting
{
    public static class ExtentManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                var reportPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "TestResults",
                    "ExtentReport.html");

                Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

                var htmlReporter = new ExtentSparkReporter(reportPath);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }

            return _extent;
        }

        public static ExtentTest CreateTest(string scenarioName)
        {
            _test = GetExtent().CreateTest(scenarioName);
            return _test;
        }

        public static ExtentTest GetTest()
        {
            return _test;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}
