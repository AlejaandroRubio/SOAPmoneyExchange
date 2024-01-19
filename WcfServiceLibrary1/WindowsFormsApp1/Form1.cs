using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum Monedas
        {
            USD,
            EUR,
            JPY,
        }


        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            ServiceReference2.Service1Client client = new
                ServiceReference2.Service1Client();
            decimal returnExchange;


            string MonedaOrigen = DropDownBoxOrigen.Text;
           string MonedaDestino = DropDownBoxDestino.Text;

            returnExchange = client.CambioDeMoneda(MonedaOrigen, MonedaDestino, Convert.ToInt32(textBox1.Text));

            MessageBox.Show("El monto a cambiar es "+textBox1.Text+" "+ MonedaOrigen+" a "+ MonedaDestino +" es: "+ returnExchange + "");
            

        }
    }
}
