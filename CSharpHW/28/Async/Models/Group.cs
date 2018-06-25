using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Async.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public Curator Curator { get; set; }
    }
}