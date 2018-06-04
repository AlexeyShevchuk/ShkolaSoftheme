using System;

namespace HW2
{
    class Human
    {
        private int _age;
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; }

        public Human(string firstName)
        {
            FirstName = firstName;
        }

        public Human(string firstName, int age)
        {
            FirstName = firstName;
            _age = age;
        }

        public Human(string firstName, string lastname, DateTime birthDate, int age)
        {
            FirstName = firstName;
            Lastname = lastname;
            BirthDate = birthDate;
            _age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Human h = (Human)obj;
            if (this.FirstName != h.FirstName)
            {
                return false;
            }
            if (this.Lastname != h.Lastname)
            {
                return false;
            }
            if (this.BirthDate != h.BirthDate)
            {
                return false;
            }
            if (this.Age != h.Age)
            {
                return false;
            }
            return true;
        }
    }
}
