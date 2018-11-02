using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.Model.Security;
using PayRoll.Core.Model.Utility;

namespace PayRoll.Core.BLL.Interface
{
    public interface ILoginManager
    {
        Message DoLogin(string userName, string password);
        User GetUserSession(string employeeId);
    }
}
