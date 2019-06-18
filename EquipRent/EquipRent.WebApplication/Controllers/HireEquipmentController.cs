using AutoMapper;
using EquipRent.Domain.Services.Abstract;
using EquipRent.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipRent.WebApplication.Controllers
{
    public class HireEquipmentController : Controller
    {
        private IHireEquipmentService hireEquipmentService;

        public HireEquipmentController(IHireEquipmentService hireEquipmentService)
        {
            this.hireEquipmentService = hireEquipmentService;
        }
        // GET: HireEquipment
        public ActionResult Index()
        {
            var model = Mapper.Map<List<ModelViewModel>>(hireEquipmentService.GetModels());
            return View(model);
        }

        // GET: HireEquipment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HireEquipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HireEquipment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HireEquipment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HireEquipment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HireEquipment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HireEquipment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
