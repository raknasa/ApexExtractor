namespace Ladder
{
    using System.IO;

    public interface ISteps
    {
        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [log enabled].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [log enabled]; otherwise, <c>false</c>.
        /// </value>
        bool LogEnabled
        {
            get; set;
        }
        DirectoryInfo LogFolder
        {
            get; set;
        }
        #endregion Properties

        #region Methods

        void TotalFlow(FileInfo apexFile);

        int GetDaisyXML(FileInfo fileInfo, int sidsthentet);

        void TransformDaisy2APEX(DirectoryInfo sourcedir, DirectoryInfo targetdir);

        void ValidateAPEXFile(FileInfo sourceFile);

        #endregion Methods

      
    }
}