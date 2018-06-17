using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesAndAbstractClasses;

namespace MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var loginWebServices = new LoginWebServices())
            {
               loginWebServices.LogIn();
            }
            Console.ReadLine();
        }
    }
}
