using DataAccess.Context;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ECommerceContext db = new ECommerceContext();
        Category category = new Category();
       
        // GET: Admin/Category
        public ActionResult Index()
        {
            TempData["urunSayisi"] = db.Products.Where(x=>x.ProductName="Teknoloji"x.SubCategoryId).ToList();
            return View(db.Categories.ToList());
        }
        public ActionResult AddCategory()
        {

            return View();
        }
    }
}