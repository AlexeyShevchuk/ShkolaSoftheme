using System;
using System.ServiceModel;

namespace WcfHost
{
    [ServiceContract]
    public interface IKeyContract
    {
        [OperationContract]
        ConsoleKey GetKey(ConsoleKey key, int clientId);
    }
}