using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    class AuthenticatorByEmail : IAuthenticator
    {
        User[] _users;
        public AuthenticatorByEmail(User[] users)
        {
            Users = users;
        }

        internal User[] Users { get => _users; set => _users = value; }

        public bool AuthenticateUser(IUser user)
        {
            foreach (var item in Users)
            {
                if (item.Email.Equals(user.Email) && item.Password.Equals(user.Password))
                {
                    Console.WriteLine(item.GetFullInfo());
                    return true;
                }
            }
            return false;
        }
    }
}
