using SportBetApp.Common.Exceptions;
using SportBetApp.DTO;
using SportBetApp.Services;
using SportBetApp.Services.Contracts;
using SportBetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportBetApp.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var events = eventService.GetAll().Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                OddsForFirstTeam = e.OddsForFirstTeam,
                OddsForDraw = e.OddsForDraw,
                OddsForSecondTeam = e.OddsForSecondTeam,
                StartDate = e.StartDate
            });

            return View(events);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var events = eventService.GetAll().Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                OddsForFirstTeam = e.OddsForFirstTeam,
                OddsForDraw = e.OddsForDraw,
                OddsForSecondTeam = e.OddsForSecondTeam,
                StartDate = e.StartDate
            }).ToList();

            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var eventDto = new EventDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    OddsForFirstTeam = model.OddsForFirstTeam,
                    OddsForDraw = model.OddsForDraw,
                    OddsForSecondTeam = model.OddsForSecondTeam,
                    StartDate = model.StartDate
                };

                try
                {
                    this.eventService.Edit(eventDto);
                }
                catch(EventNotFoundException ex)
                {
                    return Json(new { success = false, responseText = "Error", data = new List<string>() { ex.Message } }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                
                return Json(new { success = true, responseText = $"Succsessfully editted event {model.Id} - {model.Name}" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = new List<string>();

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                
                return Json(new { success = false, responseText = "Error", data = errors }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                this.eventService.Delete(id);
            }
            catch (EventNotFoundException ex)
            {
                return Json(new { success = false, responseText = "Error", data = new List<string>() { ex.Message } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                NotFound();
            }

            return Json(new { success = true, responseText = $"Succsessfully deleted event with id ${id}" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            try
            {
                var model = this.eventService.Add();

                var viewModel = new EventViewModel()
                {
                    Id = model.Id,
                    StartDate = model.StartDate
                };

                return PartialView("AddPartial", viewModel);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View("Error");
        }


    }
}