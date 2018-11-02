using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.License
{

    enum Organization
    {

        ITechGentle
    }
    public class OrganizationInformation
    {
        private string _organizationName;
        private List<keyvaluepair<string, string>> _clientCompanies;
        private DateTime _licenseExpDate;
        private bool _isAccessentiresolution;

        public OrganizationInformation()
        {
            SetLicenseExpiryDate(Organization.ITechGentle);

        }

        private void SetLicenseExpiryDate(Organization currentOrganization)
        {
            _clientCompanies = new List<keyvaluepair<string, string>>();


            if (currentOrganization == Organization.ITechGentle)
            {
                _organizationName = "ITechGentle";
                _clientCompanies.Add(new keyvaluepair<string, string>("00010001", "ITechGentle"));
                _licenseExpDate = Convert.ToDateTime("31-Dec-2018");
                _isAccessentiresolution = true;

            }
        }
        public string GetOrganizationName()
        {
            return _organizationName;
        }
        public DateTime GetLicenseExpDate()
        {
            return _licenseExpDate;
        }
        public bool GetSolutionAccessLevel()
        {
            return _isAccessentiresolution;
        }


    }

    internal class keyvaluepair<T1, T2>
    {
        private string v1;
        private string v2;

        public keyvaluepair(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
