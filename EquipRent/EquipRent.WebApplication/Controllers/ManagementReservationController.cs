using AutoMapper;
using EquipRent.Domain.Services.Abstract;
using EquipRent.WebApplication.Helpers;
using EquipRent.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipRent.WebApplication.Controllers
{
    public class ManagementReservationController : Controller
    {
        private IHireEquipmentService hireEquipmentService;

        private AuthenticationUserManager authenticationUserManager;

        public ManagementReservationController(IHireEquipmentService hireEquipmentService, AuthenticationUserManager authenticationUserManager)
        {
            this.hireEquipmentService = hireEquipmentService;
            this.authenticationUserManager = authenticationUserManager;
        }

        // GET: ManagementReservation
        public ActionResult Index()
        {
            var userReservations = hireEquipmentService.GetHires();
            //var equipments = hireEquipmentService.GetEquipments
            var model = new ReservationViewModel()
            {
                Equipment = Mapper.Map<List<EquipmentViewModel>>(userReservations)
            };

            return View(model);
        }

        public ActionResult EditReservation(int reservationId)
        {            
            var userReservations = hireEquipmentService.GetHires().First(x => x.Id == reservationId);
            var statusesToSelect = new List<SelectListItem>();
            statusesToSelect.Add(new SelectListItem() { Text = "Wypozyczony" });
            statusesToSelect.Add(new SelectListItem() { Text = "Zarezerwowany" });
            statusesToSelect.Add(new SelectListItem() { Text = "Do odbioru" });
            statusesToSelect.Add(new SelectListItem() { Text = "Oddany" });


            var model = new HireViewModel()
            {
                Hire = Mapper.Map<EquipmentViewModel>(userReservations),
                StateSelections = statusesToSelect
            };

            return View(model);
        }        

        [HttpPost]
        public ActionResult ConfirmReservation(HireViewModel model)
        {
            switch (model.SelectedStatus)
            {
                case  "Oddany":
                    hireEquipmentService.CancelReservation(model.Hire.Id);
                    break;
                default:
                    hireEquipmentService.EditReservation(model.Hire.Id, model.SelectedStatus);
                    break;
            }

            return RedirectToAction("Index");
        }
        // GET: ManagementReservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagementReservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementReservation/Create
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

        // GET: ManagementReservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagementReservation/Edit/5
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

        // GET: ManagementReservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagementReservation/Delete/5
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
