namespace Ladder
{
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using Saxon.Api;
    using System.Collections;

    public class XSDValidator : IXSDValidator
    {
        #region Constructors

        public XSDValidator()
        {
            // XSDFile = new FileInfo("DEFAULT.XSD");
            XSDFile = new FileInfo("./lib/apeEAD.xsd");
        }

        #endregion Constructors

        #region Properties

        public FileInfo XSDFile
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void ValidateXML(FileInfo sourceFile)
        {
            string dir = sourceFile.FullName.Replace(sourceFile.Name, "");
           

            string[] files = Directory.GetFiles(dir, "dataextract*.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                FileInfo input = new FileInfo(file);
             
                ValidateOneXML(input);
            }
        }
        public void ValidateOneXML(FileInfo sourceFile)
        {
            Steps.Log.DebugFormat("Validating sourcefile '{0}' with schema '{1}'", sourceFile.FullName, XSDFile.FullName);
            XmlReaderSettings settings = new XmlReaderSettings();
       
            settings.ValidationType = ValidationType.Schema;
            
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create(sourceFile.FullName, settings);

            // Parse the file. 
            while (reader.Read()) ;

        }
        // Display any warnings or errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
           
            if (args.Severity == XmlSeverityType.Error)
                Steps.Log.DebugFormat("\tValidation error: " + args.Message);
        }
      


        #endregion Methods
        }
    }
