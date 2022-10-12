using ServiceOrion.Proveedores;
using ServiceOrion.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion
{
   public class Proveedor2
    {
        public Proveedor2()
        {
        }
        public Response GetClient(string id, QuerySupplierInClient proveedor)
        {
            SupplierByElementsQueryMessage_sync request = new SupplierByElementsQueryMessage_sync();
            try
            {
                request.SupplierSelectionByElements = new SupplierByElementsQuerySelectionByElements();
                request.SupplierSelectionByElements.SelectionByInternalID = new SelectionByIdentifier[1];
                request.SupplierSelectionByElements.SelectionByInternalID[0] = new SelectionByIdentifier();
                request.SupplierSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request.SupplierSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request.SupplierSelectionByElements.SelectionByInternalID[0].LowerBoundaryIdentifier = id;
                var response = proveedor.FindByElements(request);
                var customer = response.Supplier[0].FirstLineName;
                return new Response
                {
                    IsSuccess = true,
                    Result = new ProveedorModel
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

        
    }
}
