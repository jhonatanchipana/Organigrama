using Microsoft.AspNetCore.Mvc.Rendering;
using Organigrama.Common;
using Organigrama.Entities.Enums;
using Organigrama.Services.Interfaces;

namespace Organigrama.Services
{
    /// <summary>
    /// Implementa la interface asociado al servicio level
    /// </summary>
    public class LevelService : ILevelService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LevelService()
        {

        }

        /// <summary>
        /// Obtiene un listado para el combo de los niveles
        /// </summary>
        /// <returns>Retorna un listdo de los niveles</returns>
        public IEnumerable<SelectListItem> GetCombo()
        {
            var combo = EnumManager.EnumToList<Level>().Select(c => new SelectListItem()
            {
                Value = c.ToString(),
                Text = EnumManager.GetEnumDescription(c)
            });
            return combo;
        }
    }
}
