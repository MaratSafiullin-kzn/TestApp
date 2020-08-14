using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

using TestASPNetMVCwithAngulsrJS.Models;

namespace TestASPNetMVCwithAngulsrJS.Controllers
{
    public class MessageController : Controller
    {
        private DatabaseContext db = null;

        public MessageController()
        {
            db = new DatabaseContext();
        }

        //GET: Messages
        public ActionResult Get()
        {
            var messages = db.Messages.ToList();

            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            var converted = JsonConvert.SerializeObject(messages, null, jsSettings);
            return Content(converted, "application/json");
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "Original, Encrypted")] Message message)
        {
            message.DateTime = DateTime.Now;

            db.Messages.Add(message);
            db.SaveChanges();

            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();

            return Json(null);
        }
    }
}
