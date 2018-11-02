using System;

namespace PayRoll.Core.Model.Utility
{
    public class STLPasswordEncryptDecrypt
    {
        private const string PassCmpStr1 = "98760555";
        private const string PassCmpStr2 = "12340555";
        private const int IniVal = 60;
        private const int ValRange = 65;
        string AppPassword2 = "12340555";

        private static STLPasswordEncryptDecrypt thisInstance = new STLPasswordEncryptDecrypt();


        private STLPasswordEncryptDecrypt()
        {
        }

        public static STLPasswordEncryptDecrypt GetInstance()
        {
            return thisInstance;
        }


        public string GetDecryptedUserPwd(string strUserPassword)
        {
            return PMS_RecoverPassword(strUserPassword, PassCmpStr1);
        }

        private string PMS_RecoverPassword(string fpass, string AppPass)
        {
            string tempPMS_RecoverPassword = null;
            try
            {
                int v2 = 0;
                int v1 = 0;
                int v3 = 0;
                string s2 = "";
                int ln1 = 0;
                int t2 = 0;
                int t1 = 0;
                int ln = 0;
                int ln3 = 0;

                if (AppPass != PassCmpStr1)
                {
                    return "";
                }

                tempPMS_RecoverPassword = s2;

                ln = fpass.Length;
                if (ln == 0)
                {
                    return tempPMS_RecoverPassword;
                }

                int tempFor1 = ln;
                for (ln1 = 0; ln1 < tempFor1; ln1++)
                {
                    v1 = System.Convert.ToInt32(Convert.ToChar(fpass.Substring(ln1, 1))) - IniVal;
                    ln3 = ln1 + 1;
                    v2 = System.Convert.ToInt32(Convert.ToChar(fpass.Substring(ln3, 1))) - IniVal;
                    ln3 = ln3 + 1;
                    v3 = System.Convert.ToInt32(Convert.ToChar(fpass.Substring(ln3, 1))) - IniVal;
                    ln3 = ln3 + 1;
                    if (v3 == 1)
                    {
                        t1 = v1 + v2;
                    }
                    else
                    {
                        t1 = System.Math.Abs(v2 - v1);
                    }
                    ln3 = ln3 + t1;
                    s2 = s2 + fpass.Substring(ln3, 1);
                    ln1 = ln3;
                }
                tempPMS_RecoverPassword = s2.Substring(1, s2.Length - 2);
            }
            catch
            {
            }
            return tempPMS_RecoverPassword;
        }


        public string GetEncryptedSrvPwd(string strUserPassword)
        {
            string strRet = "";
            PMS_FinalGenPassServer(strUserPassword, AppPassword2, ref strRet);
            return strRet;
        }


        public string GetEncryptedUserPwd(string strUserPassword)
        {
            string strRet = PMS_GeneratePassword(strUserPassword, PassCmpStr1);
            return strRet;
        }


        public string PMS_GeneratePassword(string fpass, string AppPass)
        {
            string tempPMS_GeneratePassword = null;
            try
            {
                int v3 = 0;
                int v1 = 0;
                int v2 = 0;
                int iii = 0;
                string s2 = "";
                int ln = 0;
                int t1 = 0;
                int t2 = 0;
                int ln1 = 0;


                if (!AppPass.Equals(PassCmpStr1))
                {
                    return "";
                }

                s2 = "";
                tempPMS_GeneratePassword = s2;
                fpass = "Z" + fpass + "A";

                ln = fpass.Length;


                Random r = new Random();



                int tempFor1 = ln;
                for (ln1 = 0; ln1 < tempFor1; ln1++)
                {
                    v1 = Convert.ToInt32(r.Next(1, 9));
                    v2 = Convert.ToInt32(r.Next(1, 9));
                    v3 = Convert.ToInt32(r.Next(1, 2));

                    s2 = s2 + System.Convert.ToString(Convert.ToChar(IniVal + v1)) + System.Convert.ToString(Convert.ToChar(IniVal + v2)) + System.Convert.ToString(Convert.ToChar(IniVal + v3));
                    if (v3 == 1)
                    {
                        t1 = v1 + v2;
                    }
                    else
                    {
                        t1 = System.Math.Abs(v2 - v1);
                    }

                    int tempFor2 = t1;
                    for (t2 = 1; t2 <= tempFor2; t2++)
                    {
                        s2 = s2 + System.Convert.ToString(Convert.ToChar(Convert.ToInt32(r.Next(IniVal, ValRange))));
                    }

                    iii = (int)(Convert.ToChar((fpass.ToString().Substring(ln1, 1))));
                    s2 = s2 + System.Convert.ToString(Convert.ToChar(iii));
                }

                tempPMS_GeneratePassword = s2;
            }
            catch
            {
            }
            return tempPMS_GeneratePassword;
        }



