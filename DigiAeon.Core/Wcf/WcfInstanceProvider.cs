namespace DigiAeon.Core.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// The WCF instance provider.
    /// </summary>
    public class WcfInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// The service type.
        /// </summary>
        private readonly Type _serviceType;

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWcfContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        public WcfInstanceProvider(Type serviceType, IWcfContainer container)
        {
            this._serviceType = serviceType;
            this._container = container;
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this._container.GetInstance(this._serviceType);
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this._container.GetInstance(this._serviceType);
        }

        /// <summary>
        /// The release instance.
        /// </summary>
        /// <param name="instanceContext">
        /// The instance context.
        /// </param>
        /// <param name="instance">
        /// The instance.
        /// </param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}