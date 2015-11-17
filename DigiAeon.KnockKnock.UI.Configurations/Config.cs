namespace DigiAeon.KnockKnock.UI.Configurations
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Gets the my knock knock token.
        /// </summary>
        public static Guid MyKnockKnockToken
        {
            get
            {
                return new Guid(ConfigurationManager.AppSettings["MyKnockKnockToken"]);
            }
        }
    }
}