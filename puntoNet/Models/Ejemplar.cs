using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace puntoNet.Models
{
    /*
     * Como la herencia y la implementacion se hace con los dos puntos, si queremos heradar e implementar,
     *  en primer lugar pondremos la herencia y posteriormente pondremos las implementaciones separadas por un ' ' 
     */
    public class Ejemplar : Libro
    {
        private int _codEjemplar;
        private string _iSBN;
        private int _numPaginas;
        private DateTime _fPublicacion;
        //Hacemos una lista de prestamos porque presuponemos que uqeremos un historial de prestamos de dicho ejemplar
        private IList<Prestamos> _prestamos;
        private Editorial _editorial;

        public Ejemplar()
        {
            this._codEjemplar = -1;
            this._iSBN = "";
            this._numPaginas = 0;
            this._fPublicacion = new DateTime();
            this._prestamos = new List<Prestamos>();
            this._editorial = new Editorial();
        }

        public int CodEjemplar
        {
            get
            {
                return _codEjemplar;
            }

            set
            {
                _codEjemplar = value;
            }
        }
        [Display(Name = "ISBN", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "ISBNrequerido")]
        public string ISBN
        {
            get
            {
                return _iSBN;
            }

            set
            {
                _iSBN = value;
            }
        }
        [Display(Name = "Numeropaginas", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "Numeropaginasrequerido")]
        public int NumPaginas
        {
            get
            {
                return _numPaginas;
            }

            set
            {
                _numPaginas = value;
            }
        }
        [Display(Name = "FPublicacion", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "FPublicacionrequerido")]
        public DateTime FPublicacion
        {
            get
            {
                return _fPublicacion;
            }

            set
            {
                _fPublicacion = value;
            }
        }

        public Editorial Editorial
        {
            get
            {
                return _editorial;
            }

            set
            {
                _editorial = value;
            }
        }

        public IList<Prestamos> Prestamos
        {
            get
            {
                return _prestamos;
            }

            set
            {
                _prestamos = value;
            }
        }
    }
}