
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace puntoNet.Models {

    public class ChangePasswordModel {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordActual")]
        public string OldPassword {get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe de tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword {get; set;}

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmaPassword")]
        [Compare("Password", ErrorMessage = "La constraseña y la confirmación no coinciden.")]
        public string ConfirmPassword {get; set;}
    }

    public class Login {
        [Required]
        [Display(Name = "NombreUsuario")]
        public string Alias {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pass {get; set;}

        [Display(Name = "Recordarme")]
        public bool Recordar { get; set;}
    }

    public class RegisterModel {
        [Required]
        [Display(Name = "Nombre")]
        public string UserName {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email {get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe de tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmaPassword")]
        [Compare("Password", ErrorMessage = "La constraseña y la confirmación no coinciden.")]
        public string ConfirmPassword {get; set;}
    }
}