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
    public class PostsController : Controller

    {
        IPostService PostService;
        public PostsController()
        {

        }
        public PostsController(IPostService PostService)
        {
            this.PostService = PostService;
        }

        // GET: admin/Posts
        public ActionResult Index()
        {
            var post = PostService.FindAll();
            // Phải chuyền sang DTO 
            ICollection<PostsDTO> postDTO = AutoMapper.Mapper.Map<ICollection<PostsDTO>>(post);
            return View(postDTO);

        }
        [HttpGet]
        public PartialViewResult ListPost()
        {
            var post = PostService.FindAll();
            var postDTO = AutoMapper.Mapper.Map<ICollection<PostsDTO>>(post);
            return PartialView(postDTO);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = PostService.Remove(id);
            PostService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult AddOrUpdate(PostsDTO model)
        {
            model.Status = true;
            var status = false;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                Post posts= new Post();
                posts = AutoMapper.Mapper.Map<Post>(model);
                if (model.ID==0)
                {
                    status = PostService.Add(posts);
                }
                else { status = PostService.Update(posts); }
                PostService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
     
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var post = PostService.FindById(id);
            var postsDTO = AutoMapper.Mapper.Map<PostsDTO>(post);
            ViewBag.Data = postsDTO;
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult InfoDetail(int id)
        {
            var post = PostService.FindById(id);
            var postsDTO = AutoMapper.Mapper.Map<PostsDTO>(post);
            return PartialView(postsDTO);
        }
    }
}