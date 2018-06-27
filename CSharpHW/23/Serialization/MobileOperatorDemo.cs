using System;

namespace Delegates
{
    public class MobileOperatorDemo
    {
        public void Start()
        {
            var mobileOperator = new MobileOperator();
            mobileOperator.JsonDeserialize();

            var mobile1 = mobileOperator.List[0];
            var mobile2 = mobileOperator.List[1];
            var mobile3 = mobileOperator.List[2];
            var mobile4 = mobileOperator.List[3];
            var mobile5 = mobileOperator.List[4];
            var mobile6 = mobileOperator.List[5];
            var mobile7 = mobileOperator.List[6];

            mobile1.CallOut(mobile3.Id);
            mobile2.CallOut(mobile3.Id);
            mobile3.CallOut(mobile3.Id);
            mobile4.CallOut(mobile3.Id);
            mobile5.CallOut(mobile3.Id);
            mobile6.CallOut(mobile5.Id);
            mobile2.CallOut(mobile1.Id);
            mobile7.CallOut(mobile3.Id);
            mobile3.CallOut(mobile7.Id);
            mobile4.CallOut(mobile6.Id);
            mobile5.CallOut(mobile5.Id);
            mobile6.CallOut(mobile4.Id);
            mobile2.CallOut(mobile3.Id);
            mobile7.CallOut(mobile2.Id);
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

            foreach (var item in mobile1.Contacts)
            {
                Console.WriteLine(item.Key);
            }

            Console.ReadLine();
        }
    }
}