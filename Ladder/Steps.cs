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
        private DirectoryInfo _logFolder;
    
        #endregion Fields

        #region Properties

        public DirectoryInfo LogFolder
        {
            get { return _logFolder; }
            set { _logFolder = value; }
          
           
        }

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

        public int GetDaisyXML(FileInfo resultat, int sidsthentet)
        {
            try
            {
                ISQLWorker worker = new SQLWorker();
                return  worker.QueryDaisy(resultat, sidsthentet);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return sidsthentet;
            }
        }



        public void TransformDaisy2APEX(DirectoryInfo sourcedir, DirectoryInfo targetdir)
        {
            try
            {
                IXSLTWorker worker = new XSLTWorker();
                worker.TransformXML(sourcedir, targetdir);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void ValidateAPEXFile(FileInfo sourceFile)
        {
            try
            {
                IXSDValidator worker = new XSDValidator();
                worker.ValidateXML(sourceFile);
            }
            catch (Exception e)
            {

                Log.Error(e);
            }
          
        }

        public void InitateLog()
        {
           
           
            var hierarchy = (Hierarchy) LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/
            var fileAppender = new FileAppender
                                   {
                                      // AppendToFile = false,
                                      AppendToFile = true,
                                       LockingModel = new FileAppender.MinimalLock(),
                                       File = _logFolder.FullName + @"\ApexLog.txt"
                                      
                                   };
            var pl = new PatternLayout {ConversionPattern = "%d [%2%t] %-5p [%-10c] %m%n%n"};
            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
        }
        public void TotalFlow(FileInfo apexFile)
        {
            //    try
            //    {

            //        FileInfo result = GetDaisyXML();
            //        TransformDaisy2APEX(result, apexFile);
            //        ValidateAPEXFile(apexFile);
            //        Log.Debug("TotalFlow done!");
            //    }
            //    catch (Exception e)
            //    {
            //        Log.Error(e);
            //    }
        }
        #endregion Methods
    }
}