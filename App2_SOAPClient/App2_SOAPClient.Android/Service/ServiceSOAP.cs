using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(App2_SOAPClient.Droid.Service.ServiceSOAP))]
namespace App2_SOAPClient.Droid.Service {
    class ServiceSOAP : IServiceSOAP {

        public string Somar(int num1, int num2) {

            var serv = new com.dneonline.www.Calculator();

            return "Resultado WS SOAP:" + serv.Add(num1, num2).ToString();
        }

    }
}