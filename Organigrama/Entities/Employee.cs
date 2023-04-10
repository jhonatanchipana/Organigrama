using Microsoft.EntityFrameworkCore;
using Organigrama.Entities.Enums;

namespace Organigrama.Entities
{
    /// <summary>
    /// Representa al empleado
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Nombre del empleado
        /// </summary>       
        public string Names { get; set; }

        /// <summary>
        /// Apellido del empleado
        /// </summary>
        public string LastNames { get; set; }

        /// <summary>
        /// Dni del empleadod
        /// </summary>
        public string NroDocumento { get; set; }

        /// <summary>
        /// Fecha de Nacimiento del empleado
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Celular del empleado
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Correo electrónico del empleado
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Identificador del Puesto del empleado
        /// </summary>
        public int WorkStationId { get; set; }

        /// <summary>
        /// Clave foreanea asociado al Puesto del Empleado
        /// </summary>
        public WorkStation WorkStation { get; set; }        

        /// <summary>
        /// Indica el id del Jefe (Empleado)
        /// </summary>
        public int? BossId { get; set; }
    }
}
