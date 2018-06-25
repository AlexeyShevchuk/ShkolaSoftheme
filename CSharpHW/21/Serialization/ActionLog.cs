using Delegates;

namespace LINQ
{
    public class ActionLog
    {
        public MobileAccount MobileAccount1 { get; set; }
        public MobileAccount MobileAccount2 { get; set; }
        public Action Action { get; set; }
        public ActionLog(MobileAccount a, MobileAccount b, Action action)
        {
            MobileAccount1 = a;
            MobileAccount2 = b;
            Action = action;
        }
    }
}