using Business.Services;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class LogController : Controller
    {
        ILogService logService;
        IUserService userService;
        public LogController() { }
        public LogController(ILogService logService, IUserService userService)
        {
            this.logService = logService;
            this.userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listLog()
        {
            var logs = logService.FindAll();
            var logsDTO = AutoMapper.Mapper.Map<IEnumerable<LogDTO>>(logs);
            return PartialView(logsDTO);
        }
        [HttpPost]
        public ActionResult addLog(string data)
        {
            var username = User.Identity.Name;
            Log log = new Log();
            log.Content = username  + data;
            log.CreatedBy = userService.FindAll().Where(x=>x.Username==username).FirstOrDefault().ID;
            log.CreateAt = DateTime.Now;
            log.Status = true;
         
            bool status = logService.Add(log);
            logService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}