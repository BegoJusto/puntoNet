using puntoNet.BBLL.interfaces;
using System.Collections.Generic;
using puntoNet.Models;
using puntoNet.DAL;

namespace puntoNet.BBLL {
    public class EjemplarServiceImp : AutorService
    {
        private AutorRepository aR;

        public EjemplarServiceImp()
        {
            aR = new AutorRepositoryImp();
        }
        public Autor create(Autor autor)
        {
            return aR.create(autor);
        }

        public void delete(int codigoAutor)
        {
            aR.delete(codigoAutor);
        }

        public IList<Autor> getAll()
        {
            return aR.getAll();
        }

        public Autor getByID(int codigoAutor)
        {
            return aR.getById(codigoAutor);
        }

        public Autor update(Autor autor)
        {
            return aR.update(autor);
        }
    }
}