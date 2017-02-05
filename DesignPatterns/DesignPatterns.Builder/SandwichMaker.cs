namespace DesignPatterns.Builder
{
	// using components of Builder design pattern, this class is Director
	// controlling the process of building some sandwich
	//maker knows how to make a sandwich
	class SandwichMaker
	{
		private readonly SandwichBuilder builder;

		public SandwichMaker(SandwichBuilder builder)
		{
			this.builder = builder;
		}

		public void BuildSandwich()
		{
			builder.CreateNewSandwich();
			builder.PrepareBread();
			builder.ApplyMeetAndCheese();
			builder.ApplyVegetables();
			builder.AddCondiments();
		}

		public Sandwich GetSandwich()
		{
			return builder.GetSandwich();
		}
	}
}
