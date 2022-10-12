﻿using ServiceOrion.Item;
using ServiceOrion.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion
{
    public class Item1
    {
        public Item1() {  }
        public Response GetClient(string id, QueryMaterialInClient material)
        {
            MaterialByElementsQueryMessage_sync request = new MaterialByElementsQueryMessage_sync();
            try
            {
                request.MaterialSelectionByElements = new MaterialByElementsQuerySelectionByElements();
                request.MaterialSelectionByElements.SelectionByInternalID = new MaterialByElementsQuerySelectionByInternalID[1];
                request.MaterialSelectionByElements.SelectionByInternalID[0] = new MaterialByElementsQuerySelectionByInternalID();
                request.MaterialSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request.MaterialSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request.MaterialSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = new ProductInternalID { Value = id };
                var response = material.FindByElements(request);
                var customer = response.Material[0];
                return new Response
                {
                    IsSuccess = true,
                    Result = new ClienteModel
                    {
                        Name = customer.Description[0].Description.Value
                    }
                };
            }
            catch (Exception ex)
            {

                return new Response 
                { IsSuccess = false, 
                  Message = ex.Message 
                }; 
            }
        }
    }
}
