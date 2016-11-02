using puntoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoNet.BBLL.interfaces
{
    interface UsuarioService
    {
        Usuario getById(int codigoUsuario);

        Usuario create(Usuario usuario);

        Usuario update(Usuario usuario);

        void delete(int codigoUsuario);

        Usuario Login(Login model);

        IList<Usuario> getAll();
    }
}
