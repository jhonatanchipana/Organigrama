using Microsoft.AspNetCore.Mvc.Rendering;
using Organigrama.Models;

namespace Organigrama.Services.Interfaces
{
    /// <summary>
    /// Interface asociado al servicio del puesto
    /// </summary>
    public interface IWorkStationService
    {
        /// <summary>
        /// Obtiene un listado para el combo del puesto
        /// </summary>
        /// <returns>Retorna un listado</returns>
        /// <exception cref="Exception">Si se produce una error se genera una excepción</exception>
        IEnumerable<SelectListItem> GetCombo();

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
        ResultsViewModel<WorkStationListViewModel> GetList(string filter, int levelId, int offset, int limit, string sortBy, string orderBy);
    }
}
