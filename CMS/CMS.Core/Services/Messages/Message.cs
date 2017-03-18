using CMS.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Messages
{
    public class Message
    {
        public IComponent Sender { get; set; }
        public String Receiver { get; set; }
        public DateTime SendTime { get; set; }
        public String Value { get; set; }
    }
}
