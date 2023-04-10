namespace Organigrama.Models.DTO
{
    /// <summary>
    /// Dto para el organigrama
    /// </summary>
    public class EmployeeOrgChartDTO
    {
        /// <summary>
        /// Identifcador del empleado
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
        /// Puesto del empleado
        /// </summary>
        public string Puesto { get; set; }

        /// <summary>
        /// Identificador de su jefe del empleado
        /// </summary>
        public int? BossId { get; set; }

        /// <summary>
        /// Nivel del puesto del empleado
        /// </summary>
        public int LevelId { get; set; }

        /// <summary>
        /// Empleado que tiene a cargo
        /// </summary>
        public IEnumerable<EmployeeOrgChartDTO> Employee { get; set; }
    }
}
