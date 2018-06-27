using System;

namespace WcfHost
{
    class KeyService : IKeyContract
    {
        public ConsoleKey GetKey(ConsoleKey key, int clientId)
        {
            Console.WriteLine("Host got key: {0} from Client: {1}",key, clientId);

            if (key == ConsoleKey.End)
            {
                Console.WriteLine("Client: {0} completed the session.", clientId);
            }

            return key;
        }
    }
}