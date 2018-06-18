using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //   Каждый MobileAccount имеет свой уникальный номер и методы по отправке смс и совершении звонка на любой другой номер.
    class MobileAccount : IMobile
    {
        public delegate void MobileHandler(object sender, AccountEventArgs e);
        public event MobileHandler SendSMS;
        public event MobileHandler Called;

        int _id;

        public int Id { get => _id; set => _id = value; }

        public MobileAccount(int id)
        {
            Id = id;
        }


        public void SMS(int id)
        {
            SendSMS?.Invoke(this, new AccountEventArgs(string.Format("SMS from {0} to {1}", this.Id, id), id));
        }

        public void Call(int id)
        {
            Called?.Invoke(this, new AccountEventArgs(string.Format("Call from {0} to {1}", this.Id, id), id));
        }
    }
}
