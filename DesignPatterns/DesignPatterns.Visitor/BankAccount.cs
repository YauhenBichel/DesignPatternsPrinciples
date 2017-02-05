namespace DesignPatterns.Visitor
{
	internal class BankAccount : IAsset
	{
		public int Amount { get; set; }
		public double MonthlyInterest { get; set; }

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
