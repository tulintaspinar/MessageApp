using MessageApp.BusinessLayer.Abstract;
using MessageApp.DataAccessLayer.Concrete;
using MessageApp.EntityLayer.Concrete;
using MessageApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessageApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageManager;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        }
        public async Task<IActionResult> Chats()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserPhoto = user.ImageUrl;

            var listMessage = _messageManager.GetMessageByPhoneNumber(user.PhoneNumber);
            ViewBag.ListMessage = listMessage;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChatDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserPhoto = user.ImageUrl;
            ViewBag.userID = user.Id;

            var listMessage = _messageManager.GetMessageByPhoneNumber(user.PhoneNumber);
            ViewBag.ListMessage = listMessage;

            var atilanMesaj = _messageManager.GetMessageByReceiver(id, user.PhoneNumber); //kullanıcıya atılan mesajlar
            ViewBag.receiverName = atilanMesaj[0].ReceiverName;//Mesaj atılan kişinin adı
            ViewBag.receiverPhoto = atilanMesaj[0].AppUser.ImageUrl; //Alıcının profil fotoğrafı
            ViewBag.receiverID = atilanMesaj[0].AppUserID;

            var gelenMesaj = _messageManager.GetMessageBySender(user.PhoneNumber, user.Id);

            List<Message> messages = new List<Message>();
            messages.AddRange(atilanMesaj);
            messages.AddRange(gelenMesaj);
            ViewBag.messages = messages.OrderBy(x=>x.Date);
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            Message newMessage = new Message();

            using (var context=new Context())
            {
                var receiver = context.Users.Where(x => x.PhoneNumber == message.ReceiverPhone).FirstOrDefault();
                newMessage.ReceiverName = receiver.Name + " " + receiver.Surname;
                newMessage.AppUserID = receiver.Id;
            }

            newMessage.MessageContent = message.MessageContent;
            newMessage.SenderPhone = sender.PhoneNumber;
            newMessage.ReceiverPhone = message.ReceiverPhone;
            newMessage.Date = DateTime.Now;

            _messageManager.TInsert(newMessage);
            return RedirectToAction("Chats", "Message");
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(int receiverID,string MessageContent)
        {
            Message newMessage = new Message();
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            using (var context = new Context())
            {
                var receiver = context.Users.Where(x => x.Id == receiverID).FirstOrDefault();
                newMessage.ReceiverName = receiver.Name + " " + receiver.Surname;
                newMessage.ReceiverPhone = receiver.PhoneNumber;
            }
            newMessage.AppUserID = receiverID;
            newMessage.SenderPhone = sender.PhoneNumber;
            newMessage.MessageContent = MessageContent;
            newMessage.Date = DateTime.Now;

            _messageManager.TInsert(newMessage);
            return RedirectToAction("ChatDetail", new { @id = receiverID });
        }
       
    }
}
