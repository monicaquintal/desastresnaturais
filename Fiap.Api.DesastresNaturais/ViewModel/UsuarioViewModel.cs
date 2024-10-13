namespace Fiap.Api.DesastresNaturais.ViewModel
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? EnderecoUsuario { get; set; }
    }
}
