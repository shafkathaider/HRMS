using System.Configuration;

namespace PayRoll.Core.Model.Utility
{
    public class Utility
    {

        public static string AbsoluteUri = ConfigurationManager.AppSettings["AbsoluteUri"].ToString();

    }
}
