namespace DigiAeon.Core
{
    using System;
    using System.Text;

    /// <summary>
    /// The string helper.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// The reverse words.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If value is null then exception will be thrown.
        /// </exception>
        public static string ReverseWords(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Value cannot be null.");
            }

            var output = new StringBuilder(value.Length);
            var currentPosition = 0;

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
                var isWordSeparator = char.IsSeparator(c) || char.IsWhiteSpace(c);

                if (isWordSeparator)
                {
                    output.Append(c);
                    currentPosition = i + 1;
                }
                else
                {
                    output.Insert(currentPosition, c);
                }
            }

            return output.ToString();
        }
    }
}