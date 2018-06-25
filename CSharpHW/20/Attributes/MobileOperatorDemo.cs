using System;

namespace Delegates
{
    public class MobileOperatorDemo
    {
        public void Start()
        {
            MobileOperator mobileOperator = new MobileOperator();
            var mobile1 = new MobileAccount("1","Shevchuk1",DateTime.Today,"alex1@ukr.net");
            var mobile2 = new MobileAccount(null,"Shevchuk2",DateTime.Today,"alex2@ukr.net");
            var mobile3 = new MobileAccount("Alex3","Shevchuk3",DateTime.Today,"alex3@ukr.net");
            var mobile4 = new MobileAccount("Alex4","Shevchuk4",DateTime.Today,"alex4@ukr.net");
            var mobile5 = new MobileAccount("Alex5","Shevchuk5",DateTime.Today,"alex5@ukr.net");
            var mobile6 = new MobileAccount("Alex6","Shevchuk6",DateTime.Today,"alex6@ukr.net");
            var mobile7 = new MobileAccount("Alex7","Shevchuk7",DateTime.Today,"alex7@ukr.net");
            var mobile8 = new MobileAccount("Alex8","Shevchuk8",DateTime.Today,"alex8@ukr.net");
            var mobile9 = new MobileAccount("Alex9","Shevchuk9",DateTime.Today,"alex9@ukr.net");
            mobile1.Name = "1";
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