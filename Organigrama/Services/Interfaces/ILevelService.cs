using Microsoft.AspNetCore.Mvc.Rendering;

namespace Organigrama.Services.Interfaces
{
    /// <summary>
    /// Interface asociado al servicio del Nivel
    /// </summary>
    public interface ILevelService
    {
        /// <summary>
        /// Obtiene un listado para el combo de los niveles
        /// </summary>
        /// <returns>Retorna un listdo de los niveles</returns>
        IEnumerable<SelectListItem> GetCombo();
    }
}
