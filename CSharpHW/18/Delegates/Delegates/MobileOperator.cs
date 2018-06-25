using System;
using System.Collections.Generic;

namespace Delegates
{
    public class MobileOperator
    {
        List<MobileAccount> _list = new List<MobileAccount>();

        public bool AddMobileAccount(MobileAccount mobileAccount)
        {
            if (_list.Exists(x => x.Id == mobileAccount.Id))
            {
                return false;
            }
            _list.Add(mobileAccount);
            mobileAccount.SendSMS += OnSMS;
            mobileAccount.Called += OnCall;
            mobileAccount.GotSMS += OnGotSMS;
            mobileAccount.GotCall += OnGotCall;
            return true;
        }

        private void OnSMS(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            var account = sender as MobileAccount;
            if (account != null)
            {
                Route(account.Id, e.Id, Action.SMS);
            } 
        }

        private void OnCall(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            var account = sender as MobileAccount;
            if (account != null)
            {
                Route(account.Id, e.Id, Action.Call);
            }
        }

        private void OnGotSMS(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void OnGotCall(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private bool SearchById(int id)
        {
            foreach (var item in _list)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Route(int fromMobileId, int toMobile, Action action)
        {
            if (!SearchById(toMobile))
            {
                Console.WriteLine("Wrong number!");
            }
            else
            {
                switch (action) {
                    case Action.SMS: _list.Find(x => x.Id == toMobile).SMSIn(fromMobileId); break;
                    case Action.Call: _list.Find(x => x.Id == toMobile).CallIn(fromMobileId); break;
                }
                Console.WriteLine("Id {0} | Actoin {1}", fromMobileId, action);
            }
        }
    }
}
