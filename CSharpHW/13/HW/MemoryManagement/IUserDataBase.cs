using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesAndAbstractClasses;

namespace MemoryManagement
{
    //   с методами получения всех текущих пользователей, поиска пользователя по имени, добавления нового пользователя.
    interface IUserDataBase : IDisposable
    {
        User[] GetUsers();
        bool IsUserNameExist(string name);
        void AddUser(User user);
    }
}
