namespace Organigrama.Models
{
    /// <summary>
    /// Representa la clase para el organigrama de los empleados
    /// </summary>
    public class OrgChartEmployeeViewModel
    {
        /// <summary>
        /// Identificador del empleado
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
        /// Nombre del puesto del empleado
        /// </summary>
        public string WorkStationNames { get; set; }

        /// <summary>
        /// Nivel del puesto del empleado
        /// </summary>
        public int LevelId { get; set; }

        /// <summary>
        /// Identificador del jefe del empleado
        /// </summary>
        public int? BossId { get; set; }

        /// <summary>
        /// Empleados a cargo que tiene el empleado
        /// </summary>
        public List<OrgChartEmployeeViewModel> Children { get; set; } = new List<OrgChartEmployeeViewModel>();
    }
}
