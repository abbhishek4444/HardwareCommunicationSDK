using System;
namespace HardwareCommunicationSDK.Communications
{
    public class CommunicationFactory
    {
        public static ICommunicationProtocol CreateProtocol(string protocolType)
        {
            return protocolType switch
            {
                "Modbus" => new ModbusCommunication(),
                _ => throw new ArgumentException("Unsupported protocol"),
            };
        }
    }
}
