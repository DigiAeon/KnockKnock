namespace DigiAeon.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Fasterflect;

    /// <summary>
    /// The reflection helper.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// The get class properties.
        /// </summary>
        /// <param name="obj">
        /// The object of type T.
        /// </param>
        /// <typeparam name="T">
        /// Class type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:List"/>.
        /// </returns>
        public static List<KeyValuePair<string, string>> GetClassProperties<T>(this T obj) where T : class
        {
            return typeof(T).Properties()
                .Select(x => new KeyValuePair<string, string>(x.Name, obj.GetPropertyValue(x.Name).ToString()))
                .ToList();
        }
    }
}