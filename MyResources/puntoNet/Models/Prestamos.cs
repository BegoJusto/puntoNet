using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace puntoNet.Models
{
    public class Prestamos
    {
        private int _codPrestamo;
        private DateTime _fRecogida;
        private DateTime _fDevolucion;
        private Usuario _usuario;
        private Ejemplar _ejemplar;

        public Prestamos()
        {
            /*
             * Diferencia entre new GUID() y GUID.NewGuid()
             * Ambas me dan una clave primaria unica
             * La primera genera el numero 0
             * La segunda genera un numero aleatorio, que es muy improbable que salga dos veces 
             */
            this._codPrestamo = -1;
            this._fRecogida = new DateTime();
            this._fDevolucion = new DateTime();
            this._ejemplar = new Ejemplar();
            this._usuario = new Usuario();
        }

        public int CodPrestamo
        {
            get
            {
                return _codPrestamo;
            }

            set
            {
                _codPrestamo = value;
            }
        }
        [Display(Name = "FRecodiga", ResourceType = typeof(MyResources.PrestamoResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.PrestamoResources),
            ErrorMessageResourceName = "FRecogidarequerido")]
        public DateTime FRecogida
        {
            get
            {
                return _fRecogida;
            }

            set
            {
                _fRecogida = value;
            }
        }
        [Display(Name = "FDevolucion", ResourceType = typeof(MyResources.PrestamoResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.PrestamoResources),
            ErrorMessageResourceName = "FDevolucionrequerido")]
        public DateTime FDevolucion
        {
            get
            {
                return _fDevolucion;
            }

            set
            {
                _fDevolucion = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }

        public Ejemplar Ejemplar
        {
            get
            {
                return _ejemplar;
            }

            set
            {
                _ejemplar = value;
            }
        }
    }
}