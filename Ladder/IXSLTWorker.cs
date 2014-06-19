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

        void TransformXML(DirectoryInfo sourcedir, DirectoryInfo targetdir);

        #endregion Methods
    }
}