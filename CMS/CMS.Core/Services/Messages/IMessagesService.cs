﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Messages
{
    public interface IMessagesService
    {
        bool SendMessage(Message message);
        String RequestData(Message message);
    }
}
