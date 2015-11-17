namespace DigiAeon.Core.Wcf
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// The WCF service host.
    /// </summary>
    public class WcfServiceHost : ServiceHost
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWcfContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceHost"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public WcfServiceHost(IWcfContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses.
        /// </param>
        public WcfServiceHost(Type serviceType, IWcfContainer container, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this._container = container;
        }

        /// <summary>
        /// The on opening.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new WcfServiceBehavior(this._container));
            base.OnOpening();
        }
    }
}