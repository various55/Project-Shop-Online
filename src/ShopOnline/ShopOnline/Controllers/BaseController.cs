using Business.Services;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class BaseController : Controller
    {
        // Khởi tạo đối tượng tầng dịch vụ Service
        IProductService productService;

        public BaseController()
        {

        }
        public BaseController(IProductService productService)
        {
            // Tiêm vào để sử dụng
            this.productService = productService;
        }

        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Add()
        {
            // T đang ví dụ nên bỏ tham số truyền vào là một ProductDTO, nếu add bình thường sẽ có  tham số Add(ProductDTO productDTO)
            // T sẽ giả data để có thể convert thử từ DTO sáng Model
            ProductDTO productDTO = new ProductDTO();
            productDTO.Name = "Áo sơ mi trắng nam";
            productDTO.CategoryID = 1;
            productDTO.SupplierID = 1;
            productDTO.UrlImage = "images/ao2.png";
            productDTO.Description = "Alo";
            productDTO.ImportPrice = 50000;
            productDTO.ExportPrice = 70000;
            // Nhận vào DTO => model 

            //if(ModelState.IsValid) -- Câu này kiểm tra hợp lệ k, nếu hợp lệ thì mới thêm vào, k thì sẽ trả về luôn
            // Ta sẽ chuyển từ DTO ( nhận từ View ) sang Model để có thể lưu xuống db
            Product product = new Product();
            // Convert từ DTO(View) -> Model(Db)
            product = AutoMapper.Mapper.Map<Product>(productDTO);
            // Sau đấy thì chỉ việc add xuống db
            //
            var res = productService.Add(product);
            // Lưu lại 1 transaction
            if (res) productService.Save();
            // Res trả về true nếu thành công, false nếu thất bại, gửi lên client, client sẽ hiển thị thông báo cho user
            return new JsonResult() { Data=res,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        //GET
        public ActionResult Update(int id)
        {
            // Update cx tương tự, update sẽ có method là POST và GET
            // GET dùng để lấy dữ liệu và đổ lên client
            // POST sẽ nhận dữ liệu từ client và tiến hành cập nhật
            // Đây là method GET, nhận vào 1 id và trả về đối tượng đấy
            var product = productService.FindById(id);
            // Chuyển nó thành productDTO để hiển thị lên view
            ProductDTO productDTO = AutoMapper.Mapper.Map<ProductDTO>(product);
            return View(productDTO);
        }
        //POST
        [HttpPost]
        public ActionResult Update(ProductDTO productDTO)
        {
           
            Product product = AutoMapper.Mapper.Map<Product>(productDTO);
            productService.Update(product);
            productService.Save();
            return View(productDTO);
        }
        public ActionResult Remove()
        {
            return View();
        }
        public ActionResult FindAll()
        {
            var products = productService.FindAll();
            return View();
        }
        public ActionResult FindInclude()
        {
            var products = productService.FindAll(new string[] { "Category" });
            return View();
        }
    }
}