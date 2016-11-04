using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace puntoNet.Models
{
    public class Usuario {
        private int _codUsuario;
        private string _nombre;
        private string _apellidos;
        private string _alias;
        private string _pass;
        private DateTime? _fNacimiento;
        private string _dni;
        private string _email;
        private IList<Prestamos> _prestamos;


        public Usuario() {
            this._codUsuario = -1;
            this._nombre = "";
            this._apellidos = "";
            this._alias = "";
            this._pass = "";
            _fNacimiento = null;
            this._dni = "";
            this._email = "";
            this.Prestamos = null;
        }

        public int CodUsuario {
            get {
                return _codUsuario;
            }

            set {
                _codUsuario = value;
            }
        }
        [Display(Name = "Nombre", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Nombrerequerido")]
        public string Nombre {
            get {
                return _nombre;
            }

            set {
                _nombre = value;
            }
        }
        [Display(Name = "Apellidos", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Apellidosrequerido")]
        public string Apellidos {
            get {
                return _apellidos;
            }

            set {
                _apellidos = value;
            }
        }
        [Display(Name = "Nick", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Nickrequerido")]
        public string Alias {
            get {
                return _alias;
            }

            set {
                _alias = value;
            }
        }
        [Display(Name = "Password", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Passwordrequerido")]
        public string Pass {
            get {
                return _pass;
            }

            set {
                _pass = value;
            }
        }
        [DisplayFormat(DataFormatString ="{dd/MM/yyyy}")]
        [Display(Name = "FNacimiento", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "FNacimientorequerido")]
        public DateTime? FNacimiento
        {
            get
            {
                return _fNacimiento;
            }

            set
            {
                _fNacimiento = value;
            }
        }
        [Display(Name = "Dni", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Dnirequerido")]
        public string Dni
        {
            get
            {
                return _dni;
            }

            set
            {
                _dni = value;
            }
        }
        [Display(Name = "Email", ResourceType = typeof(MyResources.UsuarioResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.UsuarioResources),
            ErrorMessageResourceName = "Emailrequerido")]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
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