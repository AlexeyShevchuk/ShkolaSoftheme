using System;

namespace HW1
{
    struct UserStruct : ICloneable
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public SomeClass SomeClass { get; set; }
        public UserStruct(string login, string password, string email, SomeClass someClass)
        {
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.SomeClass = someClass;
        }

        public object Clone()
        {
            return new UserStruct(this.Login, this.Password, this.Email, this.SomeClass);
        }

        public override string ToString()
        {
            return Login + " " + " " + SomeClass.A + " " + SomeClass.B + " " + this.GetHashCode();
        }
    }
}
