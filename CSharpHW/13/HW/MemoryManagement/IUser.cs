using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        string GetFullInfo();
    }
}
