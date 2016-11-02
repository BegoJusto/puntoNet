using puntoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoNet.DAL.interfaces {
    interface FotoRepository {

        IList<Foto> getAll();

        void delete(int id);

        Foto create(Foto foto);

        Foto update(Foto foto);

        Foto getById(int id);

    }
}
