using Xunit;
using HardwareCommunicationSDK.Communications;
using FluentAssertions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareCommunicationSDK.Tests
{

    public class ModbusCommunicationTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CommunicationFactory _factory;

        public ModbusCommunicationTests()
        {
            // Set up the Dependency Injection container
            var services = new ServiceCollection();
            services.AddTransient<ModbusCommunication>(); // Ensure ModbusCommunication is registered
            _serviceProvider = services.BuildServiceProvider();

            // Initialize CommunicationFactory with the DI container
            _factory = new CommunicationFactory(_serviceProvider);
        }

        [Fact]
        public void Connect_ValidAddress_ShouldNotThrowException()
        {
            var modbus = new ModbusCommunication();
            Action action = () => modbus.Connect("192.168.1.1");
            action.Should().NotThrow();
        }

        [Fact]
        public void SendMessage_ValidMessage_ShouldReturnExpectedResponse()
        {
            var modbus = new ModbusCommunication();
            modbus.Connect("192.168.1.1");
            string response = modbus.SendMessage("Test Message");

            response.Should().Be("Response from Modbus device");
        }

        [Fact]
        public void Disconnect_ShouldNotThrowException()
        {
            var modbus = new ModbusCommunication();
            modbus.Connect("192.168.1.1");
            Action action = () => modbus.Disconnect();
            action.Should().NotThrow();
        }

        [Fact]
        public void CreateProtocol_ValidType_ShouldReturnInstance()
        {
            var protocol = _factory.CreateProtocol("Modbus");
            protocol.Should().NotBeNull();
            protocol.Should().BeOfType<ModbusCommunication>();
        }

        [Fact]
        public void CreateProtocol_InvalidType_ShouldThrowException()
        {
            Action action = () => _factory.CreateProtocol("Unknown");
            action.Should().Throw<ArgumentException>().WithMessage("Unsupported protocol");
        }
    }
}