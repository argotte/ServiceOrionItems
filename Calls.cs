using ServiceOrion.Clientes;
using ServiceOrion.Item;
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
        public Calls(int numero, string id) 
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (numero == 1) 
            {
                QueryMaterialInClient material = new QueryMaterialInClient();
                material.ClientCredentials.UserName.UserName= ConfigurationManager.AppSettings["UserTenant"];
                material.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
                Item1 material1 = new Item1();
                answer = material1.GetClient(id, material);
                MessageBox.Show(answer);
            }
            if (numero == 2)
            {
                QuerySupplierInClient proveedor = new QuerySupplierInClient();
                proveedor.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
                proveedor.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
                Proveedor2 provider = new Proveedor2();
                answer = provider.GetClient(id, proveedor);
                MessageBox.Show(answer);
            }
            if (numero == 3)
            {
                QueryCustomerInClient client = new QueryCustomerInClient();
                client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserTenant"];
                client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PasswordTenant"];
                Cliente3 cliente = new Cliente3();
                answer = cliente.GetClient(id,client);
                MessageBox.Show(answer);
            }


        }
        

    }
}
