using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            var serviceHost = new WebServiceHost(typeof(KeyService), new Uri("http://localhost:8000/"));

            serviceHost.AddServiceEndpoint(typeof(IKeyContract), new BasicHttpBinding(), "");

            serviceHost.Open();

            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
