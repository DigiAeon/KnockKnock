namespace DigiAeon.Core.Wcf
{
    using System;

    /// <summary>
    /// The WCF Container interface.
    /// </summary>
    public interface IWcfContainer
    {
        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="pluginType">
        /// The plugin type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object GetInstance(Type pluginType);
    }
}