using AutoMapper;
using EquipRent.Domain.Services.Abstract;
using EquipRent.WebApplication.Helpers;
using EquipRent.WebApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipRent.WebApplication.Controllers
{
    public class ReservationController : Controller
    {
        private IHireEquipmentService hireEquipmentService;

        private AuthenticationUserManager authenticationUserManager;

        public ReservationController(IHireEquipmentService hireEquipmentService, AuthenticationUserManager authenticationUserManager)
        {
            this.hireEquipmentService = hireEquipmentService;
            this.authenticationUserManager = authenticationUserManager;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());
            var userReservations = hireEquipmentService.GetHires().Where(x => x.User.Id == currentUser.Id);
            //var equipments = hireEquipmentService.GetEquipments
            var model = new ReservationViewModel()
            {
                Equipment = Mapper.Map<List<EquipmentViewModel>>(userReservations)
            };
            

            return View(model);
        }
        [HttpPost]
        public ActionResult CancelReservation(int reservationId)
        {
            try
            {
                hireEquipmentService.CancelReservation(reservationId);
                TempData["message"] = "Udało się usunac rezerwacje";
            }
            catch (Exception e)
            {
                TempData["error"] = "Błąd przy usuwaniu rezerwacji";
            }
            return RedirectToAction("Index");
        }

    }
}