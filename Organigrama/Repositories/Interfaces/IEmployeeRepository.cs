using Microsoft.EntityFrameworkCore;
using Organigrama.Entities;
using Organigrama.Entities.Enums;
using Organigrama.Models.DTO;

namespace Organigrama.Repositorys.Interfaces
{
    /// <summary>
    /// Interface asociado a la obtención de datos de la entidad empleados
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Registra un nuevo empleado
        /// </summary>
        /// <param name="entity">Entidad del empleado</param>
        /// <returns>Retorna el id del nuevo empleado</returns>
        int Create(Employee entity);

        /// <summary>
        /// Valida si el nro de documento ya existe
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <param name="nroDocument">Nro de documento del empleado</param>
        /// <returns>Retorna un boleano</returns>
        bool ValidateNroDocument(int id, string nroDocument);

        /// <summary>
        /// Listado de empleados
        /// </summary>
        /// <param name="filter">Filtra los registros del empleado (nombres completos, nroDocument, phone, email)</param>
        /// <param name="offset">Ignora n cantidad de registros</param>
        /// <param name="limit">Limita n cantidad de registros a devolver</param>
        /// <param name="sortBy">Indica la columna por el cual se ordenara</param>
        /// <param name="orderBy">Indica si se ordenara asc o desc </param>
        /// <param name="totalRecords">Indica la cantidad de registro total</param>
        /// <returns>Retorna un listado de DTO empleados</returns>
        IEnumerable<EmployeeGetAllDTO> GetAll(string filter, int offset, int limit, string sortBy, string orderBy, out int totalRecords);

        /// <summary>
        /// Obtiene un listado de empleados ordenados desc por nombre y apellidos
        /// </summary>
        /// <param name="filter">Filtra por el nombre completo del empleado</param>
        /// <param name="limit">Limita la cantidad de registros a devuelver</param>
        /// <returns>Retorna el listado de empleados</returns>
        IEnumerable<Employee> GetAll(string filter, int limit);

        /// <summary>
        /// Obtiene un listado de empleados necesario para el organigrama
        /// </summary>
        /// <returns>Retorna un listado de empleados</returns>
        IEnumerable<EmployeeOrgChartDTO> GetAllOrgChart();

        /// <summary>
        /// Obtiene el CEO, necesario para el organigrama
        /// </summary>
        /// <param name="LevelId">LevelId del puesto</param>
        /// <returns>Retorna un tuple del empleado y su puesto</returns>
        Tuple<Employee, WorkStation> GetCEO(Level LevelId);

        /// <summary>
        /// Valida si el puesto es menor o igual al puesto del jefe
        /// </summary>
        /// <param name="workStationId">Puesto del empleado</param>
        /// <param name="bossId">Identificador del jefe</param>
        /// <returns>Retorna un boleano</returns>
        bool ValidateWorkStationByBoss(int workStationId, int? bossId);
    }
}
