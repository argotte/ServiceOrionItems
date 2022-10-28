using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion.Models
{
    public class MaterialModel
    {
        public string InventoryValuationMeasureUnitCode { get; set; }
        public string InternalID { get; set; }
        public string Description { get; set; }
        public string ProductCategoryID { get; set; }
        public string IdentifiedStockTypeCode { get; set; }
    }//leer
    //Aun no se qué caracteristicas deberia llevar cada modelo asi que les estoy dejando Name y ya por ahora
}
