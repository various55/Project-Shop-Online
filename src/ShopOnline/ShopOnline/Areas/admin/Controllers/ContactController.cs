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
    [Authorize]
    public class ContactController : Controller

    {
        IContactService Contactservice;
        public ContactController()
        {

        }
        public ContactController(IContactService Contactservice)
        {
            this.Contactservice = Contactservice;
        }

        // GET: admin/Contact
        public ActionResult Index()
        {
            var contact = Contactservice.FindAll();
            // Phải chuyền sang DTO 
            ICollection<ContactDTO> contactDTO = AutoMapper.Mapper.Map<ICollection<ContactDTO>>(contact);
            return View(contactDTO);

        }
        [HttpGet]
        public PartialViewResult ListContact()
        {
            var contact = Contactservice.FindAll();
            var contactDTO = AutoMapper.Mapper.Map<ICollection<ContactDTO>>(contact);
            return PartialView(contactDTO);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = Contactservice.Remove(id);
            Contactservice.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult AddOrUpdate(ContactDTO model)
        {
            model.CreatedAt = DateTime.Now;

         
            var status = false;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                Contact Contact = new Contact();
                Contact = AutoMapper.Mapper.Map<Contact>(model);
                if (model.ID == 0)
                {
                    status = Contactservice.Add(Contact);
                }
                else { status = Contactservice.Update(Contact); }
                Contactservice.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var contact = Contactservice.FindById(id);
            var ContactDTO = AutoMapper.Mapper.Map<ContactDTO>(contact);
            ViewBag.Data = ContactDTO;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult InfoDetail(int id)
        {
            var contact = Contactservice.FindById(id);
            var ContactDTO = AutoMapper.Mapper.Map<ContactDTO>(contact);
            return PartialView(ContactDTO);
        }
    }
}
