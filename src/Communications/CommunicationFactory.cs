using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HardwareCommunicationSDK.Communications
{
    public class CommunicationFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _protocols = new Dictionary<string, Type>
        {
            { "Modbus", typeof(ModbusCommunication) }
        };

        public CommunicationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommunicationProtocol CreateProtocol(string protocolType)
        {
            if (_protocols.TryGetValue(protocolType, out var protocolClass))
            {
                var instance = _serviceProvider.GetService(protocolClass) as ICommunicationProtocol;
                if (instance == null)
                {
                    throw new InvalidOperationException($"Service for type '{protocolClass.Name}' is not registered in DI.");
                }
                return instance;
            }
            throw new ArgumentException($"Unsupported protocol type: {protocolType}");
        }
    }
}
