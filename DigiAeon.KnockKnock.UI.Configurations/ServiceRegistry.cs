namespace DigiAeon.KnockKnock.UI.Configurations
{
    using DigiAeon.KnockKnock.Services;

    using StructureMap.Configuration.DSL;

    /// <summary>
    /// The rule with service registry.
    /// </summary>
    public class ServiceRegistry : Registry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRegistry"/> class.
        /// </summary>
        public ServiceRegistry()
        {
            // Since WCF ServiceHost only supports class service types
            this.For<RedPill>().Use(() => new RedPill(Config.MyKnockKnockToken));
        }
    }
}
