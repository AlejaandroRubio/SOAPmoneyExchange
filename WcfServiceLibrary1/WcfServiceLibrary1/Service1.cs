using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceLibrary1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        #region TazaDeCambio
        private const decimal TazaDeCambioUSD_EUR = 1.10m;
        private const decimal TazaDeCambioEUR_JPY = 163m;
        private const decimal TazaDeCambioUSD_JPY = 149m;
        #endregion

        #region CambioDeMonedaRate
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
        #endregion

        #region CambioDeMoneda
        public decimal CambioDeMoneda(string MonedaOrigen, string MonedaDestino, decimal Monto)
        {
            decimal MontoDeTazaDeCambio = CambioDeMonedaRate(MonedaOrigen, MonedaDestino);

            if (MonedaOrigen == "EUR" && MonedaDestino == "USD")
            {
                return Math.Round(Monto * MontoDeTazaDeCambio,2);
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
                return Math.Round(Monto * MontoDeTazaDeCambio, 2);
            }
            else if (MonedaOrigen == "USD" && MonedaDestino == "JPY")
            {
                return Math.Round(Monto * MontoDeTazaDeCambio, 2);
            }
            else if (MonedaOrigen == "JPY" && MonedaDestino == "USD")
            {
                return Math.Round(Monto / MontoDeTazaDeCambio, 2);
            }
            else { return 0; }
        }
        #endregion

        #region CambioDeMonedaExchagePetition
        public ExchagePetition CambioDeMonedaExchagePetition(ExchagePetition petition)
        {
            decimal MontoDeTazaDeCambio = CambioDeMonedaRate(petition.MonedaOrigen, petition.MonedaDestino);

            if (petition.MonedaOrigen == "EUR" && petition.MonedaDestino == "USD")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado = Math.Round(monto * MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen,petition.MonedaDestino, resultado);

            }
            else if (petition.MonedaOrigen == "USD" && petition.MonedaDestino == "EUR")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado= Math.Round(monto / MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen, petition.MonedaDestino, resultado);
            }
            else if (petition.MonedaOrigen == "JPY" && petition.MonedaDestino == "EUR")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado = Math.Round(monto / MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen, petition.MonedaDestino, resultado);
            }
            else if (petition.MonedaOrigen == "EUR" && petition.MonedaDestino == "JPY")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado = Math.Round(monto * MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen, petition.MonedaDestino, resultado);

            }
            else if (petition.MonedaOrigen == "USD" && petition.MonedaDestino == "JPY")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado = Math.Round(monto * MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen, petition.MonedaDestino, resultado);
            }
            else if (petition.MonedaOrigen == "JPY" && petition.MonedaDestino == "USD")
            {
                decimal monto = Convert.ToDecimal(petition.Monto);
                decimal resultado = Math.Round(monto / MontoDeTazaDeCambio, 2);
                return resultOfOperation(petition.MonedaOrigen, petition.MonedaDestino, resultado);
            }
            else { return null; }
        }
        #endregion

        #region resultOfOperation
        public ExchagePetition resultOfOperation(string monedaOrigen, string monedaDestino, decimal monto)
        {

            ExchagePetition result = new ExchagePetition
            {
                MonedaOrigen = monedaOrigen,
                MonedaDestino = monedaDestino,
                Monto = monto
            };

            return result;

        }
        #endregion

    }
}
