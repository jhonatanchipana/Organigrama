using Organigrama.Entities.Enums;

namespace Organigrama.Models
{
    /// <summary>
    /// Representa el listado de los puestos
    /// </summary>
    public class WorkStationListViewModel
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del Puesto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Describe el puesto del trabajo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nivel al que pertenece el Puesto
        /// </summary>
        public int LevelId { get; set; }       

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
