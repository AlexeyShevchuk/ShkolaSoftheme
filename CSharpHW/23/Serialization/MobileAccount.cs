using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.WindowsServerSolutions.Administration.ObjectModel;

namespace Delegates
{
    [Serializable]
    [DataContract]
    //[XmlRoot("MobileAccount")]
    public class MobileAccount : IMobile
    {
        public delegate void MobileHandler(object sender, AccountEventArgs e);
        public event MobileHandler SendSMS;
        public event MobileHandler Called;
        public event MobileHandler GotSMS;
        public event MobileHandler GotCall;

        private int _id;


        [DataMember]
        //[XmlAttribute("Name")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [DataMember]
        //[XmlAttribute("Surname")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [DataMember]
        [Display(Name = "Дата")]
        //[XmlAttribute("BirthDay")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2019", ErrorMessage = "Недопустимая дата")]
        public DateTime BirthDay { get; set; }

        [DataMember]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        //[XmlAttribute("Email")]
        public string Email { get; set; }


        public int Id { get => _id; set => _id = value; }

        [DataMember]
        private SerializableDictionary<string, MobileAccount> _contacts = new SerializableDictionary<string, MobileAccount>();
        public SerializableDictionary<string, MobileAccount> Contacts { get => _contacts; set => _contacts = value; }

        public MobileAccount()
        {
        }

        public MobileAccount(string name, string surname, DateTime birthbay, string email)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthbay;
            Email = email;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        public bool AddMobileAccount(string name, MobileAccount mobileAccount)
        {
            if (Contacts.ContainsValue(mobileAccount))
            {
                return false;
            }
            Contacts.Add(name, mobileAccount);
            return true;
        }

        private bool SearchById(int id)
        {
            try
            {
                var name = Contacts.First(x => x.Value.Id == id);

                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private string GetNameById(int id)
        {
            try
            {
                var name = Contacts.First(x => x.Value.Id == id);

                return name.Key;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public void SMSOut(int toMobileId)
        {
            SendSMS?.Invoke(this, new AccountEventArgs(string.Format("SMSOut from {0} to {1}", this.Id, toMobileId), toMobileId));
        }

        public void CallOut(int toMobileId)
        {
            Called?.Invoke(this, new AccountEventArgs(string.Format("CallOut from {0} to {1}", this.Id, toMobileId), toMobileId));
        }

        public void SMSIn(int fromMobileId)
        {
            if (SearchById(fromMobileId))
            {
                GotSMS?.Invoke(this, new AccountEventArgs(string.Format("{0} GotSMS from {1}", this.Id, GetNameById(fromMobileId)), fromMobileId));
            }
            else
            {
                GotSMS?.Invoke(this, new AccountEventArgs(string.Format("{0} GotSMS from {1}", this.Id, fromMobileId), fromMobileId));
            }
        }

        public void CallIn(int fromMobileId)
        {
            if (SearchById(fromMobileId))
            {
                GotCall?.Invoke(this, new AccountEventArgs(string.Format("{0} GotCall from {1}", this.Id, GetNameById(fromMobileId)), fromMobileId));
            }
            else
            {
                GotCall?.Invoke(this, new AccountEventArgs(string.Format("{0} GotCall from {1}", this.Id, fromMobileId), fromMobileId));
            }
        }
    }
}
