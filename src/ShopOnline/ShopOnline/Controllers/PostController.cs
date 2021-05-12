using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index()
        {
            var model = _postService.FindAll();
            return View(model);
        }
    }
}