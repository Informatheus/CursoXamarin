﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(App2_SOAPClient.UWP.Service.ServiceSOAP))]
namespace App2_SOAPClient.UWP.Service {
    class ServiceSOAP : IServiceSOAP {
        public string Somar(int num1, int num2) {

            var serv = new ServicoWS.CalculatorSoapClient();

            return "Resultado WS SOAP:" + serv.AddAsync(num1, num2).GetAwaiter().GetResult().ToString();
        }
    }
}
