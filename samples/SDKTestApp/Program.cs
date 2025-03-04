using System;
using HardwareCommunicationSDK.Communications;
class Program
{
    static void Main()
    {
        try
        {
            ICommunicationProtocol comm = new ModbusCommunication();
            comm.Connect("192.168.1.1");
            string response = comm.SendMessage("Test Message");
            Console.WriteLine($"Received Response: {response}");
            comm.Disconnect();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
