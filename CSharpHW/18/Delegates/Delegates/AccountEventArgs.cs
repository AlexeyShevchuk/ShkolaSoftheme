using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class AccountEventArgs
    {
        public string Message { get; set; }

        public int Id { get; set; }

        public AccountEventArgs(string message, int id)
        {
            Message = message;
            Id = id;
        }
    }
}
