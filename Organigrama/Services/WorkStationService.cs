using Microsoft.AspNetCore.Mvc.Rendering;
using Organigrama.Entities.Enums;
using Organigrama.Models;
using Organigrama.Repositories.Interfaces;
using Organigrama.Services.Interfaces;

namespace Organigrama.Services
{
    /// <summary>
    /// Implementa la interface asociado al servicio del puesto
    /// </summary>
    public class WorkStationService : IWorkStationService
    {
        private readonly IWorkStationRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">repositorio puesto</param>
        public WorkStationService(IWorkStationRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene un listado para el combo del puesto
        /// </summary>
        /// <returns>Retorna un listado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public IEnumerable<SelectListItem> GetCombo()
        {
            try
            {
                var combo = _repository.GetAll().Where(x => x.LevelId != Level.Level1).Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                }).ToList();

                return combo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
          
        }

        /// <summary>
        /// Listado de puestos
        /// </summary>
        /// <param name="filter">Propiedad enviado desde el UI para filtrar los registros</param>
        /// <param name="levelId">Propiedad enviado desde el UI para filtrar por el nivel</param>
        /// <param name="offset">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="limit">Propiedad enviado desde el UI que sirve para paginar los registros</param>
        /// <param name="sordBy">Propiedad enviado desde el UI para identificar por cual columna se ordenaran los registros</param>
        /// <param name="orderBy">Propiedad enviado desde el UI para ordenar los registros (asc o desc)</param>
        /// <returns>Retorna un listado de puesto</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        public ResultsViewModel<WorkStationListViewModel> GetList(string filter, int levelId, int offset, int limit, string sortBy, string orderBy)
        {
            try
            {
                var totalRecords = 0;
                var records = _repository.GetAll(filter, (Level)levelId, offset, limit, sortBy, orderBy, out totalRecords);

                var result = new ResultsViewModel<WorkStationListViewModel>()
                {
                    Items = records.Select(x => new WorkStationListViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        LevelId = (int)x.LevelId,
                        CreateBy = x.CreateBy,
                        CreationDate = x.CreationDate,
                        IsActive = x.IsActive,
                        ModificationDate = x.ModificationDate,
                        ModifiedBy = x.ModifiedBy
                    }),
                    Count = totalRecords
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message); 
            }
            
        }

    }
}
