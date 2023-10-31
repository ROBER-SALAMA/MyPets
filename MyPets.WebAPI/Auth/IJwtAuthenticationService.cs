using SysMyPets.EntidadesDeNegocio;

namespace MyPets.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
