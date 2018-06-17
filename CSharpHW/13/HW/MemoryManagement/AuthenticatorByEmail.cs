using MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    class AuthenticatorByEmail : IAuthenticator
    {
        UserDataBase _users;
        public AuthenticatorByEmail(UserDataBase users)
        {
            _users = users;
        }

        public bool AuthenticateUser(IUser user)
        {
            foreach (var item in _users.GetUsers())
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
