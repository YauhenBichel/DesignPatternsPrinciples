namespace DesignPatterns.Builder
{
	// structure of building steps
	// contians logic of steps
	abstract class SandwichBuilder
	{
		protected Sandwich sandwich;

		public Sandwich GetSandwich()
		{
			return sandwich;
		}

		public void CreateNewSandwich()
		{
			sandwich = new Sandwich();
		}

		public abstract void PrepareBread();
		public abstract void ApplyMeetAndCheese();
		public abstract void ApplyVegetables();
		public abstract void AddCondiments();
	}
}
