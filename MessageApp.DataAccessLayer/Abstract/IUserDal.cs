using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
    }
}
