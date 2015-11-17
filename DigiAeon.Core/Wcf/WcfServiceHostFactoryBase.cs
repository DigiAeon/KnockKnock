namespace DigiAeon.Core.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    /// <summary>
    /// The WCF service host factory.
    /// </summary>
    public abstract class WcfServiceHostFactoryBase : ServiceHostFactory
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWcfContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceHostFactoryBase"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <!--
        /// http://blog.ploeh.dk/2010/05/17/ServiceHostFactorylifetime/
        /// -->
        protected WcfServiceHostFactoryBase(IWcfContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// The create service host.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceHost"/>.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new WcfServiceHost(serviceType, this._container, baseAddresses);
        }
    }
}