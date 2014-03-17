namespace Ladder
{
    using System.IO;

    public class XSDValidator : IXSDValidator
    {
        #region Constructors

        public XSDValidator()
        {
            XSDFile = new FileInfo("DEFAULT.XSD");
        }

        #endregion Constructors

        #region Properties

        public FileInfo XSDFile
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public void ValidateXML(FileInfo sourceFile)
        {
            Steps.Log.DebugFormat("Validating sourcefile '{0}' with schema '{1}'", sourceFile.FullName, XSDFile.FullName);
        }

        #endregion Methods
    }
}