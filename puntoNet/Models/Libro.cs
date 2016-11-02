using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace puntoNet.Models
{
    public class Libro
    {
        private int _codLibro;
        private string _titulo;
        private Autor autor;

        public Libro()
        {
            this._codLibro = -1;
            this._titulo = "";
            this.Autor = new Autor();
        }

        public int CodLibro
        {
            get
            {
                return _codLibro;
            }

            set
            {
                _codLibro = value;
            }
        }
        [Display(Name = "Titulo", ResourceType = typeof(MyResources.LibroResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.LibroResources),
            ErrorMessageResourceName = "Titulorequerido")]
        public string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                _titulo = value;
            }
        }

        public Autor Autor
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }
    }
}