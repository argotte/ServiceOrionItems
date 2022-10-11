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
        public string GetClient(string id, QuerySupplierInClient proveedor)
        {
     
            SupplierByElementsQueryMessage_sync request = new SupplierByElementsQueryMessage_sync();
            string rspst = "";
            string rspst1 = "";
            string rspst2 = "";
            try
            {
                request.SupplierSelectionByElements = new SupplierByElementsQuerySelectionByElements();
                request.SupplierSelectionByElements.SelectionByInternalID = new SelectionByIdentifier[1];
                request.SupplierSelectionByElements.SelectionByInternalID[0] = new SelectionByIdentifier();
                request.SupplierSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request.SupplierSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request.SupplierSelectionByElements.SelectionByInternalID[0].LowerBoundaryIdentifier = id;
                string asdasdasdsaddddd;
                asdasdasdsaddddd = "1";
                var response = proveedor.FindByElements(request);
              //  rspst = response.Supplier[0].FirstLineName;
                return rspst;
            }
            catch (Exception ex)
            {

                return rspst = ex.Message;
            }


        }
    }
}
