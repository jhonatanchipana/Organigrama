using Organigrama.Entities.Enums;
using Organigrama.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Organigrama.Models
{
    /// <summary>
    /// Representa al empleado para el registro
    /// </summary>
    public class EmployeeCreateViewModel
    {
        /// <summary>
        /// Nombre del Empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(120 , ErrorMessage = "No puede ser mayor a {0} caracteres")]
        [Display(Name = "Nombres")]
        public string Names { get; set; }

        /// <summary>
        /// Apellido del empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(120, ErrorMessage = "No puede ser mayor a {0} caracteres")]
        [Display(Name = "Apellidos")]
        public string LastNames { get; set; }

        /// <summary>
        /// Número del documento (dni)
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "El campo debe tener {1} caracteres")]
        [Remote(action: "ValidateNroDocument", controller: "Employee",  ErrorMessage = "El Dni ya ha sido registrado")]
        [Display(Name = "Dni")]
        public string NroDocument { get; set; }

        /// <summary>
        /// Fecha de Nacimiento del empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"));

        /// <summary>
        /// Celular del empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "No puede ser menor a 9 dígitos")]
        [Phone]
        [Display(Name = "Celular")]
        public string Phone { get; set; }

        /// <summary>
        /// Correo electrónico del empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(240, ErrorMessage = "No puede ser mayor a {0} caracteres")]
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo válido")]
        public string Email { get; set; }

        /// <summary>
        /// Identificador del Puesto del empleado
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Puesto")]
        [Remote(action: "ValidateWorkStationForBoss", controller: "Employee", AdditionalFields = nameof(BossId))]
        public int WorkStationId { get; set; }

        /// <summary>
        /// Identificador del jefe (id empleado)
        /// </summary>
        [Display(Name = "Jefe")]
        [Remote(action: "ValidateWorkStationForBoss", controller: "Employee", AdditionalFields = nameof(WorkStationId))]
        public int? BossId { get; set; }

        /// <summary>
        /// Listado de los Puestos
        /// </summary>
        public IEnumerable<SelectListItem> WorkStations { get; set; }
       
    }
}
