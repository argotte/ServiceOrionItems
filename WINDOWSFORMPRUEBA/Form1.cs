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
        public Form1()
        {
            InitializeComponent();
        }

        string id;

        private void button1_Click(object sender, EventArgs e)
        {
            // Este ID es para materiales.
            id = "5090001";
            Calls call = new Calls(id);
            var response = call.ObtenerMaterial().Name;
            MessageBox.Show(response);

            Calls call1 = new Calls();
            var response1 = call1.ObtenerListaMaterial();
            id = "aaaaaaaaaaaaaaaaaaa";
        }
    }
}
