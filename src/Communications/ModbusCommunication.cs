using System;
namespace HardwareCommunicationSDK.Communications
{
    public class ModbusCommunication : ICommunicationProtocol
    {
        public void Connect(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !address.Contains("."))
            {
                throw new ArgumentException("Invalid address provided", nameof(address));
            }
            
            Console.WriteLine($"Connecting to {address} using Modbus...");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from Modbus device...");
        }

        public string SendMessage(string message)
        {
            Console.WriteLine($"Sending message: {message}");
            return "Response from Modbus device";
        }
    }


}