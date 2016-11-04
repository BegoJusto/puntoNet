using puntoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoNet.BBLL.interfaces
{
    interface PrestamosService
    {
        Prestamos getById(int codigoPrestamos);

        Prestamos create(Prestamos prestamo);

        Prestamos update(Prestamos prestamo);

        IList<Prestamos> getAll();
    }
}
