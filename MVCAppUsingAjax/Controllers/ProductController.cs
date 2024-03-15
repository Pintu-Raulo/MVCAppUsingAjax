using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppUsingAjax.Models;

namespace MVCAppUsingAjax.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities dc = new NorthwindEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult DisplayProducts()
        {
            return View(dc.Products);
        }
        public ActionResult SearchProduct(string SearchTerm) 
        {
            List<Product> Products;
            if(SearchTerm.Trim().Length > 0)
                Products = (from P in dc.Products where  P.ProductName.Contains(SearchTerm) select P).ToList();
            else
                Products = dc.Products.ToList();
            return View("DisplayProducts", Products );

        }
        public JsonResult GetProducts(string term)
        {
            List<string>Products = dc.Products.Where(P => P.ProductName.StartsWith(term)).Select(P => P.ProductName).ToList();
            //var Products = (from P in dc.Products where P.ProductName.StartsWith(term)select new {P.ProductName}).ToList();
            return Json(Products, JsonRequestBehavior.AllowGet);
        }
    }
}