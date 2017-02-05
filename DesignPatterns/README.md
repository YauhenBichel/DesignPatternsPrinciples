[based on "Design Patterns Library" pluralsight course] (https://app.pluralsight.com/library/courses/patterns-library/)

# Design Patterns

## Builder

### Problems
- Too many parameters
- Order dependent
- Different constructions

### Overview
Separates the construction of a complex object from its representation so that the same construction process can create different representations.

### Example

#### A Dialog
- Hey
	- Year?
- I want a sandwich!
	- Ok, first what kind of bread?
- Wheat
	- Ok, what size?
- 1 foot long
	- Ok, what kind of meat and cheese?
- Turkey and Swiss
	- Do you want it toasted?
- Yes
	- What kind of vegetables?
...

### The Builder Patterns

Director contains Builder <- Concrete Builder refers Product

Explanations:
- The core is a builder
- The builder is used by Director
- The builder is implemented by Concrete Builder
- The Concrete Builder produces Product

Buider defines steps and order of steps

### Builder Pattern Roles
- Director (in our example is a SandwichMaker)
	- Uses the Concrete Buider
	- Knows how to build
	- Client code calls directly

Director knows what order supposed to be.
Director knows what to do to build a product.

- Builder
	- Abstract interface or class
	- Defines steps
	- Holds instance of Product

- Concrete Builder
	- Should be more than one of these
	- Provides an implemetation for interface defined by the Builder
	- A recipe

- Product
	- What is being built
	- Not a different type, but different data
	

### Not a Builder

1. StringBuilder does not mirror a builder pattern, due to you can not find there all roles of the Builder desing pattern
```c#
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
sb.ToString();
```

2. Using chain of methods syntax like:

```c#
var s = new Sandwich()
		.PrepareBread(BreadType.White)
		.AddMeat(MeatType.Chicken)
		.AddVegetalbes(new List<string>{"cucumber"})
```

## Visitor Design Pattern
- GoF: represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.

### Formal Definition

- Object Structure (Person class) uses Element (Assets)
- Element has concrete elements
- Visitor inteface has multiple concrete visitors


### Explanation

- Each value object, which is operand of operation, implements IAsset interface with Accept method.
- Accept method takes IVisitor parameter.
- Each value object implements Accept method like this:
```c#
void Accept(IVisitor visitor) {
	visitor.Visit(this);
}
```
- IVisitor interface contains overloaded methods for each value object:
```c#
interface IVisitor{
	void Visit(BankAccount bankAccount);
	void Visit(Loan loan);
	void Visit(RealEstate realEstate);
}
```

- Concrete visitor implements IVisitor interface and implement operation logic with value objects
```c#
class WorthNetVisitor: IVisit {
	public int Total;
	
	public void Visit(BankAccount bankAccount) {
		Total += bankAccount;
	}
	
	public void Visit(RealEstate realEstate) {
		Total += realEstate;
	}
	
	public void Visit(Loan loan) {
		Total -= loan;
	}
}
```

- Then create our concrete visitor, each value object calls Accept method with passed as parameter this visitor.
Each Accept method calls Visit method, each changes Total field.

```c#
WorthNetVisitor visitor = new WorthNetVisitor();
BankAccount bankAccount = new BankAccount();
bankAccount.Accept(visitor);
RealEstate realEstate = new RealEstate();
realEstate.Accept(visitor);
Loan loan = new Loan();
loan.Accept(visitor);

Console.WriteLine(visitor.Total);
```