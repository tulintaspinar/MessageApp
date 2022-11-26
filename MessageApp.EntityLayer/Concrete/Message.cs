using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageContent { get; set; }
        public string ReceiverName { get; set; } //alıcı adı
        public string ReceiverPhone { get; set; } //alıcı telefon numarası
        public string SenderPhone { get; set; }
        public DateTime Date { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

    }
}
