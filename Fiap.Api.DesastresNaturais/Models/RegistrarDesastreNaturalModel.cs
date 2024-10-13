namespace Fiap.Api.DesastresNaturais.Models;

public class RegistrarDesastreNaturalModel
{
    public int DesastreNaturalId { get; set; }
    public DateTime Data { get; set; }

    public string? EnderecoDesastre { get; set; }

    public string? TipoDesastre { get; set; }

    public string? Observacao { get; set; }

    // Relacionamento com Usuario
    public UsuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
    
}
