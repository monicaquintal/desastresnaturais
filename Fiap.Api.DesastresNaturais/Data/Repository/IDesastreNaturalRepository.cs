using System.Collections.Generic;
using Fiap.Api.DesastresNaturais.Models;

namespace Fiap.Api.DesastresNaturais.Data.Repository
{
    public interface IDesastreNaturalRepository
    {
        IEnumerable<RegistrarDesastreNaturalModel> GetAll();
        RegistrarDesastreNaturalModel GetById(int id);
        void Add(RegistrarDesastreNaturalModel desastre);
        void Update(RegistrarDesastreNaturalModel desastre);
        void Delete(RegistrarDesastreNaturalModel desastre);
    }
}