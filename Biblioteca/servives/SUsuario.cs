using Biblioteca.bd;
using Capa_Entidad;
using System.Security.Claims;

namespace Biblioteca
{
    public class SUsuario : IUsuario
    {
        private readonly DBContext dBContext;
        public SUsuario(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Usuario LoggedUser(IEnumerable<Claim> identity)
        {
            string username = identity.FirstOrDefault(o => o.Type == ClaimTypes.Name).Value;
            var user = dBContext.Usuarios.Where(o => o.Username == username).FirstOrDefault();
            return user;
        }

        public Usuario Login(string username, string password)
        {
            var usuario = dBContext.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
            return usuario;
        }
    }
}
