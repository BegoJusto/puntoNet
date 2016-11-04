using puntoNet.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using puntoNet.Models;
using puntoNet.DAL;

namespace puntoNet.BBLL
{
    
    public class UsuarioServiceImp : UsuarioService
    {
        private UsuarioRepository ur;
        public UsuarioServiceImp() {
            ur = new UsuarioRepositoryImp();
        }
        public Usuario create(Usuario usuario)
        {
            return ur.create(usuario);
        }

        public void delete(int codigoUsuario)
        {
            ur.delete(codigoUsuario);
        }

        public IList<Usuario> getAll()
        {
            return ur.getAll();
        }

        public Usuario getById(int codigoUsuario)
        {
            return ur.getById(codigoUsuario);
        }

        public Usuario update(Usuario usuario)
        {
            return ur.update(usuario);
        }

        public Usuario Login(Login model) {
            return ur.Login(model);
        }
    }
}