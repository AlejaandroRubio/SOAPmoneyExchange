﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ExchagePetition CambioDeMonedaExchagePetition(ExchagePetition petition);

        [OperationContract]
        decimal CambioDeMoneda(string MonedaOrigen, string MonedaDestino, decimal Monto);

        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "WcfServiceLibrary1.ContractType".

    [DataContract]
    public class ExchagePetition
    {

         string monedaOrigen;
         string monedaDestino;
         decimal monto;

        [DataMember]
        public string MonedaOrigen {
            get {return monedaOrigen;}
            set { monedaOrigen = value;}
        }
        [DataMember]
        public string MonedaDestino {
            get { return monedaDestino; }
            set { monedaDestino = value; }
        }
        [DataMember]
        public decimal Monto {
            get { return monto; }
            set { monto = value; }
        }

    }
}
