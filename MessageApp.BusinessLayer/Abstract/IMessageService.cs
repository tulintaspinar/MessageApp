using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetMessageByPhoneNumber(string phone);
        List<Message> GetMessageByReceiver(int receiverID, string senderPhone);
        List<Message> GetMessageBySender(string receiverPhone, int receiverID);
    }
}
