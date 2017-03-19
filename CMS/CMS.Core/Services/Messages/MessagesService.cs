using CMS.Core.Services.ComponentsLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Messages
{
    internal class MessagesService : IMessagesService
    {
        IComponentsLoaderService componentsLoader = null;

        public MessagesService(IComponentsLoaderService componentsLoader)
        {
            this.componentsLoader = componentsLoader;
        }

        public bool SendMessage(Message message)
        {
            var component = componentsLoader.GetComponent(message.Receiver);
            if (component != null)
                return false;

            component.ReceiveMessage(message);
            return true;
        }

        public String RequestData(Message message)
        {
            var component = componentsLoader.GetComponent(message.Receiver);
            if (component == null)
                return "{ 'result': 'error' }";

            var result = component.ReceiveMessage(message);
            return result;
        }
    }
}
