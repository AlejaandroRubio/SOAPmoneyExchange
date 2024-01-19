using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        private const decimal TazaDeCambioUSD_EUR = 1.10m;
        private const decimal TazaDeCambioEUR_JPY = 163m;
        private const decimal TazaDeCambioUSD_JPY = 149m;

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public decimal CambioDeMonedaRate(string MonedaOrigen, string MonedaDestino)
        {

            if (MonedaOrigen == "USD" && MonedaDestino == "EUR") { return TazaDeCambioUSD_EUR; }
            else if (MonedaOrigen == "EUR" && MonedaDestino == "USD") { return TazaDeCambioUSD_EUR; }
            else if (MonedaOrigen == "EUR" && MonedaDestino == "JPY") { return TazaDeCambioEUR_JPY; }
            else if (MonedaOrigen == "JPY" && MonedaDestino == "EUR") { return TazaDeCambioEUR_JPY; }
            else if (MonedaOrigen == "USD" && MonedaDestino == "JPY") { return TazaDeCambioUSD_JPY; }
            else if (MonedaOrigen == "JPY" && MonedaDestino == "USD") { return TazaDeCambioUSD_JPY; }
            else { return 0; }

        }      
        
        public decimal CambioDeMoneda(string MonedaOrigen, string MonedaDestino, int Monto)
        {
            decimal MontoDeTazaDeCambio = CambioDeMonedaRate(MonedaOrigen, MonedaDestino);

            if (MonedaOrigen == "EUR" && MonedaDestino == "USD")
            {
                return Monto * MontoDeTazaDeCambio;
            }
            else if (MonedaOrigen == "USD" && MonedaDestino == "EUR")
            {
                return Math.Round(Monto / MontoDeTazaDeCambio, 2);
            }
            else if (MonedaOrigen == "JPY" && MonedaDestino == "EUR")
            {

                return Math.Round(Monto / MontoDeTazaDeCambio, 2);
            }
            else if (MonedaOrigen == "EUR" && MonedaDestino == "JPY")
            {
                return Monto * MontoDeTazaDeCambio;
            }
            else if (MonedaOrigen == "USD" && MonedaDestino == "JPY")
            {
                return Monto * MontoDeTazaDeCambio;
            }
            else if (MonedaOrigen == "JPY" && MonedaDestino == "USD")
            {
                return Math.Round(Monto / MontoDeTazaDeCambio, 2);
            }
            else { return 0; }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
