using puntoNet.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using puntoNet.Models;
using puntoNet.DAL.interfaces;

namespace puntoNet.BBLL {
    public class FotoServiceImp : FotoService {

        private FotoRepository fR;
        public Foto create(Foto foto) {
            return fR.create(foto);
        }

        public void delete(int idFoto) {
            fR.delete(idFoto);
        }

        public IList<Foto> getAll() {
            return fR.getAll();
        }

        public Foto getByID(int idFoto) {
            return fR.getById(idFoto);
        }

        public Foto update(Foto foto) {
            return fR.update(foto);
        }
    }
}