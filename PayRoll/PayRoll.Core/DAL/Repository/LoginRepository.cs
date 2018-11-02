using PayRoll.Core.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PayRoll.Core.Model.Security;
using PayRoll.Core.Model.Utility;

namespace PayRoll.Core.DAL.Repository
{
    public class LoginRepository : DataCommon, ILoginRepository
    {     
        internal LoginRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Get(string employeeId)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select * from Settings.Users a where a.EmployeeId='"+employeeId+@"'");
            _inputParameters.Clear();
            _inputParameters.Add(new Parameter { Name = "@employeeId", Type = DbType.String, Value = employeeId });
            var data = _dbContext.GetDataTable(strBuilder.ToString());
            return (from DataRow row in data.Rows select User.ConvertToUser(row)).FirstOrDefault();
        }

        public User GetUserSession(string employeeId)
        {
            throw new NotImplementedException();
        }

        public  User GetLoginInfo(string userName)
        {
            throw new NotImplementedException();
        }

    }
}
