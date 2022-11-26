using MessageApp.DataAccessLayer.Abstract;
using MessageApp.DataAccessLayer.Concrete;
using MessageApp.DataAccessLayer.Repository;
using MessageApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetMessageByPhoneNumber(string phone)
        {
            using(var context = new Context())
            {
                return context.Messages.Include(x=>x.AppUser).Where(x => x.SenderPhone == phone).ToList();
            }
        }

        public List<Message> GetMessageByReceiver(int receiverID,string senderPhone)
        {
            using (var context = new Context())
            {
                return context.Messages.Include(x => x.AppUser).Where(x => x.AppUserID == receiverID && x.SenderPhone==senderPhone).ToList();
            }
        }

        public List<Message> GetMessageBySender(string receiverPhone, int receiverID)
        {
            using (var context = new Context())
            {
                return context.Messages.Include(x => x.AppUser).Where(x => x.AppUserID == receiverID && x.ReceiverPhone == receiverPhone).ToList();
            }
        }
    }
}
