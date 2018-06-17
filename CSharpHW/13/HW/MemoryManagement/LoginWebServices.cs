using MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    class LoginWebServices : IDisposable
    {
        UserDataBase _userDataBase;
        AuthenticatorByName _authenticatorByName;
        AuthenticatorByEmail _authenticatorByEmail;
        public LoginWebServices()
        {
            var accounts = new User[]
            {
                new User("Alex1", "Alex1@ukr.net", "1234"),
                new User("Alex2", "Alex2@ukr.net", "1234"),
                new User("Alex3", "Alex3@ukr.net", "1234")
            };
            _userDataBase = new UserDataBase(accounts);
            _authenticatorByName = new AuthenticatorByName(_userDataBase);
            _authenticatorByEmail = new AuthenticatorByEmail(_userDataBase);
        }

        public void Dispose()
        {
            _userDataBase.Dispose();
        }

        public void LogIn()
        {
            var flag = false;
            var login = string.Empty;
            var password = string.Empty;

            do
            {
                flag = true;
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (string.Equals(login, "exit"))
                {
                    flag = false;
                    continue;
                }

                Console.WriteLine("Password: ");
                password = Console.ReadLine();
                if (string.Equals(password, "exit"))
                {
                    flag = false;
                    continue;
                }


                if (login.Contains("@"))
                {
                    var newUser = new User() { Email = login, Password = password };
                    if (!_authenticatorByEmail.AuthenticateUser(newUser))
                    {
                        Console.WriteLine("Name: ");
                        var name = Console.ReadLine();
                        if (string.Equals(name, "exit"))
                        {
                            flag = false;
                            continue;
                        }
                        newUser.Name = name;
                        _userDataBase.AddUser(newUser);
                    }
                }
                else
                {
                    var newUser = new User() { Name = login, Password = password };
                    if (!_authenticatorByName.AuthenticateUser(newUser))
                    {
                        Console.WriteLine("Email: ");
                        var email = Console.ReadLine();
                        if (string.Equals(email, "exit") || !email.Contains("@"))
                        {
                            flag = false;
                            continue;
                        }
                        newUser.Email = email;
                        _userDataBase.AddUser(newUser);
                    }
                }
            }
            while (flag);
        }
    }
}
