using LINQ;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Delegates
{
    public class MobileOperator
    {
        List<MobileAccount> _list = new List<MobileAccount>();
        List<ActionLog> _log = new List<ActionLog>();

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
            //Console.WriteLine(e.Message);
            var account = sender as MobileAccount;
            if (account != null)
            {
                Route(account.Id, e.Id, Action.SMS);
            } 
        }

        private void OnCall(object sender, AccountEventArgs e)
        {
            //Console.WriteLine(e.Message);
            var account = sender as MobileAccount;
            if (account != null)
            {
                Route(account.Id, e.Id, Action.Call);
            }
        }

        private void OnGotSMS(object sender, AccountEventArgs e)
        {
            //Console.WriteLine(e.Message);
        }

        private void OnGotCall(object sender, AccountEventArgs e)
        {
            //Console.WriteLine(e.Message);
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

        public void Route(int fromMobileId, int toMobileId, Action action)
        {
            if (!SearchById(toMobileId))
            {
                //Console.WriteLine("Wrong number!");
            }
            else
            {
                var fromMobile = _list.Find(x => x.Id == fromMobileId);
                var toMobile = _list.Find(x => x.Id == toMobileId);
                switch (action) {
                    case Action.SMS:
                        toMobile.SMSIn(fromMobileId);
                        _log.Add(new ActionLog(fromMobile, toMobile, action));
                        break;
                    case Action.Call:
                        toMobile.CallIn(fromMobileId);
                        _log.Add(new ActionLog(fromMobile, toMobile, action));
                        break;
                }
                //Console.WriteLine("Id {0} | Actoin {1}", fromMobileId, action);
            }
        }

        public void GetStaticstic()
        {
            var topInStatistic = from l in _log
                                 group l by l.MobileAccount2.Id into g
                                 select new { Name = g.Key, Count = g.Count(x => x.Action == Action.Call) + (g.Count(x => x.Action == Action.SMS) * 0.5) };
            topInStatistic = topInStatistic.OrderByDescending(x => x.Count).Take(5);
            Console.WriteLine("Top 5 InMobiles");
            foreach (var group in topInStatistic)
            {
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            }

            var topOutStatistic = from l in _log
                                 group l by l.MobileAccount1.Id into g
                                 select new { Name = g.Key, Count = g.Count(x => x.Action == Action.Call) + (g.Count(x => x.Action == Action.SMS) * 0.5) };
            topOutStatistic = topOutStatistic.OrderByDescending(x => x.Count).Take(5);
            Console.WriteLine("Top 5 OutMobiles");
            foreach (var group in topOutStatistic)
            {
                Console.WriteLine("{0} : {1}", group.Name, group.Count);
            }
        }

    }
}
