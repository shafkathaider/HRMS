namespace PayRoll.Core.Model.Utility
{
    public class BllCommon
    {
        public readonly DbContext _dbContext;
        public BllCommon()
        {
            _dbContext = new DbContext(AppDbConnection.ConnectionString, "System.Data.SqlClient");
        }
    }
}
