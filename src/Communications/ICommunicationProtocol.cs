namespace HardwareCommunicationSDK.Communications
{
    public interface ICommunicationProtocol
    {
        void Connect(string adress);
        void Disconnect();
        string SendMessage(string message);
    }
}

