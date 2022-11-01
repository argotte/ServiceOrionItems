using ServiceOrion.Clientes;
using ServiceOrion.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion
{
    public class Cliente3
    {
        public Cliente3(){ }
        public Response GetClient(string id, QueryCustomerInClient client)
        {//
             CustomerByElementsQueryMessage_sync request1 = new CustomerByElementsQueryMessage_sync();
             try
             {
                request1.CustomerSelectionByElements = new CustomerSelectionByElements();
                request1.CustomerSelectionByElements.SelectionByInternalID = new CustomerSelectionByInternalID[1];
                request1.CustomerSelectionByElements.SelectionByInternalID[0] = new CustomerSelectionByInternalID();
                request1.CustomerSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = id;
                var response = client.FindByElements(request1);
                var customer = response.Customer[0];//AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription;//212 Lunch
                return new Response
                {
                     
                    IsSuccess = true,
                    Result = new ClienteModel
                    {
                        FirstLineName = (customer.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription != null) ? customer.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription : null,
                        SecondLineName = (customer.Person != null) ? customer.Person.FamilyName : null,
                        FormattedAddress = (customer.PaymentData[0].CompanyID != null) ? customer.PaymentData[0].CompanyID : null,
                        CompanyID = (customer.PaymentData[0].CompanyID != null) ? customer.PaymentData[0].CompanyID : null,
                        PartyTax = (customer.TaxNumber[0].PartyTaxID != null) ? customer.TaxNumber[0].PartyTaxID.Value : null,
                        EmailURI = (customer.AddressInformation[0].Address.EmailURI != null) ? customer.AddressInformation[0].Address.EmailURI.Value : null,
                        InternalID = customer.InternalID,
                        CityName = (customer.AddressInformation[0].Address.PostalAddress.CityName != null) ? customer.AddressInformation[0].Address.PostalAddress.CityName : null,
                        StreetPostalCode = (customer.AddressInformation[0].Address.PostalAddress.StreetPostalCode != null) ? customer.AddressInformation[0].Address.PostalAddress.StreetPostalCode : null,
                        CountryCode = (customer.AddressInformation[0].Address.PostalAddress.CountryCode != null) ? customer.AddressInformation[0].Address.PostalAddress.CountryCode : null,
                        StreetName = (customer.AddressInformation[0].Address.PostalAddress.StreetName != null) ? customer.AddressInformation[0].Address.PostalAddress.StreetName : null,
                        HouseID = (customer.AddressInformation[0].Address.PostalAddress.HouseID != null) ? customer.AddressInformation[0].Address.PostalAddress.HouseID : null,
                        strUUID = (customer.AddressInformation[0].UUID != null) ? customer.AddressInformation[0].UUID.Value : null,
                        Empleado = (customer.DirectResponsibility != null) ? customer.DirectResponsibility[0].EmployeeID.Value : null
                    }
                };
             }
             catch (Exception ex)
             {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
             }
        }

        public List<Response> GetClient(QueryCustomerInClient client) 
        {
            List<Response> listaresponse = new List<Response>();
            CustomerByElementsQueryMessage_sync request1 = new CustomerByElementsQueryMessage_sync();
            try
            {
                request1.CustomerSelectionByElements = new CustomerSelectionByElements();
                request1.CustomerSelectionByElements.SelectionByInternalID = new CustomerSelectionByInternalID[1];
                request1.CustomerSelectionByElements.SelectionByInternalID[0] = new CustomerSelectionByInternalID();
                request1.CustomerSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = "*";
                var response = client.FindByElements(request1); //Me devuelve la infinidad de Customer. Customer[0],[1],... etc etc etc
                foreach (var item in response.Customer)
                {
             
                    listaresponse.Add(new Response
                    {
                        IsSuccess = true,
                        Result = new ClienteModel
                        {
                         
                            FirstLineName = (item.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription != null) ? item.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription : null,
                            SecondLineName = (item.Person != null) ? item.Person.FamilyName : null,
                            FormattedAddress = (item.PaymentData[0] != null) ? item.PaymentData[0].CompanyID : null,
                            CompanyID = (item.PaymentData[0] != null) ? item.PaymentData[0].CompanyID : null,
                            PartyTax = (item.TaxNumber[0] != null) ? item.TaxNumber[0].PartyTaxID.Value : null,
                            EmailURI = (item.AddressInformation[0].Address.EmailURI != null) ? item.AddressInformation[0].Address.EmailURI.Value : null,
                            InternalID = item.InternalID,
                            CityName = (item.AddressInformation[0].Address.PostalAddress.CityName != null) ? item.AddressInformation[0].Address.PostalAddress.CityName : null,
                            StreetPostalCode = (item.AddressInformation[0].Address.PostalAddress.StreetPostalCode != null) ? item.AddressInformation[0].Address.PostalAddress.StreetPostalCode : null,
                            CountryCode = (item.AddressInformation[0].Address.PostalAddress.CountryCode != null) ? item.AddressInformation[0].Address.PostalAddress.CountryCode : null,
                            StreetName = (item.AddressInformation[0].Address.PostalAddress.StreetName != null) ? item.AddressInformation[0].Address.PostalAddress.StreetName : null,
                            HouseID = (item.AddressInformation[0].Address.PostalAddress.HouseID != null) ? item.AddressInformation[0].Address.PostalAddress.HouseID : null,
                            strUUID = (item.AddressInformation[0].UUID != null) ? item.AddressInformation[0].UUID.Value : null,
                            Empleado = (item.DirectResponsibility != null) ? item.DirectResponsibility[0].EmployeeID.Value : null
                        }
                    });; 
                }
                return listaresponse;
            }
            catch (Exception ex) 
            {
                listaresponse.Add(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
                return listaresponse;
            }
        }
    }
}

//if (response.Customer != null)
//{
//    foreach (SincrDatosDyD.QueryCustomersByD.CustomerReponseCustomer customer in response.Customer)
//    {

//        string FirstLineName = "";
//        string SecondLineName = "";
//        //string EmailURI = "";
//        string FormattedAddress = "";
//        string CompanyID = "";
//        string PartyTaxID = "";
//        if (customer.Person != null)   // cliente natural
//        {
//            FirstLineName = (customer.Person.GivenName + " " + customer.Person.FamilyName);
//        }
//        else
//        {
//            FirstLineName = customer.Organisation.FirstLineName + " " + customer.Organisation.SecondLineName;   // cliente corporativo
//        }

//        strName = FirstLineName;

//        if (customer.AddressInformation[0].Address != null)
//        {
//            EmailURI = customer.AddressInformation[0].Address.EmailURI.Value;
//        }
//        if (customer.PaymentData != null)
//        {
//            FormattedAddress = customer.PaymentData[0].CompanyID;
//            CompanyID = (customer.PaymentData[0].CompanyID);
//        }
//        if (customer.TaxNumber != null)
//        {
//            PartyTaxID = customer.TaxNumber[0].PartyTaxID.Value;
//        }

//        string InternalID = (customer.InternalID);

//        string CityName = customer.AddressInformation[0].Address.PostalAddress.CityName;
//        string StreetPostalCode = customer.AddressInformation[0].Address.PostalAddress.StreetPostalCode;
//        string CountryCode = customer.AddressInformation[0].Address.PostalAddress.CountryCode;
//        string StreetName = customer.AddressInformation[0].Address.PostalAddress.StreetName;
//        string HouseID = customer.AddressInformation[0].Address.PostalAddress.HouseID;

//        strUUID = customer.AddressInformation[0].UUID.Value;

//        if (customer.DirectResponsibility[0] != null)
//        {
//            Empleado = customer.DirectResponsibility[0].EmployeeID.Value;
//        }


//        return true; //dataList.Add(customer.InternalID + ", " + customer.Organisation.FirstLineName + "; ");
//    }
//}
//else
//{
//    return false;