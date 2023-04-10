using Microsoft.AspNetCore.Mvc;
using Organigrama.Services.Interfaces;

namespace Organigrama.Controllers
{
    /// <summary>
    /// Controller del puesto
    /// </summary>
    public class WorkStationController : Controller
    {
        private readonly IWorkStationService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Interface del servicio del puesto</param>
        public WorkStationController(IWorkStationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Acción que muesta la vista del listado
        /// </summary>
        /// <returns>Retorna la vista</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Acción obtiene el listado de los puestos
        /// </summary>
        /// <param name="filter">Propiedad enviado desde UI, para filtrar los registros</param>
        /// <param name="levelId">Propiedad enviado desde UI, para filtrar por el nivel del puesto</param>
        /// <param name="offset">Propiedad enviado desde UI, para paginar los registros </param>
        /// <param name="limit">Propiedad enviado desde UI, para paginar los registros</param>
        /// <param name="sortBy">Propiedad enviado desde UI, para identificar por cual columna se ordenara los registros</param>
        /// <param name="orderBy">Propiedad enviado desde UI, para ordenar asc o desc</param>
        /// <returns>Retorna el listodo de los puestos</returns>
        public IActionResult GetList(string filter, int levelId, int offset, int limit, string sortBy, string orderBy)
        {
            var results = _service.GetList(filter, levelId, offset, limit, sortBy, orderBy);
            return Json(results);
        }
    }
}
