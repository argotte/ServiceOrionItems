using ServiceOrion.Models;
using ServiceOrion.QueryCustomerInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion.Selections
{
    public class QCustomerInvoice
    {  //FXT-2669
        public QCustomerInvoice() 
        { 
        
        }
        public Response GetClient(string id, QueryCustomerInvoiceInClient querycustomer) 
        {
            CustomerInvoiceByElementsQueryMessage_sync request = new CustomerInvoiceByElementsQueryMessage_sync();
            try { 
            request.CustomerInvoiceSelectionByElements = new CustomerInvoiceByElementsQuerySelectionByElements();

            request.CustomerInvoiceSelectionByElements.SelectionByID = new SelectionByIdentifier[1];

            request.CustomerInvoiceSelectionByElements.SelectionByID[0] = new SelectionByIdentifier();
            request.CustomerInvoiceSelectionByElements.SelectionByID[0].InclusionExclusionCode = "I";
            request.CustomerInvoiceSelectionByElements.SelectionByID[0].IntervalBoundaryTypeCode = "1";
            //Vaidacion de contenido comentada
            request.CustomerInvoiceSelectionByElements.SelectionByID[0].LowerBoundaryIdentifier = id;
            var response = querycustomer.FindByElements(request);
            var customer = response.CustomerInvoice[0].BuyerParty.Address.FirstLineName;
                return new Response
                {
                    IsSuccess = true,
                    Result = new QueryCustomerInvoiceModel
                    {
                        Name = customer
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
        //
    }
}
