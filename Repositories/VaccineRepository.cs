using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VaccineManagement.Data;
using VaccineManagement.Models;

namespace VaccineManagement.Repositories
{
    public class VaccineRepository
    {
        private readonly VaccineContext _context;

        // inject the DbContext via DI
        public VaccineRepository(VaccineContext context)
        {
            _context = context;
        }

        public List<Vaccine> GetAll()
        {
            return _context.Vaccines
                           .AsNoTracking()
                           .OrderBy(v => v.Id)
                           .ToList();
        }

        public Vaccine? GetById(int id)
        {
            return _context.Vaccines.Find(id);
        }

        public void Add(Vaccine v)
        {
            _context.Vaccines.Add(v);
            _context.SaveChanges();
        }

        public void AddDoses(int id, int count)
        {
            var v = _context.Vaccines.Find(id);
            if (v != null)
            {
                v.TotalDosesReceived += count;
                v.TotalDosesLeft     += count;
                _context.SaveChanges();
            }
        }

        public void Update(Vaccine v)
        {
            _context.Vaccines.Update(v);
            _context.SaveChanges();
        }
    }
}
