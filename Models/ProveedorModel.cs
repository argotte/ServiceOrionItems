using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion
{
    public class ProveedorModel
    {
        public string Name { get; set; }
//                                    if (customer.Person != null)   // cliente natural
//                            {
//                                FirstLineName = RevString(customer.Person.GivenName + " " + customer.Person.FamilyName);
//    }
//                            else
//                            {
//                                FirstLineName = customer.Organisation.FirstLineName;   // cliente corporativo
//                            }
//if (customer.AddressInformation != null)
//{
//    if (customer.AddressInformation[0].Address != null)
//    {
//        if (customer.AddressInformation[0].Address.EmailURI != null)
//        {
//            EmailURI = customer.AddressInformation[0].Address.EmailURI.Value;
//        }
//        if (customer.AddressInformation[0].Address.PostalAddress != null)
//        {
//            CityName = customer.AddressInformation[0].Address.PostalAddress.CityName;

//            StreetPostalCode = customer.AddressInformation[0].Address.PostalAddress.StreetPostalCode;
//            CountryCode = customer.AddressInformation[0].Address.PostalAddress.CountryCode;
//            CountyName = customer.AddressInformation[0].Address.PostalAddress.CountyName;

//            StreetName = customer.AddressInformation[0].Address.PostalAddress.StreetName;
//            HouseID = customer.AddressInformation[0].Address.PostalAddress.HouseID;
//            RegionCode = customer.AddressInformation[0].Address.PostalAddress.RegionCode.Value;

//        }
//        if (customer.AddressInformation[0].Address.Telephone != null)
//        {
//            Telephone = customer.AddressInformation[0].Address.Telephone[0].FormattedNumberDescription;
//        }

//        //------------------------------------------------------------------------------------------//
//        //              Verifica si el cliente esta asignado a la organizacion de ventas            //
//        //------------------------------------------------------------------------------------------//
//        if (customer.SalesArrangement != null)
//        {
//            string Bien = "NO";
//            int Count = customer.SalesArrangement.Count();
//            for (int f = 0; f < Count; f++)
//            {
//                string SalesOrganisationID = customer.SalesArrangement[f].SalesOrganisationID;
//                if (strSaleOrganization == SalesOrganisationID)
//                {
//                    Bien = "SI";
//                    break;
//                }

            }//leer
             //Aun no se qué caracteristicas deberia llevar cada modelo asi que les estoy dejando Name y ya por ahora
        }
