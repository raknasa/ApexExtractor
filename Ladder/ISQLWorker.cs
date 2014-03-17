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

        FileInfo QueryDaisy();

        #endregion Methods
    }
}