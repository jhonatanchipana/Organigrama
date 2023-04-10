using Organigrama.Entities;

namespace Organigrama.Models.DTO
{
    /// <summary>
    /// Dto para el listado del empleado
    /// </summary>
    public class EmployeeGetAllDTO
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        public int Id { get; set; }

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
        /// Clave foreanea asociado al Puesto del Empleado
        /// </summary>
        public WorkStationGetAllDTO WorkStation { get; set; }

        /// <summary>
        /// Indica el id del Jefe (Empleado)
        /// </summary>
        public int? BossId { get; set; }        

        /// <summary>
        /// Usuario quien creo el registro
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Ultimo usuario quien modifico el registro
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ultima fecha de modificacion
        /// </summary>
        public DateTime? ModificationDate { get; set; }

        /// <summary>
        /// Indica si esta activo o inactivo
        /// </summary>
        public bool IsActive { get; set; }
    }
}
