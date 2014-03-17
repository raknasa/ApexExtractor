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

        #endregion Properties

        #region Methods

        FileInfo GetDaisyXML();

        void TotalFlow(FileInfo apexFile);

        void TransformDaisy2APEX(FileInfo sourceFile, FileInfo targetFile);

        void ValidateAPEXFile(FileInfo sourceFile);

        #endregion Methods
    }
}