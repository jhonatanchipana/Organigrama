using Organigrama.Entities;
using Organigrama.Entities.Enums;

namespace Organigrama.Repositories.Interfaces
{
    public interface IWorkStationRepository
    {
        /// <summary>
        /// Obtiene un listado de puesto
        /// </summary>
        /// <returns>Retorna una lista de puestos</returns>
        IEnumerable<WorkStation> GetAll();

        /// <summary>
        /// Obtiene el listado de los puestos
        /// </summary>
        /// <param name="filter">Filtra los registros de los puestos (name, description)</param>
        /// <param name="levelId">Filtra por el nivel del puesto</param>
        /// <param name="offset">Ignora n cantidad de registros</param>
        /// <param name="limit">Limita n cantidad de registros a devolver</param>
        /// <param name="sortBy">Indica la columna por el cual se ordenara</param>
        /// <param name="orderBy">Indica si se ordenara asc o desc </param>
        /// <param name="totalRecords">Indica la cantidad de registro total</param>
        /// <returns>Retorna un listado de los puestos</returns>
        IEnumerable<WorkStation> GetAll(string filter, Level levelId, int offset, int limit, string sortBy, string orderBy, out int totalRecords);

        /// <summary>
        /// Obtiene un Puesto
        /// </summary>
        /// <param name="id">Identificador del puesto</param>
        /// <returns>Retorna la entidad puesto</returns>
        WorkStation GetById(int id);
    }
}
