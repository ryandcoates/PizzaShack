using PizzaShack.Data;
using PizzaShack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaShack.Business
{
    public class SideService
    {
        private readonly PizzaContext _context;

        public SideService(PizzaContext context)
        {
            _context = context;
        }

        public void CreateSide(Side data)
        {
            _context.Sides.Add(data);
            _context.SaveChanges();
        }

        public Side GetSideById(int id)
        {
            return _context.Sides.Find(id);
        }

        public List<Side> GetSides()
        {
            return _context.Sides.ToList();
        }

        public Side UpdateSide(Side data)
        {
            _context.Sides.Update(data);
            _context.SaveChanges();
            return data;
        }
    }
}
