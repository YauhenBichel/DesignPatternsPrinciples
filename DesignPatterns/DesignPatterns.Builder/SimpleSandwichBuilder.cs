using System.Collections.Generic;

namespace DesignPatterns.Builder
{
	class SimpleSandwichBuilder: SandwichBuilder
	{
		public void CreateSandwich()
		{
			sandwich = new Sandwich();

			PrepareBread();
			ApplyMeetAndCheese();
			ApplyVegetables();
			AddCondiments();
		}

		public override void PrepareBread()
		{
			sandwich.BreadType = BreadType.White;
			sandwich.IsToasted = true;
		}

		public override void ApplyMeetAndCheese()
		{
			sandwich.CheeseType = CheeseType.Cheddar;
			sandwich.MeatType = MeatType.Turkey;
		}

		public override void ApplyVegetables()
		{
			sandwich.Vegetables = new List<string> { "Tomato", "Onion" };
		}

		public override void AddCondiments()
		{
			sandwich.HasMayo = false;
			sandwich.HasMustard = true;
		}
	}
}
