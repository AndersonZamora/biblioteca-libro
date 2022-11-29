using Capa_Entidad;
using System.Security.Claims;

namespace Biblioteca
{
    public interface IUsuario
    {
        Usuario Login(string username, string password);
        Usuario LoggedUser(IEnumerable<Claim> identity);
    }
}
