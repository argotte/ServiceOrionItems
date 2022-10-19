using ServiceOrion.ManageSalesPriceListIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion.Selections
{
    class ListaPrecios4
    {
        public ListaPrecios4()  {}

        public List<Response> GetClient(string id,ManageSalesPriceListInClient listaprecio) 
        {
            List<Response> listaresponse = new List<Response>();
            SalesPriceListFindByIDElements[] request = new SalesPriceListFindByIDElements[1];
            request[0] = new SalesPriceListFindByIDElements();
            request[0].ID = new SalesPriceListID();
            //  SalesPriceListFindByIDResponseElements request = new SalesPriceListFindByIDResponseElements();

            try
            {
                request[0].ID.Value = id;
                var respuesta = listaprecio.Read(request);
                foreach (var item in respuesta.SalesPriceListFindByIDResponseMessage1)
                {
                    listaresponse.Add(new Response
                    {
                        IsSuccess = true,
                        Result = new ListaPreciosModel
                        {
                            Name = item.ID.Value
                        }
                    });
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
