using RepositoryExample_15_02_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryExample_15_02_22.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository rep = new ProductRepository();
        BaseRepository<Categories> catRepo = new BaseRepository<Categories>();
        ProductsModel pm = new ProductsModel();
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                name = "";
            }
            pm.pList = rep.GenelListe().Where(x => x.ProductName.Contains(name)).ToList();
            return View(pm);
        }
        public ActionResult Detail(int id)
        {
            pm.Products = rep.Bul(id);
            return View(pm);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(ProductsModel model)
        {
            if (ModelState.IsValid)
            {
                Products p = new Products();
                p.ProductID = model.Products.ProductID;
                p.ProductName = model.Products.ProductName;
                p.UnitPrice = model.Products.UnitPrice;
                p.QuantityPerUnit = model.Products.QuantityPerUnit;
                p.Discontinued = model.Products.Discontinued;
                rep.Ekle(p);
                rep.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Products p = rep.Bul(id);
            rep.Sil(p);
            rep.Guncel();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            pm.Products = rep.Bul(id);
            pm.CategoryList = catRepo.GenelListe().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            });
            return View(pm);
        }
        [HttpPost]
        public ActionResult Update(int id, ProductsModel pm)
        {
            if (ModelState.IsValid)
            {
                Products selectedProduct = rep.Bul(id);
                selectedProduct.ProductName = pm.Products.ProductName;
                selectedProduct.UnitPrice = pm.Products.UnitPrice;
                selectedProduct.QuantityPerUnit = pm.Products.QuantityPerUnit;
                selectedProduct.CategoryID = pm.Products.CategoryID;
                selectedProduct.Discontinued = pm.Products.Discontinued;

                rep.Guncel();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult Choose()
        {
            ProductsModel p = new ProductsModel();
            p.pList = rep.GenelListe().OrderBy(x => x.ProductID).Skip(8).Take(16).ToList();
            return View(p);
        }
    }
}