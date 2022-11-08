using ServiceOrion.Item;
using ServiceOrion.Models;
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
                    Result = new MaterialModel
                    {
                        InventoryValuationMeasureUnitCode = customer.InventoryValuationMeasureUnitCode,
                        InternalID = customer.InternalID.Value,
                        Description = (customer.Description[0].Description.Value != null) ? customer.Description[0].Description.Value : null,
                        ProductCategoryID = customer.ProductCategoryID,
                        IdentifiedStockTypeCode = (customer.IdentifiedStockTypeCode != null) ? customer.IdentifiedStockTypeCode.Value : null
                     //   SiteID = (customer.Logistics
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
        public List<Response> GetClient(QueryMaterialInClient material)
        {
            string LastID="";
            List<MaterialByElementsResponseMaterial_sync> lista = new List<MaterialByElementsResponseMaterial_sync>();
            List<Response> listaresponse = new List<Response>();
            MaterialByElementsQueryMessage_sync request = new MaterialByElementsQueryMessage_sync();
            try
            {
                request.MaterialSelectionByElements = new MaterialByElementsQuerySelectionByElements();
                request.MaterialSelectionByElements.SelectionByInternalID = new MaterialByElementsQuerySelectionByInternalID[1];
                request.MaterialSelectionByElements.SelectionByInternalID[0] = new MaterialByElementsQuerySelectionByInternalID();
                request.MaterialSelectionByElements.SelectionByInternalID[0].InclusionExclusionCode = "I";
                request.MaterialSelectionByElements.SelectionByInternalID[0].IntervalBoundaryTypeCode = "1";
                request.MaterialSelectionByElements.SelectionByInternalID[0].LowerBoundaryInternalID = new ProductInternalID { Value = "*" };
                request.ProcessingConditions = new Item.QueryProcessingConditions();
                request.ProcessingConditions.LastReturnedObjectID = new Item.ObjectID();
                request.ProcessingConditions.LastReturnedObjectID.Value = LastID;

                var response = material.FindByElements(request); //Me devuelve la infinidad de Customer. Customer[0],[1],... etc etc etc
                do
                {
                    request.ProcessingConditions.LastReturnedObjectID.Value = LastID;
                    response = material.FindByElements(request);
                    if (response.Material != null)
                    {
                        foreach (var item in response.Material)
                        {
                            lista.Add(item);
                        }
                        LastID = response.ProcessingConditions.LastReturnedObjectID.Value;
                    }

                } while (response.Material != null);
                foreach (var item in lista)
                {
                    bool primero, segundo, tercero, cuarto, quinto,sexto;
                    primero = segundo = tercero = cuarto = quinto= sexto = false;
                    if (item.InventoryValuationMeasureUnitCode != null)
                    {
                        primero = true;
                    }
                    if (item.InternalID != null)
                    {
                        if (item.InternalID.Value != null)
                        {
                            segundo = true;
                        }
                    }
                    if (item.Description != null)
                    {
                        if (item.Description[0].Description != null)
                        {
                            if (item.Description[0].Description.Value != null)
                            {
                                tercero = true;
                            }
                        }
                    }
                    if (item.ProductCategoryID != null)
                    {
                        cuarto = true;
                    }
                    if (item.IdentifiedStockTypeCode != null)
                    {
                        if (item.IdentifiedStockTypeCode.Value != null)
                        {
                            quinto = true;
                        }
                    }
                    if (item.Logistics !=null)
                    {
                        if (item.Logistics[0].SiteID != null)
                        {
                            if (item.Logistics[0].SiteID.Value != null)
                            {
                                if (item.Logistics[0].SiteID.Value == "SPOSA21")
                                {
                                    sexto = true;
                                }
                            }
                        }
                    }
                    if (sexto==true)
                    {
                        listaresponse.Add(new Response
                        {
                            IsSuccess = true,
                            Result = new MaterialModel
                            {
                                InventoryValuationMeasureUnitCode = (primero == true) ? item.InventoryValuationMeasureUnitCode : null,
                                InternalID = (segundo == true) ? item.InternalID.Value : null,
                                Description = (tercero == true) ? item.Description[0].Description.Value : null,
                                ProductCategoryID = (cuarto == true) ? item.ProductCategoryID : null,
                                IdentifiedStockTypeCode = (quinto == true) ? item.IdentifiedStockTypeCode.Value : null,
                                SiteID = (sexto == true) ? item.Logistics[0].SiteID.Value : null
                            }
                        });
                    }
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
