namespace DigiAeon.Core.Test
{
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// The NUnit extensions.
    /// </summary>
    public static class NUnitHelper
    {
        /// <summary>
        /// The to test case data.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="nameIdentifier">
        /// The name identifier.
        /// </param>
        /// <typeparam name="TForTestCaseDataFirstArgument">
        /// Type of object for the first argument of TestCaseData.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TestCaseData"/>.
        /// </returns>
        public static TestCaseData ToTestCaseData<TForTestCaseDataFirstArgument>(this TForTestCaseDataFirstArgument obj, string nameIdentifier = "") where TForTestCaseDataFirstArgument : class
        {
            var name = GetName(obj, nameIdentifier);

            return string.IsNullOrWhiteSpace(name) ? new TestCaseData(obj) : new TestCaseData(obj).SetName(name);
        }

        /// <summary>
        /// The get name.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="nameIdentifier">
        /// The name identifier.
        /// </param>
        /// <typeparam name="T">
        /// Type of an object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetName<T>(T obj, string nameIdentifier = "") where T : class
        {
            if (!string.IsNullOrWhiteSpace(nameIdentifier))
            {
                return typeof(T).Name + " [" + nameIdentifier + "]";
            }

            if (obj != null)
            {
                var testCaseName = string.Join(", ", obj.GetClassProperties().Select(x => string.Format("{0}: {1}", x.Key, x.Value)));

                return typeof(T).Name + " [" + testCaseName + "]";
            }

            return string.Empty;
        }
    }
}