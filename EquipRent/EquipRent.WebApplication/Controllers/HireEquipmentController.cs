using AutoMapper;
using EquipRent.Domain.Services.Abstract;
using EquipRent.WebApplication.Helpers;
using EquipRent.WebApplication.Models;
using FluentNHibernate.Testing.Values;
using Microsoft.AspNet.Identity;
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

        private AuthenticationUserManager authenticationUserManager;

        public HireEquipmentController(IHireEquipmentService hireEquipmentService, AuthenticationUserManager authenticationUserManager)
        {
            this.hireEquipmentService = hireEquipmentService;
            this.authenticationUserManager = authenticationUserManager;
        }
        // GET: HireEquipment
        public ActionResult Index()
        {
            var model = Mapper.Map<List<ModelViewModel>>(hireEquipmentService.GetModels());
            foreach (var element in model)
            {
                var listofequipments = hireEquipmentService.GetEquipments(element.Id);
                element.NumberOfEquipments = listofequipments.Count;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int modelId)
        {
            return RedirectToAction("GetEquipment", new { modelId });
        }

        [HttpGet]
        public ActionResult GetEquipment(int modelId)
        {
            var model = new HireEquipmentViewModel();
            {
                model.Equipments = Mapper.Map<List<EquipmentViewModel>>(hireEquipmentService.GetEquipments(modelId));
                model.EquipmentOptions = Mapper.Map<List<SelectListItem>>(hireEquipmentService.GetEquipments(modelId).Select(x => x.Id));
                model.Model = Mapper.Map<ModelViewModel>(hireEquipmentService.GetModels().First(x => x.Id == modelId));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult GetEquipment(HireEquipmentViewModel model)
        {
            var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());

            try
            {
                hireEquipmentService.hireEquipment(model.SelectEquipment, currentUser);
                //bookTableService.ReserveTable(tableId, startDate, endDate, currentUser);
                TempData["message"] = "Udało się zarezerwować stolik";
            }
            catch (Exception e)
            {
                TempData["error"] = "Błąd przy zapisie rezerwacji";
            }

            return RedirectToAction("Index");
        }
        
        //public ActionResult HireEquipment(int equipmentId, string someString)
        //{
        //    var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());

        //    try
        //    {
        //        hireEquipmentService.hireEquipment(equipmentId, currentUser);
        //        //bookTableService.ReserveTable(tableId, startDate, endDate, currentUser);
        //        TempData["message"] = "Udało się zarezerwować stolik";
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["error"] = "Błąd przy zapisie rezerwacji";
        //    }

        //    return RedirectToAction("Index");
        //}
        
    }
}
