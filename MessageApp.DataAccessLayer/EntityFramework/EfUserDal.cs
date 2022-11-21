using MessageApp.DataAccessLayer.Abstract;
using MessageApp.DataAccessLayer.Repository;
using MessageApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataAccessLayer.EntityFramework
{
    public class EfUserDal : GenericRepository<User>,IUserDal
    {
    }
}
