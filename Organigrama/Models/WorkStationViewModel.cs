using Organigrama.Entities.Enums;

namespace Organigrama.Models
{
    /// <summary>
    /// Representa el puesto para el listado de cada empleado
    /// </summary>
    public class WorkStationViewModel
    {
        /// <summary>
        /// Identificador del puesto del empleado
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
    }
}
