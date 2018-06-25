using System;

namespace Delegates
{
    public class MobileOperatorDemo
    {
        public void Start()
        {
            MobileOperator mobileOperator = new MobileOperator();
            var mobile1 = new MobileAccount(1);
            var mobile2 = new MobileAccount(2);
            var mobile3 = new MobileAccount(3);
            var mobile4 = new MobileAccount(4);
            var mobile5 = new MobileAccount(5);
            var mobile6 = new MobileAccount(6);
            var mobile7 = new MobileAccount(7);
            var mobile8 = new MobileAccount(8);
            var mobile9 = new MobileAccount(9);

            mobile5.Contacts.Add("Alex1", mobile1);
            mobile3.Contacts.Add("Alex1", mobile1);
            mobile2.Contacts.Add("Alex1", mobile1);

            mobile1.Contacts.Add("mobile5", mobile5);
            mobile1.Contacts.Add("mobile3", mobile3);
            mobile1.Contacts.Add("mobile2", mobile2);

            mobileOperator.AddMobileAccount(mobile1);
            mobileOperator.AddMobileAccount(mobile2);
            mobileOperator.AddMobileAccount(mobile3);
            mobileOperator.AddMobileAccount(mobile4);
            mobileOperator.AddMobileAccount(mobile5);
            mobileOperator.AddMobileAccount(mobile6);
            mobileOperator.AddMobileAccount(mobile7);
            mobileOperator.AddMobileAccount(mobile8);
            mobileOperator.AddMobileAccount(mobile9);

            mobile1.CallOut(mobile3.Id);
            mobile2.CallOut(mobile3.Id);
            mobile3.CallOut(mobile3.Id);
            mobile4.CallOut(mobile3.Id);
            mobile5.CallOut(mobile3.Id);
            mobile6.CallOut(mobile5.Id);
            mobile2.CallOut(mobile1.Id);
            mobile7.CallOut(mobile3.Id);
            mobile8.CallOut(mobile3.Id);
            mobile9.CallOut(mobile3.Id);
            mobile1.CallOut(mobile9.Id);
            mobile2.CallOut(mobile8.Id);
            mobile3.CallOut(mobile7.Id);
            mobile4.CallOut(mobile6.Id);
            mobile5.CallOut(mobile5.Id);
            mobile6.CallOut(mobile4.Id);
            mobile2.CallOut(mobile3.Id);
            mobile7.CallOut(mobile2.Id);
            mobile8.CallOut(mobile1.Id);
            mobile9.CallOut(mobile3.Id);
            mobile1.CallOut(mobile3.Id);
            mobile1.CallOut(mobile3.Id);
            mobile3.CallOut(mobile5.Id);
            mobile2.CallOut(mobile1.Id);
            mobile1.CallOut(mobile3.Id);
            mobile1.CallOut(mobile3.Id);
            mobile3.CallOut(mobile5.Id);
            mobile2.CallOut(mobile1.Id);
            mobile1.CallOut(mobile3.Id);
            mobile2.CallOut(49);

            mobile1.SMSOut(mobile3.Id);
            mobile3.SMSOut(mobile5.Id);
            mobile2.SMSOut(mobile1.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile3.SMSOut(mobile5.Id);
            mobile2.SMSOut(mobile1.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile3.SMSOut(mobile5.Id);
            mobile2.SMSOut(mobile1.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile3.SMSOut(mobile5.Id);
            mobile2.SMSOut(mobile1.Id);
            mobile1.SMSOut(mobile3.Id);
            mobile2.SMSOut(50);

            mobileOperator.GetStaticstic();

            Console.ReadLine();
        }
    }
}