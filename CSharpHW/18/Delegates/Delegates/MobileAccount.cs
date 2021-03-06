﻿using System.Collections.Generic;

namespace Delegates
{
    public class MobileAccount : IMobile
    {
        public delegate void MobileHandler(object sender, AccountEventArgs e);
        public event MobileHandler SendSMS;
        public event MobileHandler Called;
        public event MobileHandler GotSMS;
        public event MobileHandler GotCall;

        int _id;
        Dictionary<string, MobileAccount> _contacts = new Dictionary<string, MobileAccount>();

        public int Id { get => _id; set => _id = value; }
        public Dictionary<string, MobileAccount> Contacts { get => _contacts; set => _contacts = value; }

        public MobileAccount(int id)
        {
            Id = id;
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
            foreach (var item in Contacts)
            {
                if (item.Value.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        private string GetNameById(int id)
        {
            foreach (var item in Contacts)
            {
                if (item.Value.Id == id)
                {
                    return item.Key;
                }
            }
            return string.Empty;
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
