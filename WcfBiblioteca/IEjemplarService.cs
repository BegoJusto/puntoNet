using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEjemplar" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEjemplarService {

        Ejemplar getEjemplarById(int idEjemplar);
    }
    [DataContract]
    public class Ejemplar {
        string titulo = "";
        int numPaginas = 0;
        string isbn = "";
        string errorMessage = "";

        [DataMember]
        public string Titulo {
            get {return titulo;}
            set {titulo = value;}
        }
        [DataMember]
        public int NumPaginas {
            get {
                return numPaginas;
            }
            set {
                numPaginas = value;
            }
        }
        [DataMember]
        public string ISBN {
            get {
                return isbn;
            }
            set {
                isbn = value;
            }
        }
        [DataMember]
        public string ErrorMessage {
            get {
                return errorMessage;
            }
            set {
                errorMessage = value;
            }
        }

    }
}
