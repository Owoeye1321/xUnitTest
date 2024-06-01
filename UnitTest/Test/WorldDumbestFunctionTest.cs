using System;
namespace UnitTest.Test
{
	public static class WorldDumbestFunctionTest
	{
		public static void WorldDumbestFunction_ReturnPikachuIfZero_ReturnString()
		{
			try {
                //Arrange- Go get your variables, what you need, your classes
                WorldDumbestFunction worldDumbestFunction = new WorldDumbestFunction();
                int digit = 0;
				//Act - Execute your classes/function
				string result = worldDumbestFunction.ReturnPikachuIfZero(digit);
				//Assert- Whatever is returned is what you want
				if (result == "Pikachu")
				{
                     Console.WriteLine("Passed: Pikachu");
				}
				else
				{
					Console.WriteLine("Failed:  Not Match");
				}
				
			}catch(Exception ex)
			{
				Console.WriteLine($"What happened here >>>>>> {ex.Message}");
			}
		}
	}
}

