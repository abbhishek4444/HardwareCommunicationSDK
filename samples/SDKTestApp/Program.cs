using System;
using Microsoft.Extensions.DependencyInjection;
using HardwareCommunicationSDK.Communications;
using HardwareCommunicationSDK;

class Program
{
    static void Main()
    {
        try
        {
            // Set up Dependency Injection
            var serviceProvider = HardwareCommunicationSDK.DependencyInjectionConfig.ConfigureServices();

            // Ensure CommunicationFactory is registered
            var factory = serviceProvider.GetService<CommunicationFactory>();
            if (factory == null)
            {
                throw new InvalidOperationException("CommunicationFactory is not registered in the DI container.");
            }

            // Create a Modbus communication protocol using the factory
            ICommunicationProtocol comm = factory.CreateProtocol("Modbus");

            // Ensure protocol is created successfully
            if (comm == null)
            {
                throw new InvalidOperationException("Failed to create Modbus protocol using CommunicationFactory.");
            }

            // Connection and Communication
            string ipAddress = "192.168.1.1";
            Console.WriteLine($"Connecting to {ipAddress}...");
            comm.Connect(ipAddress);

            string message = "Test Message";
            Console.WriteLine($"Sending: {message}");
            string response = comm.SendMessage(message);
            
            Console.WriteLine($"Received Response: {response}");

            comm.Disconnect();
            Console.WriteLine("Disconnected successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\nStack Trace:\n{ex.StackTrace}");
        }
    }
}
