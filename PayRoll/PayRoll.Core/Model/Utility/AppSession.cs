using System;
using System.Collections.Generic;
using PayRoll.Core.Model.Security;
using PayRoll.Core.Model;

namespace PayRoll.Core.Model.Utility
{
    public class AppSession
    {
        public string UserId { get; set; }
        public string AccessLevel { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string ChangePassword { get; set; }
        public Boolean IsActive { get; set; }
        public string EntryUserId { get; set; }
        public Boolean IsLockedOut { get; set; }
        public string RoleId { get; set; }
        public string SelfServiceCategoryId { get; set; }

    }
}
