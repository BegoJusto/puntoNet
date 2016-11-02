using puntoNet.BBLL;
using puntoNet.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Ejemplar" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Ejemplar.svc o Ejemplar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EjemplarService: IEjemplarService {
        public Ejemplar getEjemplarById(int idEjemplar) {

            Ejemplar ejemplar = null;
            puntoNet.BBLL.interfaces.EjemplarService aS = new EjemplarServiceImp();
            puntoNet.Models.Ejemplar ejemAux = aS.getEjemplarById(idEjemplar);
            ejemplar = new Ejemplar();
            if (ejemAux == null) {
                ejemplar.ErrorMessage = "El Ejemplar no existe";
                throw new Exception();
            }
            else
            {
                ejemplar.Titulo = ejemAux.Titulo;
                ejemplar.ISBN = ejemAux.ISBN;
            }


            return ejemplar;
        }
    }
}
