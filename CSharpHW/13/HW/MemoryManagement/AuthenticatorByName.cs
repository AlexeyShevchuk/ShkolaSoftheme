using MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    class AuthenticatorByName
    {
        UserDataBase _users;
        public AuthenticatorByName(UserDataBase users)
        {
            _users = users;
        }

        public bool AuthenticateUser(IUser user)
        {
            foreach (var item in _users.GetUsers())
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
