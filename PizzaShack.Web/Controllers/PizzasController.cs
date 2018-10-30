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
    public class PizzasController : Controller
    {
        private readonly PizzaService _context;

        public PizzasController(PizzaService context)
        {
            _context = context;
        }

        // GET: Pizzas
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.GetPizzas());
        }

        // GET: Pizzas/Details/5
        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {

            var pizza = _context.GetPizzaById(id);

            return View(pizza);
        }

        // GET: Pizzas/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.CreatePizza(pizza);
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public IActionResult Edit(int id)
        {

            var pizza = _context.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price")] Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.UpdatePizza(pizza);


                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }
    }
}
