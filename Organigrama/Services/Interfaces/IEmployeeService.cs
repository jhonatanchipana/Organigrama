using Microsoft.AspNetCore.Mvc.Rendering;
using Organigrama.Entities;
using Organigrama.Models;

namespace Organigrama.Services.IServices
{
    /// <summary>
    /// Interface asociado al servicio del empleado
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Registra al empleado
        /// </summary>
        /// <param name="modelo">Propiedad enviado por el UI, indica los datos del Empleado</param>
        /// <returns>Retorna el id del empleado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        int Create(EmployeeCreateViewModel modelo);

        /// <summary>
        /// Validación para el nro de documento 
        /// </summary>
        /// <param name="id">Propiedad enviado por el UI, Id del empleado</param>
        /// <param name="nroDocument">Propiedad enviado por el UI, Nro de documento del empleado</param>
        /// <returns>Retorna un boleano</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        bool ValidateNroDocument(int id, string nroDocument);

        /// <summary>
        /// Autocomplete del empleado
        /// </summary>
        /// <param name="filter">Propiedad enviado por el UI, permite filtrar los registros(nombre completo)</param>
        /// <param name="limit">Propiedad enviado por el UI, indica el cantidad de registros a mostrar</param>
        /// <returns>Retorna un listado de los empleados (id, nombre)</returns>
        IEnumerable<SelectListItem> GetAutocomplete(string filter, int limit);

        /// <summary>
        /// Listado de los empleados
        /// </summary>
        /// <param name="filter">Propiedad enviado desde el UI para filtrar los registros</param>
        /// <param name="offset">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="limit">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="sordBy">Propiedad enviado desde el UI para identificar por cual columna se ordenaran los registros</param>
        /// <param name="orderBy">Propiedad enviado desde el UI para ordenar los registros</param>
        /// <returns>Retorna un listado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        ResultsViewModel<EmployeeViewModel> GetList(string filter, int offset, int limit, string sordBy, string orderBy);

        /// <summary>
        /// Obtiene los datos de los empleados para el organigrama
        /// </summary>
        /// <returns>Retorna el organigrama</returns>
        OrgChartEmployeeViewModel GetOrganizationChart();

        /// <summary>
        /// Valida´si el puesto del empleado es menor o igual al puesto del jefe
        /// </summary>
        /// <param name="workStation">Identificador del puesto del Empleado</param>
        /// <param name="bossId">Identificador del jefe</param>
        /// <returns>Retorna un boleano</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        bool ValidateWorkStationForBoss(int workStation, int? bossId);
    }
}
