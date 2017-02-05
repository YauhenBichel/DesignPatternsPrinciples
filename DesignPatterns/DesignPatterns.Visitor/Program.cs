using System;

namespace DesignPatterns.Visitor
{
	class Program
	{
		static void Main(string[] args)
		{
			var person = new Person();
			person.Assets.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01});
			person.Assets.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.02 });
			person.Assets.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });
			person.Assets.Add(new Loan { Oewd = 40000, MonthlyPayment = 40});

			// operations to calculate worth net.
			// if we need to add new operation to calculate monthly income, 
			// then we need change this method with new logic
			// 
			// Moreover, we do not want to change BankAccount, RealEstate and Loan classes
			// when we would like to add new operation
			//
			// We can avoid changin this method, if this method takes as parameter
			// concrete visitor, which completes spicific task
			/*
			int netWorth = 0;
			foreach (var bankAccount in person.BankAccounts) {
				netWorth += bankAccount.Amount;
			}

			foreach (var realEstate in person.RealEstates) {
				netWorth += realEstate.EstimatedValue;
			}

			foreach (var loan in person.Loans) {
				netWorth -= loan.Oewd;
		 	}
			*/

			WorthNetVisitor worthNetVisitor = new WorthNetVisitor();
			person.Accept(worthNetVisitor);
			
			Console.WriteLine(worthNetVisitor.Total);

			Console.ReadKey();
		}
		
	}
}
