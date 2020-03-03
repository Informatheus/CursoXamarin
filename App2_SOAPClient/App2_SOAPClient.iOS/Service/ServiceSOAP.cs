﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly:Xamarin.Forms.Dependency(typeof(App2_SOAPClient.iOS.Service.ServiceSOAP))]
namespace App2_SOAPClient.iOS.Service {
    class ServiceSOAP : IServiceSOAP {
        public string Somar(int num1, int num2) {

            var serv = new com.dneonline.www.Calculator();

            return "Resultado WS SOAP:" + serv.Add(num1, num2).ToString();
        }
    }
}