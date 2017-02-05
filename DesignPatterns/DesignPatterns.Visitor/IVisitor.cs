namespace DesignPatterns.Visitor
{
	interface IVisitor
	{
		void Visit(BankAccount bankAccount);
		void Visit(RealEstate realEstate);
		void Visit(Loan loan);
	}
}
