using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace puntoNet.Models
{
    public class Editorial
    {
        private int codEditorial;
        private string nombre;

        public Editorial()
        {
            this.codEditorial = -1;
            this.nombre = "";
        }

        public int CodEditorial
        {
            get
            {
                return codEditorial;
            }

            set
            {
                codEditorial = value;
            }
        }
        [Display(Name = "Editorial", ResourceType = typeof(MyResources.EditorialResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EditorialResources),
            ErrorMessageResourceName = "Editorialrequerido")]
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
    }
}