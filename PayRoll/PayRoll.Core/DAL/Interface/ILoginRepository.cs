using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.Model.Security;

namespace PayRoll.Core.DAL.Interface
{
    public interface ILoginRepository
    {
        User GetLoginInfo(string userName);
        User GetUserSession(string userName);
        User Get(string employeeId);
    }
}
