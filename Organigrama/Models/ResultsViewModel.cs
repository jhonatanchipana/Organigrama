namespace Organigrama.Models
{
    /// <summary>
    /// Clase usado para la paginacion
    /// </summary>
    /// <typeparam name="T">Clase</typeparam>
    public class ResultsViewModel<T> where T : class
    {
        /// <summary>
        /// Registros enviado a la vista
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Cantidad total de registros
        /// </summary>
        public int Count { get; set; }
    }
}
