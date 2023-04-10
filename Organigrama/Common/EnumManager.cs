using System.ComponentModel;
using System.Reflection;

namespace Organigrama.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumManager
    {
        private const string SIN_VALOR = "-1";

        private static readonly Lazy<EnumManager> lazy =
           new Lazy<EnumManager>(() => new EnumManager());

        /// <summary>
        /// Instancia de la clase
        /// </summary>
        public static EnumManager Instance { get { return lazy.Value; } }

        private EnumManager()
        {
        }

        /// <summary>
        /// Retorna la descripción de una enumeración
        /// </summary>
        /// <param name="value">Enumeración requerida</param>
        /// <returns>Descripción de la enumeración</returns>
        public static string GetEnumDescription(Enum value)
        {
            if (value != null)
            {
                if (value.ToString() == SIN_VALOR)
                    return string.Empty;

                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// Retorna una lista de valores de una enumeración
        /// </summary>
        /// <typeparam name="T">Enumeración</typeparam>
        /// <returns>Lista con los valores de la enumeración</returns>
        /// <exception cref="ArgumentException">Genera una excepción si el tipo no es una enumeración</exception>
        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

    }
}
