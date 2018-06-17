using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    class AuthenticatorByName
    {
        User[] _users;
        public AuthenticatorByName(User[] users)
        {
            Users = users;
        }

        internal User[] Users { get => _users; set => _users = value; }

        public bool AuthenticateUser(IUser user)
        {
            foreach (var item in Users)
            {
                if (item.Name.Equals(user.Name) && item.Password.Equals(user.Password))
                {
                    Console.WriteLine(item.GetFullInfo());
                    return true;
                }
            }
            return false;
        }
    }
}
