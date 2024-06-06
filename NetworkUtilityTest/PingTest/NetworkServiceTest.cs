using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using Xunit;
namespace NetworkUtilityTest.PingTest
{
	public class NetworkServiceTest
	{
		private readonly NetworkService _pingService;
		public NetworkServiceTest()
		{
            _pingService = new NetworkService();
		}
		[Fact]
		public void NetworkService_SendPing_ReturnString()
		{
            //Arrange - variables, classes, mocks
           // var pingService = new NetworkService(); 

			//Act
			var result = _pingService.SendPing();

			//Assert
			result.Should().NotBeNullOrWhiteSpace();
			result.Should().Be("Success: Ping Sent!");
			result.Should().Contain("Success", Exactly.Once());
            
		}

		[Theory]
		[InlineData(1,2,3)]
		public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
		{
			//Arrange - variables, classes, mocks
			//var pingService = new NetworkService();

			//Act
			var result = _pingService.PingTimeout(a, b);

			//Assert
			result.Should().Be(expected);
			result.Should().BeGreaterThanOrEqualTo(3);
			result.Should().NotBeInRange(-10000, 0);

		}
		[Fact]
		public void NetworkService_LastPingDate_ReturnDate()
		{
            //Arrange - variables, classes, mocks
            //var pingService = new NetworkService();

            //Act
            var result = _pingService.LastPingDate();

			//Assert
			result.Should().BeBefore(1.January(2030));
			result.Should().BeAfter(1.January(2024));
        }
	}
}

