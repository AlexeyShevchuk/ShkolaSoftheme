using System;
using System.ServiceModel;
using System.Diagnostics;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            var channelFactory = new ChannelFactory<IKeyContract>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/"));

            var service = channelFactory.CreateChannel();

            var clientId = Process.GetCurrentProcess().Id;

            Console.WriteLine("Client: Press key for send");
            Console.WriteLine("Client: For exit press End");
            var keyOut = Console.ReadKey();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Client: Key out: {0}", keyOut.Key);

                try
                {
                    var keyResponse = service.GetKey(keyOut.Key, clientId);
                    Console.WriteLine("Client: Key response: {0}", keyResponse);
                }
                catch (EndpointNotFoundException e)
                {
                    Console.WriteLine("Server is not available");
                    Console.WriteLine("Try again");
                }

                keyOut = Console.ReadKey();
            }
            while (keyOut.Key != ConsoleKey.End);

            service.GetKey(keyOut.Key, clientId);
        }
    }
}
