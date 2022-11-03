using ServiceOrion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINDOWSFORMPRUEBA
{
    public partial class Form1 : Form
    {
       public string LastID;
        public Form1()
        {
            InitializeComponent();
        }

        string id;

        private void button1_Click(object sender, EventArgs e)
        {
            // Este ID es para materiales.
            id = "5090001";
            //Calls call = new Calls(id);
            //var response = call.ObtenerMaterial();
            //MessageBox.Show(response.Description);

            Calls call1 = new Calls();
            var response1 = call1.ObtenerListaMaterial();
        }

        private void button2_Click(object sender, EventArgs e)
        {//cliente
            id = "1000452";
            Calls call = new Calls(id);
            var response = call.ObtenerProveedor().Name;
            MessageBox.Show(response);

            Calls call1 = new Calls();
            var response1 = call1.ObtenerListaProveedor();
        }

        private void button3_Click(object sender, EventArgs e)
        {//proveedor
            id = "1001885";
            Calls call = new Calls(id);
            var response = call.ObtenerCliente().FirstLineName;
         //   MessageBox.Show(response);

            Calls call1 = new Calls(ref LastID);
            var response1 = call1.ObtenerListaCliente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = "XOLOPASS CLAUSURA 2018";
            Calls call = new Calls(id);
            var response = call.ObtenerListaPrecios();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            id = "FXT-2669";
            Calls call = new Calls(id);
            var response = call.ObtenerQueryCustomerInvoice().Name;
            MessageBox.Show(response);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string aux1 = "USD";
            string aux2 = "MXN";
            Calls call = new Calls(aux1, aux2);
            var response = call.ObtenerTasaCambio().Quantity;
            MessageBox.Show(response.ToString());
        }
    }
}
