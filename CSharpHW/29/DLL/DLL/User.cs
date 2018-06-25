using System;

namespace DLL
{
    class User
    {
        string _name;
        string _email;
        string _password;
        DateTime _lastIn;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals("exit"))
                {
                    throw new ArgumentException();
                }

                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Equals("exit"))
                {
                    throw new ArgumentException();
                }

                _email = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Equals("exit"))
                {
                    throw new ArgumentException();
                }

                _password = value;
            }
        }

        public DateTime LastIn
        {
            get => _lastIn;
            set => _lastIn = value;
        }

        public User()
        {
            LastIn = DateTime.Now;
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            LastIn = DateTime.Now;
        }

        public string GetFullInfo()
        {
            return string.Format("Name: {0} | Email: {1} | Password: {2} | LastIn: {3}", Name, Email, Password, LastIn);
        }
    }
}
