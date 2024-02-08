using System.Diagnostics;

namespace WebTeX.Core
{
    public static class CommandInvoker
    {
        public static bool InvokeProcess(String processName, String processArgument, String? workingDirectory = null)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(processName);
                processStartInfo.Arguments = processArgument;
                if (workingDirectory != null) processStartInfo.WorkingDirectory = workingDirectory;

                Process _process = Process.Start(processStartInfo);
                _process.WaitForExit();

                return _process.ExitCode == 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
