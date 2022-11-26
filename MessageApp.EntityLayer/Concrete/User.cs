using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.EntityLayer.Concrete
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail{ get; set; }
        public string UserPhoneNumber { get; set; }

    }
}
