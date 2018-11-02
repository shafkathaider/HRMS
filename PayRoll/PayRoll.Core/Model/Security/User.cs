using System;
using System.Data;

namespace PayRoll.Core.Model.Security
{
    public class User
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
        public static User ConvertToUser(DataRow row)
        {
            return new User
            {
                UserId = row.Table.Columns.Contains("UserId") ? Convert.ToString(row["UserId"]) : "",
                AccessLevel = row.Table.Columns.Contains("AccessLevel") ? Convert.ToString(row["AccessLevel"]) : "",
                UserName = row.Table.Columns.Contains("UserName") ? Convert.ToString(row["UserName"]) : "",
                UserFullName = row.Table.Columns.Contains("UserFullName") ? Convert.ToString(row["UserFullName"]) : "",
                EmployeeId = row.Table.Columns.Contains("EmployeeId") ? Convert.ToString(row["EmployeeId"]) : "",
                RoleId = row.Table.Columns.Contains("RoleId") ? Convert.ToString(row["RoleId"]) : "",
                IsActive = row.Table.Columns.Contains("IsActive") ? Convert.ToBoolean(row["IsActive"]) : false,
                IsLockedOut = row.Table.Columns.Contains("IsLockedOut") ? Convert.ToBoolean(row["IsLockedOut"]) : false,
                SelfServiceCategoryId = row.Table.Columns.Contains("SelfServiceCategoryId") ? Convert.ToString(row["SelfServiceCategoryId"]) : "",
                Password = row.Table.Columns.Contains("Password") ? Convert.ToString(row["Password"]) : "",
                PasswordSalt = row.Table.Columns.Contains("PasswordSalt") ? Convert.ToString(row["PasswordSalt"]) : "",
                ChangePassword = row.Table.Columns.Contains("ChangePassword") ? Convert.ToString(row["ChangePassword"]) : "",
                EntryUserId = row.Table.Columns.Contains("EntryUserId") ? Convert.ToString(row["EntryUserId"]) : ""
            };
        }




    }
}
