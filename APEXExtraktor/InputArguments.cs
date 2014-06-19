namespace APEXExtractor
{
    using CmdLine;

    /// <summary>
    ///     This is a specific class for parsing input from the commandline.
    ///     It specifies the type, order, names and so on of the input
    /// </summary>
    [CommandLineArguments(Program = "APEXExtractor.exe", Title = "APEXExtractor",
        Description = "Extracting data from Daisy and converts the contents to APEX xml")]
    public class InputArguments
    {
        #region Properties

        [CommandLineParameter(Name = "EnableLog", Command = "l", Required = false,
            Description = "Specifies whether a logfile is generated", Default = false, ValueExample = "false")]
        public bool EnableLog
        {
            get; set;
        }

        [CommandLineParameter(Command = "?", Default = false, Description = "Show Help", Name = "Help", IsHelp = true)]
        public bool Help
        {
            get; set;
        }

        [CommandLineParameter(Name = "TargetFile", Command = "f", Required = true,
            Description = "Specifies the xmlfile the data are saved in", Default = "apexFromDaisy.xml")]
        public string TargetFile
        {
            get; set;
        }

        #endregion Properties
    }
}