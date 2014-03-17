//using PetaPoco;
namespace Ladder
{
    using System.IO;

    public class SQLWorker : ISQLWorker
    {
        #region Constructors

        public SQLWorker()
        {
            ConnectionString = "DEFAULTDATABASE";
        }

        #endregion Constructors

        #region Properties

        public string ConnectionString
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public FileInfo QueryDaisy()
        {
            Steps.Log.DebugFormat("Logon til Daisy med værdi for '{0}'", ConnectionString);
              //  var db = new Database(ConnectionString);
            Steps.Log.Debug("Execute SQL");
            //Sql query = GetQuery();
               // IEnumerable<dynamic> result = db.Query<dynamic>(query);
            var newXMLFile = new FileInfo(Path.GetRandomFileName());
            Steps.Log.DebugFormat("Write result til filen '{0}'", newXMLFile);
            return newXMLFile;
        }

        #endregion Methods

        #region Other

        //private Sql GetQuery()
        //{
        //    return Sql.Builder.Append("Select osv");
        //}

        #endregion Other
    }
}