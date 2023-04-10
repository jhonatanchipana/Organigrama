using Organigrama.Entities;
using Organigrama.Entities.Enums;
using Organigrama.Repositories.Interfaces;
using System.Linq.Dynamic.Core;

namespace Organigrama.Repositories
{
    /// <summary>
    /// Interface asociado a la obtención de datos de la entidad puesto del empleado
    /// </summary>
    public class WorkStationRepository : IWorkStationRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public WorkStationRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un listado de puesto
        /// </summary>
        /// <returns>Retorna una lista de puestos</returns>
        public IEnumerable<WorkStation> GetAll()
        {
            var records = _context.WorkStation.Where(c => c.IsActive);
            return records;
        }

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
        public IEnumerable<WorkStation> GetAll(string filter, Level levelId, int offset, int limit, string sortBy, string orderBy, out int totalRecords)
        {
            var records = (from a in _context.WorkStation
                           where
                            a.IsActive
                            && (string.IsNullOrEmpty(filter) 
                                || (a.Name.ToUpper().Contains(filter.ToUpper())
                                        || a.Description.ToUpper().Contains(filter.ToUpper())
                                    )
                                )
                            && (levelId == 0 || a.LevelId == levelId)
                            select a)
                           .OrderBy($"{sortBy} {orderBy}");

            totalRecords = records.Count();

            return records.Skip(offset).Take(limit);
        }

        /// <summary>
        /// Obtiene un Puesto
        /// </summary>
        /// <param name="id">Identificador del puesto</param>
        /// <returns>Retorna la entidad puesto</returns>
        public WorkStation GetById(int id)
        {
            var entity = _context.WorkStation.FirstOrDefault(c => c.Id == id);
            return entity;
        }

    }
}
