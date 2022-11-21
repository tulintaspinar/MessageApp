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
        public string UserNickName { get; set; }
        public string ImageUrl { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedinLink { get; set; }
        public string YoutubeLink { get; set; }

    }
}
