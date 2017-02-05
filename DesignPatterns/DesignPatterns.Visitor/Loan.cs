namespace DesignPatterns.Visitor
{
	internal class Loan: IAsset
	{
		public int MonthlyPayment { get; set; }
		public int Oewd { get; set; }

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}