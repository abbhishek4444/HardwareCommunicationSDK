using HardwareCommunicationSDK.Communications;

namespace HardwareCommunicationSDK.HardwareSDK
{
    public class HardwareSDK
    {
        private readonly ICommunicationProtocol _communicationProtocol;

        public HardwareSDK(ICommunicationProtocol communicationProtocol)
        {
            _communicationProtocol = communicationProtocol;
        }

        public void Initialize(string address)
        {
            _communicationProtocol.Connect(address);
        }
    }
}
