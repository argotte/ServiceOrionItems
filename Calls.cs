using ServiceOrion.Clientes;
using ServiceOrion.Item;
using ServiceOrion.ManageSalesPriceListIn;
using ServiceOrion.Models;
using ServiceOrion.Proveedores;
using ServiceOrion.QueryCustomerInvoice;
using ServiceOrion.QueryExchangeRate;
using ServiceOrion.Selections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceOrion
{
    public class Calls
    {
        string id;
        string aux1, aux2;
        public Calls(string _id) //Constructor que lleva de parametro un id. Este se invoca cuando quieras uno en especifico por su id.
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            id = _id;
        }
        public Calls()//Constructor sin parametro. Este se invoca cuando quieras traer una lista de todos
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public Calls(string _aux1, string _aux2) 
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            aux1 = _aux1;
            aux2 = _aux2;
        }
        public MaterialModel ObtenerMaterial() //por id
        {
            QueryMaterialInClient material = new QueryMaterialInClient();
            material.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            material.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Item1 material1 = new Item1();
            Response response = material1.GetClient(id, material);
            MaterialModel materialModel = new MaterialModel
            {//Name = "RESMAS DE HOJAS BLANCAS"
                InventoryValuationMeasureUnitCode = ((MaterialModel)response.Result).InventoryValuationMeasureUnitCode,
                InternalID = ((MaterialModel)response.Result).InternalID,
                Description = ((MaterialModel)response.Result).Description,
                ProductCategoryID = ((MaterialModel)response.Result).ProductCategoryID,
                IdentifiedStockTypeCode = ((MaterialModel)response.Result).IdentifiedStockTypeCode,
            };
            return materialModel;
        }
        public List<MaterialModel> ObtenerListaMaterial() //Lista de todos
        {
            QueryMaterialInClient material = new QueryMaterialInClient();
            material.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            material.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Item1 material1 = new Item1();
            List<Response> response = material1.GetClient(material);
            List<MaterialModel> materialModels = new List<MaterialModel>();
            foreach (var item in response)
            {
                materialModels.Add(new MaterialModel
                {
                    InventoryValuationMeasureUnitCode = ((MaterialModel)item.Result).InventoryValuationMeasureUnitCode,
                    InternalID = ((MaterialModel)item.Result).InternalID,
                    Description = ((MaterialModel)item.Result).Description,
                    ProductCategoryID = ((MaterialModel)item.Result).ProductCategoryID,
                    IdentifiedStockTypeCode = ((MaterialModel)item.Result).IdentifiedStockTypeCode,
                });
            }
            return materialModels;
        }

        public ClienteModel ObtenerCliente()
        {
            QueryCustomerInClient client = new QueryCustomerInClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Cliente3 cliente = new Cliente3();
            Response response = cliente.GetClient(id, client);
            ClienteModel clienteModel = new ClienteModel
            {
                FirstLineName = ((ClienteModel)response.Result).FirstLineName,
                SecondLineName=((ClienteModel)response.Result).SecondLineName,
                FormattedAddress=((ClienteModel)response.Result).FormattedAddress,
                CompanyID=((ClienteModel)response.Result).CompanyID,
                PartyTax=((ClienteModel)response.Result).PartyTax,
                EmailURI =((ClienteModel)response.Result).EmailURI,
                InternalID = ((ClienteModel)response.Result).InternalID,
                CityName= ((ClienteModel)response.Result).CityName,
                StreetPostalCode = ((ClienteModel)response.Result).StreetPostalCode,
                CountryCode= ((ClienteModel)response.Result).CountryCode,
                StreetName = ((ClienteModel)response.Result).StreetName,
                HouseID = ((ClienteModel)response.Result).HouseID,
                strUUID = ((ClienteModel)response.Result).strUUID,
                Empleado = ((ClienteModel)response.Result).Empleado
            };
            return clienteModel;
        }

        public List<ClienteModel> ObtenerListaCliente()
        {
            QueryCustomerInClient client = new QueryCustomerInClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Cliente3 cliente = new Cliente3();
           
            List<Response> response = cliente.GetClient(client);
            
            //al salir lastId tendra el valor del ultimo ID, entonces al volver a hacer el llamado seguira buscando desde el
            //ultimo adquirido!!
            List<ClienteModel> clienteModel = new List<ClienteModel>();//((ServiceOrion.ClienteModel)(new System.Collections.Generic.Mscorlib_CollectionDebugView<ServiceOrion.Response>(response).Items[0]).Result).Name
            foreach (var item in response)
            {
                clienteModel.Add(new ClienteModel
                {
                    FirstLineName = ((ClienteModel)item.Result).FirstLineName,
                    SecondLineName = ((ClienteModel)item.Result).SecondLineName,
                    FormattedAddress = ((ClienteModel)item.Result).FormattedAddress,
                    CompanyID = ((ClienteModel)item.Result).CompanyID,
                    PartyTax = ((ClienteModel)item.Result).PartyTax,
                    EmailURI = ((ClienteModel)item.Result).EmailURI,
                    InternalID = ((ClienteModel)item.Result).InternalID,
                    CityName = ((ClienteModel)item.Result).CityName,
                    StreetPostalCode = ((ClienteModel)item.Result).StreetPostalCode,
                    CountryCode = ((ClienteModel)item.Result).CountryCode,
                    StreetName = ((ClienteModel)item.Result).StreetName,
                    HouseID = ((ClienteModel)item.Result).HouseID,
                    strUUID = ((ClienteModel)item.Result).strUUID,
                    Empleado = ((ClienteModel)item.Result).Empleado
                });
            }
            return clienteModel;

        }

        public ProveedorModel ObtenerProveedor()
        {
            QuerySupplierInClient proveedor = new QuerySupplierInClient();
            proveedor.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            proveedor.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Proveedor2 provider = new Proveedor2();
            Response response = provider.GetClient(id, proveedor);
            ProveedorModel proveedorModel = new ProveedorModel
            {
                Name = ((ProveedorModel)response.Result).Name
            };
            return proveedorModel;
        }

        public List<ProveedorModel> ObtenerListaProveedor()
        {
            QuerySupplierInClient proveedor = new QuerySupplierInClient();
            proveedor.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            proveedor.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Proveedor2 provider = new Proveedor2();
            List<Response> response = provider.GetClient(proveedor);

            List<ProveedorModel> proveedorModels = new List<ProveedorModel>();//((ServiceOrion.ClienteModel)(new System.Collections.Generic.Mscorlib_CollectionDebugView<ServiceOrion.Response>(response).Items[0]).Result).Name
            foreach (var item in response)
            {
                proveedorModels.Add(new ProveedorModel
                {
                    Name = ((ProveedorModel)item.Result).Name
                });
            }
            return proveedorModels;

        }

        public List<ListaPreciosModel> ObtenerListaPrecios()
        {//XOLOPASS CLAUSURA 2018
            ManageSalesPriceListInClient listaprecio = new ManageSalesPriceListInClient();
            listaprecio.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            listaprecio.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            ListaPrecios4 pricelist = new ListaPrecios4();
            List<Response> response = pricelist.GetClient(id, listaprecio);
            List<ListaPreciosModel> listaPreciosModels = new List<ListaPreciosModel>();
            foreach (var item in response)
            {
                listaPreciosModels.Add(new ListaPreciosModel
                {
                    Name = ((ListaPreciosModel)item.Result).Name,
                    TypeCode=((ListaPreciosModel)item.Result).TypeCode,
                    CurrencyCode=((ListaPreciosModel)item.Result).CurrencyCode
                });
            }
            return listaPreciosModels;
        }
        public QueryCustomerInvoiceModel ObtenerQueryCustomerInvoice() 
        {
            QueryCustomerInvoiceInClient querycustomer = new QueryCustomerInvoiceInClient();
            querycustomer.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            querycustomer.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            QCustomerInvoice qCustomer = new QCustomerInvoice();
            Response response = qCustomer.GetClient(id, querycustomer);
            QueryCustomerInvoiceModel queryCustomerInvoiceModel = new QueryCustomerInvoiceModel
            {
                Name = ((QueryCustomerInvoiceModel)response.Result).Name
            };
            return queryCustomerInvoiceModel;
        }

        public QueryExchangeRateModel ObtenerTasaCambio() 
        {
            QueryExchangeRateIn_V1Client queryExchange = new QueryExchangeRateIn_V1Client();
            queryExchange.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            queryExchange.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            QExchangeRate qExchange = new QExchangeRate();
            Response response = qExchange.GetClient(aux1, aux2, queryExchange);
            QueryExchangeRateModel queryExchangeRateModel = new QueryExchangeRateModel
            {
                Quantity = ((QueryExchangeRateModel)response.Result).Quantity

            }; return queryExchangeRateModel;


        }


    }
}
