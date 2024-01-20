using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

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

        public ExchagePetition petition = new ExchagePetition();

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            decimal returnExchange;
            ExchagePetition returnExchange2;



            string MonedaOrigen = DropDownBoxOrigen.Text;
            string MonedaDestino = DropDownBoxDestino.Text;
            decimal MontoLocal = Convert.ToDecimal(textBox1.Text);

            returnExchange = client.CambioDeMoneda(MonedaOrigen, MonedaDestino, MontoLocal);
            MessageBox.Show("El monto a cambiar es " + textBox1.Text + " " + MonedaOrigen + " a " + MonedaDestino + " es: " + returnExchange + "");
            
            petition.MonedaOrigen= MonedaOrigen;
            petition.MonedaDestino= MonedaDestino;
            petition.Monto = MontoLocal;

            returnExchange2 = client.CambioDeMonedaExchagePetition(petition);
            MessageBox.Show("El monto a cambiar es " + textBox1.Text + " " + returnExchange2.MonedaOrigen + " a " + returnExchange2.MonedaDestino + " es: " + returnExchange2.Monto + "");

            
        }

    
    }
}
