using Business.Services;
using Data.DTO;
using ShopOnline.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    [Authorize]
    [CustomAuthorize("ADMIN")]
    public class TransactionController : Controller
    {
        ITransactionService transactionService;
        public TransactionController()
        {

        }
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        // GET: admin/Transaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAll()
        {
            var transactions = transactionService.FindAll(new string[] { "User", "Order" });
            var tranDTO = AutoMapper.Mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return PartialView("Transactions/_TransactionsPartial", tranDTO);
        }
    }
}