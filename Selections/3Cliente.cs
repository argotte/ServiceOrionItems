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
            string LastID = "";
            List<Response> listaresponse = new List<Response>();
            List<CustomerReponseCustomer> lista = new List<CustomerReponseCustomer>();
            CustomerByElementsQueryMessage_sync request1 = new CustomerByElementsQueryMessage_sync();
            try
            {
                    request1.CustomerSelectionByElements = new CustomerSelectionByElements();
                    request1.CustomerSelectionByElements.SelectionByInternalID = new CustomerSelectionByInternalID[1];
                    request1.CustomerSelectionByElements.SelectionByInternalID[0] = new CustomerSelectionByInternalID();
                    request1.CustomerSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                    request1.CustomerSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                    request1.CustomerSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = "*";

                    request1.ProcessingConditions = new Clientes.QueryProcessingConditions();
                    request1.ProcessingConditions.LastReturnedObjectID = new Clientes.ObjectID();
                    request1.ProcessingConditions.LastReturnedObjectID.Value = LastID;
                    var response = client.FindByElements(request1); //Me devuelve la infinidad de Customer. Customer[0],[1],... etc etc etc
                do
                {
                    request1.ProcessingConditions.LastReturnedObjectID.Value = LastID;
                    response = client.FindByElements(request1);
                    if (response.Customer != null) 
                    {
                        foreach (var item in response.Customer)
                        {
                            lista.Add(item);
                        }
                        LastID = response.ProcessingConditions.LastReturnedObjectID.Value;
                    }
                } while (response.Customer != null);





                foreach (var item in lista)
                {
                    bool primero, segundo, segundo1, tercero, cuarto, quinto, sexto, septimo, octavo, noveno, decimo, decimoprimero, decimosegundo, decimotercero, decimocuarto;
                    primero = segundo = segundo1 = tercero = cuarto = quinto = sexto = septimo = octavo = noveno = decimo = decimoprimero = decimosegundo = decimotercero = decimocuarto = false;
                    if (item.AddressInformation != null) 
                    { 
                        if(item.AddressInformation[0].Address != null) 
                        {
                            if(item.AddressInformation[0].Address.FormattedAddress != null)
                            {
                                if (item.AddressInformation[0].Address.FormattedAddress.FormattedAddress != null)
                                {
                                    if (item.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription != null)
                                    {
                                        primero = true;
                                    }
                                }

                                if (item.AddressInformation[0].Address.FormattedAddress.FormattedAddressDescription != null)
                                {
                                    tercero = true;
                                }
                            }

                            if (item.AddressInformation[0].Address.EmailURI != null)
                            {
                                if (item.AddressInformation[0].Address.EmailURI.Value != null)
                                {
                                    sexto = true;
                                }
                            }


                            if (item.AddressInformation[0].Address.PostalAddress != null)
                            {
                                if (item.AddressInformation[0].Address.PostalAddress.CityName != null)
                                {
                                    octavo = true;
                                }

                                if (item.AddressInformation[0].Address.PostalAddress.StreetPostalCode != null)
                                {
                                    noveno = true;
                                }

                                if (item.AddressInformation[0].Address.PostalAddress.CountryCode != null)
                                {
                                    decimo = true;
                                }

                                if (item.AddressInformation[0].Address.PostalAddress.StreetName != null)
                                {
                                    decimoprimero = true;
                                }

                                if (item.AddressInformation[0].Address.PostalAddress.HouseID != null)
                                {
                                    decimosegundo = true;
                                }
                            }
                        }

                        if (item.AddressInformation[0].UUID != null)
                        {
                            if (item.AddressInformation[0].UUID.Value != null)
                            {
                                decimotercero = true;
                            }     
                        }
                    }

                    if (item.Person != null)
                    {
                        if (item.Person.FamilyName != null)
                        {
                            segundo = true;
                        }
                        if (item.Person.GivenName != null)
                        {
                            segundo1 = true;
                        }
                        if (segundo == true && segundo1 == false)
                        {
                            segundo = false;
                        }
                    }
                    if (item.PaymentData != null)
                    {
                        if (item.PaymentData[0].CompanyID !=null)
                        {
                            cuarto = true;
                        }

                    }
                    if (item.TaxNumber !=null)
                    {
                        if (item.TaxNumber[0].PartyTaxID != null) 
                        {
                            if (item.TaxNumber[0].PartyTaxID.Value != null)
                            {
                                quinto = true;
                            }
                        }
                    }
                    if (item.InternalID !=null)
                    {
                        septimo = true;
                    }

                    if (item.DirectResponsibility != null)
                    {
                        if (item.DirectResponsibility[0].EmployeeID != null)
                        {
                            if (item.DirectResponsibility[0].EmployeeID.Value != null)
                            {
                                decimocuarto = true;
                            }
                        }
                    }


                    listaresponse.Add(new Response
                    {
                        IsSuccess = true,
                        Result = new ClienteModel
                        {
                         
                            FirstLineName = (primero == true) ? item.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription : null,
                            SecondLineName = (segundo == true) ? item.Person.GivenName+" "+item.Person.FamilyName : null,
                            FormattedAddress = (tercero == true) ? item.AddressInformation[0].Address.FormattedAddress.FormattedAddressDescription : null,
                            CompanyID = (cuarto == true) ? item.PaymentData[0].CompanyID : null,
                            PartyTax = (quinto == true) ? item.TaxNumber[0].PartyTaxID.Value : null,
                            EmailURI = (sexto == true) ? item.AddressInformation[0].Address.EmailURI.Value : null,
                            InternalID = (septimo == true)?item.InternalID:null,
                            CityName = (octavo == true) ? item.AddressInformation[0].Address.PostalAddress.CityName : null,
                            StreetPostalCode = (noveno == true) ? item.AddressInformation[0].Address.PostalAddress.StreetPostalCode : null,
                            CountryCode = (decimo == true) ? item.AddressInformation[0].Address.PostalAddress.CountryCode : null,
                            StreetName = (decimoprimero == true) ? item.AddressInformation[0].Address.PostalAddress.StreetName : null,
                            HouseID = (decimosegundo == true) ? item.AddressInformation[0].Address.PostalAddress.HouseID : null,
                            strUUID = (decimotercero == true) ? item.AddressInformation[0].UUID.Value : null,
                            Empleado = (decimocuarto == true) ? item.DirectResponsibility[0].EmployeeID.Value : null
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

