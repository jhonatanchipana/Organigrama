using Microsoft.AspNetCore.Mvc;
using Organigrama.Models;
using Organigrama.Services.Interfaces;
using Organigrama.Services.IServices;

namespace Organigrama.Controllers
{
    /// <summary>
    /// Controller de empleados
    /// </summary>
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IWorkStationService _workStationService;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="service">Interface del servicio empleados</param>
        /// <param name="workStationService">Interface del servicio de puesto</param>
        public EmployeeController(IEmployeeService service,
            IWorkStationService workStationService)
        {
            _service = service;
            _workStationService = workStationService;
        }

        /// <summary>
        /// Accion que muestra la vista del empleado
        /// </summary>
        /// <returns>Retorna una vista</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Accion que obtiene el listado de empleados paginado
        /// </summary>
        /// <param name="filter">Propiedad enviado desde UI, para filtrar los registros</param>
        /// <param name="offset">Propiedad enviado desde UI, para paginar los registros </param>
        /// <param name="limit">Propiedad enviado desde UI, para paginar los registros</param>
        /// <param name="sortBy">Propiedad enviado desde UI, para identificar por cual columna se ordenara los registros</param>
        /// <param name="orderBy">Propiedad enviado desde UI, para ordenar asc o desc</param>
        /// <returns>Retorna un Json</returns>
        [HttpGet]
        public IActionResult GetList(string filter, int offset, int limit, string sortBy, string orderBy)
        {
            var results = _service.GetList(filter, offset, limit, sortBy, orderBy);
            return Json(results);
        }

        /// <summary>
        /// Accion que obtiene la vista para el registro de un empleado
        /// </summary>
        /// <returns>Retorna una vista</returns>
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel()
            {
               WorkStations = _workStationService.GetCombo()
            };

            return View(model);
        }

        /// <summary>
        /// Accion para el registro de un empleado
        /// </summary>
        /// <param name="model">Representa un model del empleado</param>
        /// <returns>Redirecciona a la vista index</returns>
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            var exists = _service.ValidateWorkStationForBoss(model.WorkStationId, model.BossId);

            if (!exists)
            {
                ModelState.AddModelError(nameof(model.WorkStationId),
                                 "El puesto debe ser de menor nivel o igual al puesto del Jefe");
            }

            if (!ModelState.IsValid)
            {
                model.WorkStations = _workStationService.GetCombo();
                return View(model);
            }
            
            var id = _service.Create(model);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Accion de un autocomplete del empleado
        /// </summary>
        /// <param name="filter">Filtrar por el nombre completo del empleado, enviado desde UI</param>
        /// <param name="limit">Cantidad de registros a mostrar, enviado desde UI</param>
        /// <returns>Retorna los registros</returns>
        [HttpGet]
        public IActionResult Autocomplete(string filter, int limit)
        {
            var result = _service.GetAutocomplete(filter, limit);   
            return Json(result);
        }

        /// <summary>
        /// Acción que valida si el nro de documento existe
        /// </summary>
        /// <param name="id">Identificador del empleado enviado desde UI</param>
        /// <param name="nroDocument">Número de documento enviado desde UI</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ValidateNroDocument(int id, string nroDocument)
        {
            var exists = _service.ValidateNroDocument(id, nroDocument);
            return Json(exists);
        }

        /// <summary>
        /// Acción que valida que el puesto del empleado sea de menor o igual nivel que el puesto del jefe
        /// </summary>
        /// <param name="workStationId">Identificador del puesto empleado, enviado desde UI</param>
        /// <param name="bossId">Identificador del jefe, , enviado desde UI</param>
        /// <returns>Retorna un boleano</returns>
        [HttpGet]
        public IActionResult ValidateWorkStationForBoss(int workStationId, int? bossId)
        {
            var exists = _service.ValidateWorkStationForBoss(workStationId, bossId);

            if (!exists) return Json($"El puesto debe ser de menor nivel o igual al puesto del Jefe");

            return Json(true);
        }

    }
}
