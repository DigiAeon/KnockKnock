namespace DigiAeon.Core.StructureMapExtensions
{
    using DigiAeon.Core.Wcf;

    /// <summary>
    /// The structure map WCF service host factory.
    /// </summary>
    public class StructureMapWcfServiceHostFactory : WcfServiceHostFactoryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapWcfServiceHostFactory"/> class.
        /// </summary>
        public StructureMapWcfServiceHostFactory() : base(new StructureMapWcfContainer())
        {
        }
    }
}