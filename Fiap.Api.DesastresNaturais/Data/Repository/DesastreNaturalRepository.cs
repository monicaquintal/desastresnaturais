using Fiap.Api.DesastresNaturais.Data.Contexts;
using Fiap.Api.DesastresNaturais.Data.Repository;
using Fiap.Api.DesastresNaturais.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Api.DesastresNaturais.Data.Repository
{
    public class DesastreNaturalRepository : IDesastreNaturalRepository
    {

        private readonly DatabaseContext _context;

        public DesastreNaturalRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<RegistrarDesastreNaturalModel> GetAll() => _context.DesastreNatural.AsNoTracking().ToList();

        public RegistrarDesastreNaturalModel GetById(int id)
        {
            return _context.DesastreNatural.Find(id);
        }

        public void Add(RegistrarDesastreNaturalModel desastre)
        {
            _context.DesastreNatural.Add(desastre);
            _context.SaveChanges();
        }

        public void Update(RegistrarDesastreNaturalModel desastre)
        {
            _context.Update(desastre);
            _context.SaveChanges();
        }

        public void Delete(RegistrarDesastreNaturalModel desastre)
        {
            _context.DesastreNatural.Remove(desastre);
            _context.SaveChanges();
        }
    }

}
