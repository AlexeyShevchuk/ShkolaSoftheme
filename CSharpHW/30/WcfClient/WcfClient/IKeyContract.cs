using System;
using System.ServiceModel;

namespace WcfClient
{
    [ServiceContract]
    public interface IKeyContract
    {
        [OperationContract]
        ConsoleKey GetKey(ConsoleKey key, int clientId);
    }
}