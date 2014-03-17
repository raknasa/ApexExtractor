namespace APEXExtractor
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using CmdLine;

    using Ladder;

    internal static class Program
    {
        #region Fields

        private const int AttachParentProcess = -1;

        #endregion Fields

        #region Methods

        // defines for commandline output
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(AttachParentProcess);

            if (args.Length > 0)
            {
                try
                {
                    var arguments = CommandLine.Parse<InputArguments>();
                    ISteps ladder = new Steps();
                    ladder.LogEnabled = arguments.EnableLog;
                    ladder.TotalFlow(new FileInfo(arguments.TargetFile));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }

                // sending the enter key is not really needed, but otherwise the user thinks the app is still running by looking at the commandline. The enter key takes care of displaying the prompt again.
                SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        #endregion Methods
    }
}