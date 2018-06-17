using InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class UserDataBase : IUserDataBase
    {
        User[] _accounts;

        public UserDataBase(User[] accounts)
        {
            _accounts = accounts;
        }

        public void AddUser(User user)
        {
            var usersBuff = new User[_accounts.Length + 1];
            _accounts.CopyTo(usersBuff, 0);
            usersBuff[usersBuff.Length - 1] = user;
            _accounts = usersBuff;
        }

        public bool IsUserNameExist(string name) 
        {
            foreach (var item in _accounts)
            {
                if (item.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public User[] GetUsers()
        {
            return _accounts;
        }

        public void Dispose()
        {
            foreach (var item in _accounts)
            {
                Console.WriteLine(item.GetFullInfo());
            }
        }
    }
}
