using System.ComponentModel.DataAnnotations;

namespace PayRoll.Core.Model.Security
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string PassWord { get; set; }
        public string Key { set; get; }
    }
}