        public bool PMS_FinalGenPassServer(string UsrPasswordFor, string GeneralAppPass2, ref string strRet)
        {
            bool blnRet = false;
            try
            {
                string TempPass1, TempPass2;

                int i, j;
                TempPass1 = UsrPasswordFor;
                j = TempPass1.ToString().Length;
                if (j < 10)
                {
                    TempPass1 = j.ToString() + TempPass1;
                }

                TempPass2 = PMS_GenPassServer(TempPass1, GeneralAppPass2);

                i = TempPass2.ToString().Length;

                int k = i * i;
                strRet = i.ToString().Substring(0, 1) + TempPass2 + k.ToString().Substring(k.ToString().Length - 1, 1);
                blnRet = true;
            }
            catch (Exception ex)
            {
                blnRet = false;
            }
            return blnRet;
        }

        public string GetPMS_FinalGenPassServer(string UsrPasswordFor, string GeneralAppPass2, ref string strRet)
        {
            try
            {
                string TempPass1, TempPass2;

                int i, j;
                TempPass1 = UsrPasswordFor;
                j = TempPass1.ToString().Length;
                if (j < 10)
                {
                    TempPass1 = j.ToString() + TempPass1;
                }

                TempPass2 = PMS_GenPassServer(TempPass1, GeneralAppPass2);

                i = TempPass2.ToString().Length;

                int k = i * i;
                strRet = i.ToString().Substring(0, 1) + TempPass2 + k.ToString().Substring(k.ToString().Length - 1, 1);
            }
            catch (Exception ex)
            {
                strRet = "";
            }
            return strRet;
        }


        public string PMS_GenPassServer(string fpass, string AppPass)
        {
            string tempPMS_GenPassServer = null;
            try
            {
                int ii = 0;
                int v1 = 0;
                int i = 0;
                int iii = 0;
                string s2 = null;
                string s1 = null;

                if (AppPass.Equals(PassCmpStr2))
                {
                    tempPMS_GenPassServer = "";

                    s2 = "";
                    s1 = "Zo" + fpass.ToString() + "kA";

                    ii = s1.Length;

                    int tempFor1 = ii;
                    for (i = 1; i <= tempFor1; i++)
                    {
                        iii = System.Convert.ToInt32(s1[i - 1]);
                        iii = (((iii % 2) == 0) ? iii + 1 : iii - 1);
                        if ((iii < 32) | (iii == 34) | (iii == 39) | (iii == 59))
                        {
                            iii = 42;
                        }
                        if (iii > 126)
                        {
                            iii = 126;
                        }
                        s2 = s2 + System.Convert.ToString((char)(iii));
                    }

                    s1 = s2;
                    if ((s1.Length % 2) == 0)
                    {
                        s1 = s1 + "M";
                    }
                    v1 = ((s1.Length + 1) / 2);
                    s2 = s1.Substring(s1.Length - v1) + s1.Substring(0, v1);
                    tempPMS_GenPassServer = s2;
                }
            }

            catch
            {
                tempPMS_GenPassServer = "";
            }
            return tempPMS_GenPassServer;
        }
    } // End of Class
}
