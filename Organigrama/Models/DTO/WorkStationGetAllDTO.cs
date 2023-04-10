using Organigrama.Entities.Enums;

namespace Organigrama.Models.DTO
{
    /// <summary>
    /// DTO para el listadod del puesto del empleado
    /// </summary>
    public class WorkStationGetAllDTO
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
        public Level LevelId { get; set; }

    }
}
