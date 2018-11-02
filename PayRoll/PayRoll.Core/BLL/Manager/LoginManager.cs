using System;
using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.DAL.Repository;
using PayRoll.Core.Model.Security;
using PayRoll.Core.Model.Utility;

namespace PayRoll.Core.BLL.Manager
{
    public class LoginManager : BllCommon, ILoginManager
    {
        private readonly ILoginRepository _iLoginRepository;
 

        public LoginManager()
        {
       
            _iLoginRepository = new LoginRepository(_dbContext);
        }

        #region Login
        public Message DoLogin(string employeeId, string password)
        {
            Message message;

            try
            {
                _dbContext.Open();
                var logininfo = _iLoginRepository.Get(employeeId);

                if (logininfo != null)
                {

                    string strDecPass = STLPasswordEncryptDecrypt.GetInstance().GetDecryptedUserPwd(logininfo.Password);
                    message = !String.Equals(password, strDecPass)
                        ? SetMessages.SetErrorMessage("Invalid user PIN or password")
                        : SetMessages.SetSuccessMessage("success");
                    if (!logininfo.IsActive)
                    {
                        message = SetMessages.SetErrorMessage("Either your account is in-active or locked");
                    }
                }
                else
                {
                    message = SetMessages.SetErrorMessage("Invalid Username or Password!!! Please Check...");
                }
            }
            catch (Exception ex)
            {
                message = SetMessages.SetErrorMessage("Exception Occurred!!!!!! Ex Message : " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        #endregion

        #region GetSession
        public User GetUserSession(string userName)
        {

            try
            {
                _dbContext.Open();
                var data = _iLoginRepository.GetUserSession(userName);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
            #endregion


        }
    }
}
