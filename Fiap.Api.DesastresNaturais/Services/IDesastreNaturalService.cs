using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.Services;

namespace Fiap.Api.DesastresNaturais.Services
{
    public interface IDesastreNaturalService
    {
        IEnumerable<RegistrarDesastreNaturalModel> ListarDesastreNatural();
        RegistrarDesastreNaturalModel ObterDesastreNaturalPorId(int id);
        void AdicionarDesastreNatural(RegistrarDesastreNaturalModel desastre);
        void AtualizarDesastreNatural(RegistrarDesastreNaturalModel desastre);
        void DeletarDesastreNatural(int id);

    }
}
