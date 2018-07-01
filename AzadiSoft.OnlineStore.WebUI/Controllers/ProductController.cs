using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzadiSoft.OnlineStore.Framework;
using AzadiSoft.OnlineStore.ServiceLayer;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProduct_Service _productService;

        public ProductController(IProduct_Service productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var models = _productService.GetViewModels();

            var viewModel = new ProductListViewModel(){Products = models};

            return View(viewModel);
        }

        [ActionName("View")]
        public ActionResult ViewDetail(int id)
        {
            var model = _productService.GetViewModel(id);

            return View("ViewDetail",  model);
        }

        public ActionResult Search(string title = null)
        {
            var produts = _productService.GetAllQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                produts = produts.Where(x => x.Title.Contains(title) || x.Description.Contains(title));
            }

            var models = produts.ToList().Select(x => x.ToModel()).ToList();

            var viewModel = new ProductListViewModel {Product_Title = title, Products = models};

            return PartialView("_ProductList", viewModel);
        }
    }
}