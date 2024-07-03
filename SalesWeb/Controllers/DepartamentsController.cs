using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;
using SalesWeb.Services.Exceptions;

namespace SalesWeb.Controllers
{
    
    public class DepartamentsController : Controller
    {
        private readonly DepartamentService _service;

        public DepartamentsController(DepartamentService service)
        {
           _service = service;   
        }
        public async Task<IActionResult> Index()
        {
            var list = await _service.FindAllAsync();
            return View(list);
        }
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departament departament)
        {
            if(!ModelState.IsValid)
           {
              return View(departament);
           }
             _service.Isert(departament);

             return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _service.FindiByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _service.FindiByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departament> departaments = await _service.FindAllAsync();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Departament departament)
        {
            if(!ModelState.IsValid)
           {
              return View(departament);
           }

            if (id != departament.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(departament);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundExceptoion)
            {

                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }

    }
}