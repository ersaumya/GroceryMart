using GroceryMart.BAL;
using GroceryMart.DomainModels.Entities;
using GroceryMart.DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow) : base(uow)
        {
        }

        void BindCategory()
        {
            ViewBag.CategoryList = _uow.CategoryRepo.GetAll();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(_uow.ProductRepo.GetAll());
        }

        public ActionResult Create()
        {
            BindCategory();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                string folderPath = "~/Uploads/"; // your code goes here
                bool exists = Directory.Exists(Server.MapPath(folderPath));
                if (!exists)
                    Directory.CreateDirectory(Server.MapPath(folderPath));

                //saving file
                var fileName = Path.GetFileName(model.file.FileName);
                var path = Path.Combine(Server.MapPath(folderPath), fileName);
                model.file.SaveAs(path);

                model.ImageName = fileName;
                model.ImagePath = "/Uploads/" + fileName;

                Product data = new Product();
                data.ProductId = model.ProductId;
                data.Name = model.Name;
                data.UnitPrice = model.UnitPrice;
                data.CategoryId = model.CategoryId;
                data.Description = model.Description;
                data.ImagePath = model.ImagePath;
                data.ImageName = model.ImageName;

                _uow.ProductRepo.Add(data);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            BindCategory();
            return View();
        }

        public ActionResult Edit(int id)
        {
            BindCategory();
            Product data = _uow.ProductRepo.GetById(id);
            ProductViewModel model = new ProductViewModel();
            if (data != null)
            {
                model.ProductId = data.ProductId;
                model.Name = data.Name;
                model.UnitPrice = data.UnitPrice;
                model.CategoryId = data.CategoryId;
                model.Description = data.Description;
                model.ImagePath = data.ImagePath;
            }
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            try
            {
                if (model.file != null)
                {
                    //deleting previous one
                    var filePath = Server.MapPath(model.ImagePath);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    //uploading new one
                    var fileName = Path.GetFileName(model.file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    model.file.SaveAs(path);

                    model.ImageName = fileName;
                    model.ImagePath = "/Uploads/" + fileName;
                }
                Product data = new Product();
                data.ProductId = model.ProductId;
                data.Name = model.Name;
                data.UnitPrice = model.UnitPrice;
                data.CategoryId = model.CategoryId;
                data.Description = model.Description;
                data.ImagePath = model.ImagePath;
                if (model.ImageName != null)
                    data.ImageName = model.ImageName;

                _uow.ProductRepo.Modify(data);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            BindCategory();
            return View();
        }

        public ActionResult Delete(int id, string file)
        {
            _uow.ProductRepo.DeleteById(id);
            var filePath = Server.MapPath(file);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}