namespace Fiap.Api.DesastresNaturais.ViewModel
{
    public class DesastreNaturalViewModel
    {
        public int DesastreNaturalId { get; set; }
        public DateTime Data { get; set; }
        public string? EnderecoDesastre { get; set; }
        public string? TipoDesastre { get; set; }
        public string? Observacao { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
