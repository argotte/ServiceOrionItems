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
        public string GetClient(string id, QueryCustomerInClient client)
        {//
             CustomerByElementsQueryMessage_sync request1 = new CustomerByElementsQueryMessage_sync();
             string rspst = "";
            //  string rspst1 = "";
            string asdasdasd;
             string rspst2 = "";
             try
             {
                request1.CustomerSelectionByElements = new CustomerSelectionByElements();
                request1.CustomerSelectionByElements.SelectionByInternalID = new CustomerSelectionByInternalID[1];
                request1.CustomerSelectionByElements.SelectionByInternalID[0] = new CustomerSelectionByInternalID();
                request1.CustomerSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request1.CustomerSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = id; 
                var response = client.FindByElements(request1);
                rspst = response.Customer[0].AddressInformation[0].Address.FormattedAddress.FormattedAddress.FirstLineDescription;//212 Lunch
                return rspst;
             }
             catch (Exception ex)
             {
                return rspst = ex.Message;
             }
        }

        public string GetAllClient() { return "no"; }
    }
}

