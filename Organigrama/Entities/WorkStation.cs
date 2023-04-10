using Organigrama.Entities.Enums;

namespace Organigrama.Entities
{
    /// <summary>
    /// Representa el puesto del empleado
    /// </summary>
    public class WorkStation : BaseEntity
    {
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
