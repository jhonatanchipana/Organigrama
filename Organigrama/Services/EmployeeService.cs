using Microsoft.AspNetCore.Mvc.Rendering;
using Organigrama.Common;
using Organigrama.Entities;
using Organigrama.Entities.Enums;
using Organigrama.Models;
using Organigrama.Repositories.Interfaces;
using Organigrama.Repositorys.Interfaces;
using Organigrama.Services.IServices;

namespace Organigrama.Services
{
    /// <summary>
    /// Implementa la interface asociado al servicio empleado
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IWorkStationRepository _repositoryWorkStation;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="repository">repositorio del empleado</param>
        /// <param name="repositoryWorkStation">repositorio del puesto</param>
        public EmployeeService(IEmployeeRepository repository,
            IWorkStationRepository repositoryWorkStation)
        {
            _repository = repository;
            _repositoryWorkStation = repositoryWorkStation;
        }

        /// <summary>
        /// Autocomplete del empleado
        /// </summary>
        /// <param name="filter">Propiedad enviado por el UI, permite filtrar los registros(nombre completo)</param>
        /// <param name="limit">Propiedad enviado por el UI, indica el cantidad de registros a mostrar</param>
        /// <returns>Retorna un listado de los empleados (id, nombre)</returns>
        public IEnumerable<SelectListItem> GetAutocomplete(string filter, int limit)
        {
            var records = _repository.GetAll(filter, limit).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = $"{x.Names} {x.LastNames}"
            });

            return records;
        }

        /// <summary>
        /// Listado de los empleados
        /// </summary>
        /// <param name="filter">Propiedad enviado desde el UI para filtrar los registros</param>
        /// <param name="offset">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="limit">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="sordBy">Propiedad enviado desde el UI para identificar por cual columna se ordenaran los registros</param>
        /// <param name="orderBy">Propiedad enviado desde el UI para ordenar los registros (asc o desc)</param>
        /// <returns>Retorna un listado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public ResultsViewModel<EmployeeViewModel> GetList(string filter, int offset, int limit, string sordBy, string orderBy)
        {
            try
            {
                var totalRows = 0;
                var records = _repository.GetAll(filter, offset, limit, sordBy, orderBy, out totalRows).ToList();

                var results = new ResultsViewModel<EmployeeViewModel>()
                {
                    Items  = records.Select(x => new EmployeeViewModel()
                    {
                        Id = x.Id,
                        Names = x.Names,
                        LastNames = x.LastNames,
                        NroDocument = x.NroDocumento,
                        BirthDate = x.BirthDate,
                        Phone = x.Phone,
                        Email = x.Email,
                        WorkStation = new WorkStationViewModel
                        {
                            Id= x.WorkStation.Id,
                            Name = x.WorkStation.Name,
                            Description = x.WorkStation.Description,
                            LevelId = (int)x.WorkStation.LevelId
                        },
                        CreateBy = x.CreateBy,
                        CreationDate = x.CreationDate,
                        ModifiedBy = x.ModifiedBy,
                        ModificationDate = x.ModificationDate,
                        IsActive = x.IsActive
                    }).ToList(),
                    Count = totalRows
                };

                return results;
            }
            catch(Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }            
            
        }        

        /// <summary>
        /// Obtiene los datos de los empleados para el organigrama
        /// </summary>
        /// <returns>Retorna el organigrama</returns>
        public OrgChartEmployeeViewModel GetOrganizationChart()
        {
            var IdCEO = _repository.GetCEO(Level.Level1);
            var results = _repository.GetAllOrgChart().Select(c => new OrgChartEmployeeViewModel()
            {
                Id = c.Id,
                Names = c.Names,
                LastNames = c.LastNames,
                LevelId = c.LevelId,
                WorkStationNames = c.Puesto,
                BossId = c.BossId
            })
            .ToList();

            foreach (var item in results)
            {
                var index = results.FindIndex(x => item.BossId != null && x.Id == item.BossId);

                if (index != -1)
                {
                    var boss = results
                            .Where(x => x.BossId != null && item.BossId == x.Id)
                            .FirstOrDefault();

                    results[index].Children.Add(item);
                }
                
            }

            return results.Where(x => x.Id == IdCEO.Item1.Id).FirstOrDefault();

        }

        /// <summary>
        /// Registra al empleado
        /// </summary>
        /// <param name="modelo">Propiedad enviado por el UI, indica los datos del Empleado</param>
        /// <returns>Retorna el id del empleado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public int Create(EmployeeCreateViewModel modelo)
        {
            var workStation = _repositoryWorkStation.GetById(modelo.WorkStationId);
            if (workStation is null) throw new Exception("El puesto de trabajo no existe");

            try
            {
                var entity = new Employee()
                {
                    Names = modelo.Names,
                    LastNames = modelo.LastNames,
                    BirthDate = modelo.BirthDate,
                    NroDocumento = modelo.NroDocument,
                    Phone = modelo.Phone,
                    Email = modelo.Email,
                    WorkStationId = modelo.WorkStationId,
                    BossId = modelo.BossId,
                    CreateBy = "admin",
                    CreationDate = DateTime.UtcNow.Date,
                    IsActive = true
                };

                return _repository.Create(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            
        }

        /// <summary>
        /// Validación para el nro de documento 
        /// </summary>
        /// <param name="id">Propiedad enviado por el UI, Id del empleado</param>
        /// <param name="nroDocument">Propiedad enviado por el UI, Nro de documento del empleado</param>
        /// <returns>Retorna un boleano</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public bool ValidateNroDocument(int id, string nroDocument)
        {
            try
            {
                return _repository.ValidateNroDocument(id, nroDocument);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        /// <summary>
        /// Valida´si el puesto del empleado es menor o igual al puesto del jefe
        /// </summary>
        /// <param name="workStation">Identificador del puesto del Empleado</param>
        /// <param name="bossId">Identificador del jefe</param>
        /// <returns>Retorna un boleano</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public bool ValidateWorkStationForBoss(int workStation, int? bossId)
        {
            try
            {
                return _repository.ValidateWorkStationByBoss(workStation, bossId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }            
        }
    }
}
