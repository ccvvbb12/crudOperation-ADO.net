using crudOperation_ADO.net.Models;
using MvcCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace crudOperation_ADO.net.Controllers
{
    public class HomeController : Controller
    {
        Productcmd cmd = new Productcmd();
        public ActionResult Index(int? i)
        {
            List<Product> pro = (List<Product>)cmd.getAllProductData().ToList();

            return View(pro.ToPagedList(i ?? 1, 10));
        }

        public ActionResult create()
        {
            var CategList = cmd.FillDropDown().ToList();
            ViewBag.category = CategList;

            return View();
        }
        [HttpPost]
        public ActionResult create(Product pro)
        {

            bool status = cmd.InsretProductData(pro);
            if (status == true)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult Edit(int Id)
        {
            var CategList = cmd.FillDropDown().ToList();
            ViewBag.Category = CategList;

            Product pro = cmd.getAllProductData().Find(x => x.ProductId == Id);

            return View(pro);

        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            bool status = cmd.editProductData(pro);
            if (status == true)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult Delete(int Id)
        {
            bool status = cmd.deleteProductData(Id);
            if (status == true)
            {
                return RedirectToAction("index");
            }

            return View();

        }
        public ActionResult Details(int Id)
        {
            var CategList = cmd.FillDropDown().ToList();
            ViewBag.Category = CategList;
            Product pro = cmd.getAllProductData().Find(x => x.ProductId == Id);

            return View(pro);

        }

    }
}
