using System;
using System.Collections.Generic;

namespace DesignPatterns.Builder
{
	// containes components
	class Sandwich
	{
		public BreadType BreadType { get; set; }
		public MeatType MeatType { get; set; }
		public CheeseType CheeseType { get; set; }
		public bool HasMayo { get; set; }
		public bool IsToasted { get; set; }
		public bool HasMustard { get; set; }
		public IList<string> Vegetables { get; set; }

		public Sandwich()
		{

		}

		public void Display()
		{
			Console.WriteLine("BreadType is {0}", BreadType);
			Console.WriteLine("MeatType is {0}", MeatType);
			Console.WriteLine("CheeseType is {0}", CheeseType);
			Console.WriteLine("HasMayo is {0}", HasMayo);
			Console.WriteLine("IsToasted is {0}", IsToasted);
			Console.WriteLine("HasMustard is {0}", HasMustard);
			Console.WriteLine("Vegetables:");
			foreach(var vegetable in Vegetables)
				Console.WriteLine("\t{0}", vegetable);
		}
	}

	enum BreadType
	{
		White,
		Black
	}

	enum CheeseType
	{
		Cheddar,
		sdf
	}

	enum MeatType
	{
		Ham,
		Turkey,
		Chicken,
		Salami
	}
}
