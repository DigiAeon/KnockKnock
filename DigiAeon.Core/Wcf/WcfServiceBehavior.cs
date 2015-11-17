namespace DigiAeon.Core.Wcf
{
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// The WCF service behavior.
    /// </summary>
    public class WcfServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWcfContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceBehavior"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public WcfServiceBehavior(IWcfContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// The apply dispatch behavior.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description.
        /// </param>
        /// <param name="serviceHostBase">
        /// The service host base.
        /// </param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (var ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider = new WcfInstanceProvider(serviceDescription.ServiceType, this._container);
                    }
                }
            }
        }

        /// <summary>
        /// The add binding parameters.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description.
        /// </param>
        /// <param name="serviceHostBase">
        /// The service host base.
        /// </param>
        /// <param name="endpoints">
        /// The endpoints.
        /// </param>
        /// <param name="bindingParameters">
        /// The binding parameters.
        /// </param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description.
        /// </param>
        /// <param name="serviceHostBase">
        /// The service host base.
        /// </param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
