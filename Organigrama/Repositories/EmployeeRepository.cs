using Microsoft.EntityFrameworkCore;
using Organigrama.Entities;
using Organigrama.Entities.Enums;
using Organigrama.Models.DTO;
using Organigrama.Repositorys.Interfaces;
using System.Linq.Dynamic.Core;

namespace Organigrama.Repositorys
{
    /// <summary>
    /// Implementa la interface asociada al repositorio para la entidad empleado
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un listado de empleados necesario para el organigrama
        /// </summary>
        /// <returns>Retorna un listado de empleados</returns>
        public IEnumerable<EmployeeOrgChartDTO> GetAllOrgChart()
        {
            var records = (from a in _context.Employee
                           where a.IsActive
                           select new EmployeeOrgChartDTO
                           {
                               Id = a.Id,
                               Names = a.Names,
                               LastNames = a.LastNames,
                               Puesto = a.WorkStation.Name,
                               LevelId = (int)a.WorkStation.LevelId,
                               BossId = a.BossId
                           }).OrderByDescending(c => c.LevelId);

            return records;
        }

        /// <summary>
        /// Obtiene un listado de empleados ordenados desc por nombre y apellidos
        /// </summary>
        /// <param name="filter">Filtra por el nombre completo del empleado</param>
        /// <param name="limit">Limita la cantidad de registros a devuelver</param>
        /// <returns>Retorna el listado de empleados</returns>
        public IEnumerable<Employee> GetAll(string filter, int limit)
        {
            var records = (from a in _context.Employee                               
                           let names = a.Names + " " + a.LastNames
                           where a.IsActive &&
                                (string.IsNullOrEmpty(filter) || names.ToUpper().Contains(filter.ToUpper()))  
                           orderby a.Names , a.LastNames descending
                           select a
                           ).Take(limit);

            return records;
        }

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
        public IEnumerable<EmployeeGetAllDTO> GetAll(string filter, int offset, int limit, string sortBy, string orderBy, out int totalRecords)
        {
            var records = (from a in _context.Employee
                           join b in _context.WorkStation on a.WorkStation equals b
                           let employees = a.Names + " " + a.LastNames
                           where (string.IsNullOrEmpty(filter)
                                    || (filter.ToUpper().Contains(employees.ToUpper())
                                        || filter.ToUpper().Contains(a.NroDocumento.ToUpper())
                                        || filter.ToUpper().Contains(a.Phone.ToUpper())
                                        || filter.ToUpper().Contains(a.Email.ToUpper())
                                    )
                               )
                           select new EmployeeGetAllDTO
                           {
                               Id = a.Id,
                               Names = a.Names,
                               LastNames = a.LastNames,
                               BirthDate = a.BirthDate,
                               BossId = a.BossId,                              
                               Email = a.Email,
                               NroDocumento = a.NroDocumento,
                               Phone = a.Phone,
                               IsActive = a.IsActive,
                               CreateBy = a.CreateBy,
                               CreationDate = a.CreationDate,
                               ModifiedBy = a.ModifiedBy,
                               ModificationDate = a.ModificationDate,                                                            
                               WorkStation = new WorkStationGetAllDTO()
                               {
                                   Id = b.Id,
                                   Name = b.Name,
                                   Description = b.Description,
                                   LevelId = b.LevelId
                               }
                           })
                           .OrderBy($"{sortBy} {orderBy}");

            totalRecords = records.Count();

            return records.Skip(offset).Take(limit);
        }
       
        /// <summary>
        /// Registra un nuevo empleado
        /// </summary>
        /// <param name="entity">Entidad del empleado</param>
        /// <returns>Retorna el id del nuevo empleado</returns>
        public int Create(Employee entity)
        {
             _context.Add(entity);
            var id = _context.SaveChanges();
            var data = entity.Id;
            return id;
        }

        /// <summary>
        /// Valida si el nro de documento ya existe
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <param name="nroDocument">Nro de documento del empleado</param>
        /// <returns>Retorna un boleano</returns>
        public bool ValidateNroDocument(int id, string nroDocument)
        {
            var exists = _context.Employee
                    .Where(x => x.Id != id && x.NroDocumento.ToUpper().Equals(nroDocument.ToUpper()))
                    .Any();

            return !exists;
        }
        
        /// <summary>
        /// Obtiene el CEO, necesario para el organigrama
        /// </summary>
        /// <param name="LevelId">LevelId del puesto</param>
        /// <returns>Retorna un tuple del empleado y su puesto</returns>
        public Tuple<Employee, WorkStation> GetCEO(Level LevelId)
        {
            var employee = _context.Employee.Where(x => x.WorkStation.LevelId == LevelId).FirstOrDefault();

            var workStation = employee == null ? null : _context.Employee
                                                            .Where(x => x.WorkStation.LevelId == LevelId)
                                                            .Select(x => x.WorkStation)
                                                            .FirstOrDefault();
            return new (employee, workStation);
        }

        /// <summary>
        /// Valida si el puesto es menor o igual al puesto del jefe
        /// </summary>
        /// <param name="workStationId">Puesto del empleado</param>
        /// <param name="bossId">Identificador del jefe</param>
        /// <returns>Retorna un boleano</returns>
        public bool ValidateWorkStationByBoss(int workStationId, int? bossId)
        {
            if (workStationId <= 0 || bossId is null) return true;

            var levelOfWorKSation = _context.WorkStation.Where(c => c.Id == workStationId).Select(x => x.LevelId).FirstOrDefault();

            var result = (from a in _context.Employee
                       join b in _context.WorkStation on a.WorkStation equals b
                       where a.Id == bossId
                            && b.LevelId <= levelOfWorKSation
                        select a)
                        .Any();

            return result;
        }
    }
}
