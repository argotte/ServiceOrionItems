using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion
{
    public class ClienteModel
    {
        public string FirstLineName { get; set; }
        public string SecondLineName { get; set; }
        public string FormattedAddress { get; set; }
        public string CompanyID { get; set; }
        public string PartyTax { get; set; }
        public string EmailURI { get; set; }

        public string InternalID { get; set; }
        public string CityName { get; set; }
        public string StreetPostalCode { get; set; }
        public string CountryCode { get; set; }
        public string StreetName { get; set; }
        public string HouseID { get; set; }

        public string strUUID { get; set; }
        public string Empleado { get; set; }
    }
}
//        strUUID = customer.AddressInformation[0].UUID.Value;

//        if (customer.DirectResponsibility[0] != null)
//        {
//            Empleado = customer.DirectResponsibility[0].EmployeeID.Value;
//        }