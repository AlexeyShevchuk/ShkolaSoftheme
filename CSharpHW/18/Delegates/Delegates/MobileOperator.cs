using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class MobileOperator
    {

        List<MobileAccount> _list = new List<MobileAccount>();

        public void AddMobileAccount(MobileAccount mobileAccount)
        {
            _list.Add(mobileAccount);
            mobileAccount.SendSMS += OnSMS;
            mobileAccount.Called += OnCall;
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


        public void Route(int idFirst, int idSecond, Action action)
        {
            if (!SearchById(idSecond))
            {
                Console.WriteLine("Wrong number!");
            }
            else
            {
                Console.WriteLine("Id {0} | Actoin {1}", idFirst, action);
            }
        }
    }
}
