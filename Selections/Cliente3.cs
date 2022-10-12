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
                        Name= customer.AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription
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

        public string GetAllClient() 
        { return "aun no"; }
    }
}

