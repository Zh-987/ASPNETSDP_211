using ItStepSDP211.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ItStepSDP211.Controllers
{
    public class ChatController : Controller
    {
        static ChatModel chatModel;
        public ActionResult Index(string user, bool? logOn, bool? logOff, string chatMessage)
        {
            try
            {
                if(chatModel == null)
                {
                    chatModel = new ChatModel();
                }
                if (chatModel.Messages.Count > 100) {
                chatModel.Messages.RemoveRange(0,90);
                }
                if (!Request.IsAjaxRequest())
                {
                    return View(chatModel);
                }
                else if (logOn != null && (bool)logOn)
                {
                    if(chatModel.Users.FirstOrDefault(u =>u.Name == user) != null)
                    {
                        throw new Exception("This username is already taken");
                    }
                    else if (chatModel.Users.Count > 10)
                    {
                        throw new Exception("Limit in the Chat(only 10 users)");
                    }
                    else
                    {
                        chatModel.Users.Add(new ChatUser()
                        {
                            Name = user,
                            LoginTime = DateTime.Now,
                            LastPing = DateTime.Now
                        });

                        chatModel.Messages.Add(new ChatMessage()
                        {
                            Message = user + "joined for the chat",
                            Date = DateTime.Now
                        });
                    }
                    return PartialView("ChatRoom", chatModel);
                }
                else if(logOff != null && (bool)logOff)
                {
                    logOFF(chatModel.Users.FirstOrDefault(u => u.Name == user));

                    return PartialView("ChatRoom", chatModel);
                }
                else
                {
                    ChatUser currentUser = chatModel.Users.FirstOrDefault(u => u.Name == user);

                    currentUser.LastPing = DateTime.Now;

                    List<ChatUser> toRemove = new List<ChatUser>();
                    foreach(Models.ChatUser usr in chatModel.Users)
                    {
                        TimeSpan span = DateTime.Now - currentUser.LastPing;
                        if (span.TotalSeconds > 20)
                        {
                            toRemove.Add(usr);
                        }
                    }
                    foreach(ChatUser usr in toRemove)
                    {
                        logOFF(usr);
                    }

                    if (!string.IsNullOrEmpty(chatMessage))
                    {
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            User = currentUser,
                            Message = chatMessage,
                            Date = DateTime.Now
                        });
                    }
                    return PartialView("History",chatModel);
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message);
            }
            
        }

        public void logOFF(ChatUser user)
        {
            chatModel.Users.Remove(user);
            chatModel.Messages.Add(new ChatMessage()
            {
                Message = user.Name + "leaved from chat",
                Date= DateTime.Now
            });
        }
        
    }
}