﻿using Logging;
using Nettbutikk.BLL;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryLogic categoryBLL;


        public CategoryController()
        {
            categoryBLL = new CategoryBLL();
        }

        public CategoryController(ICategoryLogic categoryBLL)
        {

            this.categoryBLL = categoryBLL;
            
        }
        
        public ActionResult Index()
        {

            var allCategories = categoryBLL.GetAllCategories();
            var categoryViews = new List<CategoryView>();

            foreach (var category in allCategories)
            {
                var categoryView = new CategoryView()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            }

            ViewBag.Categories = categoryViews;

            return View("ListCategory");
        }

        [HttpPost]
        public ActionResult Create(string Name)
        {

            if (!categoryBLL.AddCategory(Name))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not add the category to the database";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Category was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult Edit(string CategoryId, string CategoryName)
        {

            int categoryId;

            try
            {
                categoryId = Convert.ToInt32(CategoryId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid category id: " + CategoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!categoryBLL.UpdateCategory(categoryId, CategoryName))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not update the category";
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Title = "Success";
            ViewBag.Message = "Category was updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Delete(string CategoryId)
        {
            int categoryId;

            try
            {
                categoryId = Convert.ToInt32(CategoryId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + CategoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!categoryBLL.DeleteCategory(categoryId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not delete the category";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Category was deleted";
            return View("~/Views/Shared/Result.cshtml");
        }


        public ActionResult CreateCategory()
        {
            return View();
        }



        public ActionResult EditCategory(string categoryId)
        {

            System.Diagnostics.Debug.WriteLine("Got value: " + categoryId);

            int nCategoryId;

            try
            {
                nCategoryId = Convert.ToInt32(categoryId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid category id: " + categoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            var category = categoryBLL.GetCategory(nCategoryId);

            if (category == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Couldnt find a category with id: " + categoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            var categoryView = new CategoryView()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            ViewBag.Category = categoryView;

            return View();
        }


        public ActionResult DeleteCategory(string CategoryId)
        {

            System.Diagnostics.Debug.WriteLine("Got value: " + CategoryId);

            int nCategoryId;

            try
            {
                nCategoryId = Convert.ToInt32(CategoryId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid category id: " + CategoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            var category = categoryBLL.GetCategory(nCategoryId);

            if (category == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could find a category with the id: " + CategoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            var categoryView = new CategoryView()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            ViewBag.Category = categoryView;

            return View();
        }
    }
}