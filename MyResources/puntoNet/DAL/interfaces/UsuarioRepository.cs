using puntoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace puntoNet.DAL
{
    public interface UsuarioRepository
    {
        IList<Usuario> getAll();

        Usuario create(Usuario usuario);

        void delete(int id);

        Usuario update(Usuario usuario);

        Usuario getById(int id);

        Usuario Login(Login model);

    }
}