using System;
using NetworkUtility.Ping;
using Xunit;
namespace NetworkUtilityTest.PingTest
{
	public class NetworkServiceTest
	{
		[Fact]
		public void NetworkService_SendPing_ReturnString()
		{
            //Arrange - variables, classes, mocks
            var pingService = new NetworkService();

			//Act
			pingService.SendPing();

            //Assert
            
		}
	}
}

