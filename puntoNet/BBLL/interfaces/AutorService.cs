using puntoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoNet.BBLL.interfaces
{
    public interface AutorService
    {
        Autor getByID(int codigoAutor);
        Autor create(Autor autor);
        Autor update(Autor autor);
        void delete(int codigoAutor);
        IList<Autor> getAll();
    }
}
