namespace DigiAeon.Core.StructureMapExtensions
{
    using Wcf;
    using StructureMap;
    using StructureMap.Graph;

    /// <summary>
    /// The structure map WCF container.
    /// </summary>
    /// <!--
    /// https://lostechies.com/jimmybogard/2008/07/30/integrating-structuremap-with-wcf/
    /// -->
    public class StructureMapWcfContainer : Container, IWcfContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapWcfContainer"/> class.
        /// </summary>
        public StructureMapWcfContainer()
            : base(registry => registry.Scan(
                scanner =>
                    {
                        scanner.AssembliesFromApplicationBaseDirectory();
                        scanner.LookForRegistries();
                    }))
        {
        }
    }
}