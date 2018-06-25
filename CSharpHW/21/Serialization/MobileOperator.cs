using LINQ;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace Delegates
{
    [Serializable]
    [DataContract]
    [XmlRoot("MobileOperator")]
    [ProtoContract]
    public class MobileOperator
    {
        [DataMember]
        [ProtoMember(1)]
        List<MobileAccount> _list = new List<MobileAccount>();
        [NonSerialized]
        List<ActionLog> _log = new List<ActionLog>();
        [NonSerialized]
        int _mobileIdCount = 1;

        public bool AddMobileAccount(MobileAccount mobileAccount)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(mobileAccount);
            if (!Validator.TryValidateObject(mobileAccount, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }

            if (_list.Exists(x => x.Id == mobileAccount.Id))
            {
                return false;
            }
            mobileAccount.Id = _mobileIdCount;
            _list.Add(mobileAccount);
            mobileAccount.SendSMS += OnSMS;
            mobileAccount.Called += OnCall;
            mobileAccount.GotSMS += OnGotSMS;
            mobileAccount.GotCall += OnGotCall;
            _mobileIdCount++;
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
                switch (action)
                {
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

        public void Clear()
        {
            _list = new List<MobileAccount>();
            _log = new List<ActionLog>();
            _mobileIdCount = 1;
        }

        public void BinarySerialize()
        {
            using (var stream = File.Create("BinaryData.dat"))
            {

                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, _list);
            }
        }

        public void BinaryDeserialize()
        {
            using (var stream = File.OpenRead("BinaryData.dat"))
            {
                var formatter = new BinaryFormatter();

                if (formatter.Deserialize(stream) is List<MobileAccount> list)
                {
                    foreach (var item in list)
                    {
                        AddMobileAccount(item);
                    }
                }
            }
        }

        public void JsonSerialize()
        {
            using (var sw = new StreamWriter("JsonData.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                using (var writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, _list);
                }
            }
        }

        public void JsonDeserialize()
        {
            using (var stream = File.OpenRead("JsonData.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                using (var sw = new StreamReader("JsonData.json"))
                using (JsonReader reader = new JsonTextReader(sw))
                {
                    var collDeserialize = (List<MobileAccount>) serializer.Deserialize(reader,
                        typeof(List<MobileAccount>));
                    foreach (var item in collDeserialize)
                    {
                        AddMobileAccount(item);
                    }
                }
            }
        }

        public void XMLSerialize()
        {
            var formatter = new XmlSerializer(typeof(List<MobileAccount>));

            using (var fs = new FileStream("XMLData.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _list);
            }
        }

        public void XMLDeserialize()
        {
            var formatter = new XmlSerializer(typeof(List<MobileAccount>));
            using (var fs = new FileStream("XMLData.xml", FileMode.OpenOrCreate))
            {
                foreach (var item in (List<MobileAccount>)formatter.Deserialize(fs))
                {
                    AddMobileAccount(item);
                }
            }
        }

        public void ProtoBufSerialize()
        {
            using (var fs = new FileStream("ProtoBufData.ptb", FileMode.OpenOrCreate))
            {
                Serializer.Serialize(fs, _list);
            }
        }

        public void ProtoBufDeserialize()
        {
            using (var fs = new FileStream("ProtoBufData.ptb", FileMode.OpenOrCreate))
            {
                var list = (List<MobileAccount>)Serializer.Deserialize(typeof(List<MobileAccount>), fs);
                foreach (var item in list)
                {
                    AddMobileAccount(item);
                }
            }
        }
    }
}
