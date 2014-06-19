namespace Ladder
{
    using System.IO;

    public interface ISQLWorker
    {
        #region Properties

        string ConnectionString
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        int QueryDaisy(FileInfo newXmlFile, int sidsthentet);

        #endregion Methods
    }
}