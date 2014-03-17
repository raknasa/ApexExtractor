namespace Ladder
{
    using System.IO;

    public interface IXSLTWorker
    {
        #region Properties

        FileInfo XSLTFile
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        void TransformXML(FileInfo sourceFile, FileInfo targetFile);

        #endregion Methods
    }
}