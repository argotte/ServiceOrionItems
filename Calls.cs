using ServiceOrion.Clientes;
using ServiceOrion.Item;
using ServiceOrion.Models;
using ServiceOrion.Proveedores;
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
        string answer;
        string id;
        int numero;
        public Calls(int _numero, string _id)
        {
            numero = _numero;
            id = _id;
        }

        public MaterialModel ObtenerMaterial()
        {
           QueryMaterialInClient material = new QueryMaterialInClient();
           material.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
           material.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
           Item1 material1 = new Item1();
           Response response = material1.GetClient(id, material);
            MaterialModel materialModel = new MaterialModel
            {
                Name = ((MaterialModel)response.Result).Name
            };
            return materialModel;
        }

        public ClienteModel ObtenerRespuesta()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            QueryCustomerInClient client = new QueryCustomerInClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
            Cliente3 cliente = new Cliente3();
            Response response = cliente.GetClient(id, client);
            ClienteModel clienteModel = new ClienteModel
            {
                Name = ((ClienteModel)response.Result).Name
            };
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


    }
}
