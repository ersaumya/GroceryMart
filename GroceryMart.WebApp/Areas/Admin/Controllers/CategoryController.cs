using GroceryMart.BAL;
using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMart.WebApp.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uow) : base(uow)
        {
        }

        public ActionResult Index()
        {
            return View(_uow.CategoryRepo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                _uow.CategoryRepo.Add(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                return View(_uow.CategoryRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                model.UpdatedDate = DateTime.Now;
                _uow.CategoryRepo.Modify(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _uow.CategoryRepo.DeleteById(id);
            _uow.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
