using Fiap.Api.DesastresNaturais.Models;

namespace Fiap.Api.DesastresNaturais.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}