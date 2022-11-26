using MessageApp.BusinessLayer.Abstract;
using MessageApp.DataAccessLayer.Abstract;
using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetMessageByPhoneNumber(string phone)
        {
            return _messageDal.GetMessageByPhoneNumber(phone);
        }

        public List<Message> GetMessageByReceiver(int receiverID, string senderPhone)
        {
            return _messageDal.GetMessageByReceiver(receiverID, senderPhone);
        }

        public List<Message> GetMessageBySender(string receiverPhone, int receiverID)
        {
            return _messageDal.GetMessageBySender(receiverPhone, receiverID);
        }

        public void TDelete(Message t)
        {
           _messageDal.Delete(t);
        }

        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
