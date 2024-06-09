using System;
using System.Net.NetworkInformation;
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

		[Fact]
		public void NetworkService_GetPingOptions_ReturnObjects()
		{

			//Arrange -variables, classes, mocks
			var expectedResult = new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
            };


			//Act
			var result = _pingService.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
			result.Should().BeEquivalentTo(expectedResult);
			result.Ttl.Should().Be(1);

		}

		[Fact]

		public void NetworkService_GetAllPingOptions_ReturnIEnumerable()
		{
            //Arrange - variables, classes, mock
            var expectedResult = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.GetAllPingOptions();


			//Assert
			//result.Should().BeOfType<IEnumerable<PingOptions>>();
			result.Should().ContainEquivalentOf(expectedResult);
        }


    }
}

