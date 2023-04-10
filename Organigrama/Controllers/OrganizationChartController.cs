using Microsoft.AspNetCore.Mvc;
using Organigrama.Services.IServices;

namespace Organigrama.Controllers
{
    /// <summary>
    /// Controller del Organigrama
    /// </summary>
    public class OrganizationChartController : Controller
    {
        private readonly IEmployeeService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Interface del servicio empleado</param>
        public OrganizationChartController(IEmployeeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Action que muestra la vista principal
        /// </summary>
        /// <returns>Devuele la vista del organigrama</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action que obtiene el organigrama
        /// </summary>
        /// <returns>Retorna un json con los datos para el organigrama</returns>
        public IActionResult GetOrganigrama()
        {
            var result = _service.GetOrganizationChart();
            return Json(result);
        }
    }
}
