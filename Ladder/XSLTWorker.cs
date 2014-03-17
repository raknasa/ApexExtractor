//using System;
//using System.Text;
//using System.Xml;
//using Saxon.Api;
namespace Ladder
{
    using System.IO;

    public class XSLTWorker : IXSLTWorker
    {
        #region Constructors

        public XSLTWorker()
        {
            XSLTFile = new FileInfo("DEFAULT.XSLT");
        }

        #endregion Constructors

        #region Properties

        public FileInfo XSLTFile
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public void TransformXML(FileInfo sourceFile, FileInfo targetFile)
        {
            Steps.Log.Debug("Brug ProcessStartInfo class");
            Steps.Log.Debug("Skriv 'Transform -s:source -xsl:stylesheet -o:output'");

            Steps.Log.DebugFormat("Dvs: 'Transform -s:{0} -xsl:{1} -o:{2}'", sourceFile.FullName, XSLTFile.FullName,
                                          targetFile);
            Steps.Log.Debug("Forudsætter at saxon er installeret");
            Steps.Log.Debug("Alternativt: Kald 'DoSaxonInternally(XSLTFile, targetFile);'");
            Steps.Log.Debug("Kender ikke den øvre grænse for mængden af data");

            //DoSaxonInternally(XSLTFile, targetFile);
        }

        #endregion Methods

        #region Other

        //private void DoSaxonInternally(FileInfo xsltFile, FileInfo targetFile)
        //{
        //    XsltCompiler compiler = null;
        //    try
        //    {
        //        var processor = new Processor();
        //        compiler = processor.NewXsltCompiler();
        //        var sr = new StreamReader(xsltFile.FullName);
        //        var xslt = sr.ReadToEnd();
        //        sr.Close();
        //        var reader = new StringReader(xslt);
        //        XsltExecutable exec = compiler.Compile(reader);
        //        XsltTransformer transformer = exec.Load();
        //        transformer.InitialTemplate = new QName("", "main");
        //        var xmlResult = new TextWriterDestination(new XmlTextWriter(targetFile.FullName,Encoding.Unicode));
        //        transformer.Run(xmlResult);
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        var errMsg = ex.Message;
        //        var errList = compiler != null ? compiler.ErrorList : null;
        //    }
        //}

        #endregion Other
    }
}