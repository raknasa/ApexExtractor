namespace Ladder
{
    using System;
    using System.IO;
    using System.Reflection;

    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;

    public interface IXSDValidator
    {
        #region Properties

        FileInfo XSDFile
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        void ValidateXML(FileInfo sourceFile);

        #endregion Methods
    }

    public class Steps : ISteps
    {
        #region Fields

        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool _logEnabled;

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [log enabled].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [log enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool LogEnabled
        {
            get { return _logEnabled; }
            set
            {
                _logEnabled = value;
                if (value)
                {
                    InitateLog();
                }
                else
                {
                    BasicConfigurator.Configure(new MemoryAppender());
                }
            }
        }

        #endregion Properties

        #region Methods

        public FileInfo GetDaisyXML()
        {
            ISQLWorker worker = new SQLWorker();
            return worker.QueryDaisy();
        }

        public void TotalFlow(FileInfo apexFile)
        {
            try
            {
                FileInfo result = GetDaisyXML();
                TransformDaisy2APEX(result, apexFile);
                ValidateAPEXFile(apexFile);
                Log.Debug("TotalFlow done!");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void TransformDaisy2APEX(FileInfo sourceFile, FileInfo targetFile)
        {
            IXSLTWorker worker = new XSLTWorker();
            worker.TransformXML(sourceFile, targetFile);
        }

        public void ValidateAPEXFile(FileInfo sourceFile)
        {
            IXSDValidator worker = new XSDValidator();
            worker.ValidateXML(sourceFile);
        }

        private static void InitateLog()
        {
            var hierarchy = (Hierarchy) LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/
            var fileAppender = new FileAppender
                                   {
                                       AppendToFile = false,
                                       LockingModel = new FileAppender.MinimalLock(),
                                       File = "log.txt"
                                   };
            var pl = new PatternLayout {ConversionPattern = "%d [%2%t] %-5p [%-10c] %m%n%n"};
            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
        }

        #endregion Methods
    }
}