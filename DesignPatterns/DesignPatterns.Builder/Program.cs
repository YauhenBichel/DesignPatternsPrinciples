using System;

namespace DesignPatterns.Builder
{
	class Program
	{
		static void Main(string[] args)
		{
			var sandwichMaker = new SandwichMaker(new SimpleSandwichBuilder());
			sandwichMaker.BuildSandwich();
			var simpleSandwich = sandwichMaker.GetSandwich();

			simpleSandwich.Display();

			Console.ReadKey();
		}
	}
}
