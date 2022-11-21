using MessageApp.BusinessLayer.Abstract;
using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.BusinessLayer.Concrete
{
    public class MessageManager : IMessageDal
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Message t)
        {
           _messageDal.TDelete(t);
        }

        public void TInsert(Message t)
        {
            _messageDal.TInsert(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.TUpdate(t);
        }
    }
}
