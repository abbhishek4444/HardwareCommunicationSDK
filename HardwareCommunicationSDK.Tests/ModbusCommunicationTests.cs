using Xunit;
using HardwareCommunicationSDK.Communications;
using FluentAssertions;
using System;

namespace HardwareCommunicationSDK.Tests
{
    
    public class ModbusCommunicationTests
    {
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
            var protocol = CommunicationFactory.CreateProtocol("Modbus");
            protocol.Should().NotBeNull();
            protocol.Should().BeOfType<ModbusCommunication>();
        }

        [Fact]
        public void CreateProtocol_InvalidType_ShouldThrowException()
        {
            Action action = () => CommunicationFactory.CreateProtocol("Unknown");
            action.Should().Throw<ArgumentException>().WithMessage("Unsupported protocol");
        }
    }
    
}

