namespace DesignPatterns.Visitor
{
	class WorthNetVisitor : IVisitor
	{
		public int Total { get; set; }

		public void Visit(Loan loan)
		{
			Total -= loan.Oewd;
		}

		public void Visit(RealEstate realEstate)
		{
			Total += realEstate.EstimatedValue;
		}

		public void Visit(BankAccount bankAccount)
		{
			Total += bankAccount.Amount;
		}
	}
}
