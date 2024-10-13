using Fiap.Api.DesastresNaturais.Data.Repository;
using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.Services;

namespace Fiap.Api.DesastresNaturais.Services
{
    public class DesastreNaturalService : IDesastreNaturalService
    {
        private readonly IDesastreNaturalRepository _repository;

        public DesastreNaturalService(IDesastreNaturalRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RegistrarDesastreNaturalModel> ListarDesastreNatural() => _repository.GetAll();

        public RegistrarDesastreNaturalModel ObterDesastreNaturalPorId(int id) => _repository.GetById(id);

        public void AdicionarDesastreNatural(RegistrarDesastreNaturalModel desastre) => _repository.Add(desastre);


        public void AtualizarDesastreNatural(RegistrarDesastreNaturalModel desastre) => _repository.Update(desastre);

        public void DeletarDesastreNatural(int id)
        {
            var desastre = _repository.GetById(id);
            if (desastre != null)
            {
                _repository.Delete(desastre);
            }
        }
    }
}
