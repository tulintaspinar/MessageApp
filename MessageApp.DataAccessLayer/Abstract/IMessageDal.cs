using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetMessageByPhoneNumber(string phone);
        List<Message> GetMessageByReceiver(int receiverID, string senderPhone); //kullanıcıya atılmış mesajları listeler
        List<Message> GetMessageBySender(string receiverPhone,int receiverID); //bana atılmış mesajlar
    }
}
