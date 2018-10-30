using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaShack.Business;
using PizzaShack.Data;
using PizzaShack.Entities;

namespace PizzaShack.Web.Controllers
{
    public class SidesController : Controller
    {
        private readonly SideService _context;

        public SidesController(SideService context)
        {
            _context = context;
        }

        // GET: Pizzas
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.GetSides());
        }

        // GET: Sides/Details/5
        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {

            var side = _context.GetSideById(id);

            return View(side);
        }

        // GET: Sides/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price")] Side side)
        {
            if (ModelState.IsValid)
            {
                _context.CreateSide(side);
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        // GET: Pizzas/Edit/5
        public IActionResult Edit(int id)
        {

            var side = _context.GetSideById(id);
            if (side == null)
            {
                return NotFound();
            }
            return View(side);
        }

        // POST: Sides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price")] Side side)
        {
            if (id != side.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.UpdateSide(side);


                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }
    }
}
