using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public interface IMobile
    {
        void SMSOut(int id);

        void CallOut(int id);

        void SMSIn(int id);

        void CallIn(int id);
    }
}
