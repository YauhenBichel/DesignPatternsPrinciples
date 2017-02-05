(from pluralsight course "Domain Drive Design Fundamentals")

Eric Evans, author of Doamin-Driven Desing book:
"The Domain Layer is responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controller and used here, even though the technical details of storing it are delegated to the infrastructure. This layer is the heart of business software."

## Focus on BEHAVIORS, not ATTRIBUTES

It is possible to separate "Anemic" domain models and "Rich" domain models

### [Martin Fowler about Anemic Domain Model](http://www.martinfowler.com/bliki/AnemicDomainModel.html):

"This is one of those anti-patterns that has been around for quite a long time, yet seems to be having a particular spurt at the moment. I was chatting with Eric Evans on this, and we have both noticed they seem to be getting more popular. As great boosters of a proper Domain Model, this is not a good thing."
 
"Often these models come with design rules that say that you are not to put any domain logic in the domain objects. Instead there are a set of service objects which capture all the domain logic. These services live on top of the domain model and use the domain model for data."
 
"The fundamental horror of this anti-pattern is that it is so contrary to the basic idea of object-oriented design; which is to combine data and process together. The anemic domain model is really just a procedural style design, exactly the kind of thing that object bigots like me."
 
"What is worse, many pepole think that anemic objects are real objects, and thus completely miss the point of what object-oriented design is all about."

## Eric Evans wrote in his book about applicatoin layer and domain layer:
"Application Layer [his name for Service Layer]: Defines the jobs the software is supposed to do and directs the expressive domain objects to work out problems. The tasks this layer is responsible for are meaningful to the business or necessary for interaction with the application layers of other systems. This layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down. It does not have state reflecting the business situation, but it can have state that reflects the progress of a task for the user or the program."

"Domain Layer (or Model Layer): Responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. This layer is the heart of business software."

## Example of Anemic Domain Models

```c#
public class Person
{
	public Person()
	{
		Skills = new List<Skills>();
	}
	
	public int Id {get;set;}
	public string FirstName {get;set;}
	public string LastName {get;set;}
	
	public IList<Skill> Skills {get; private set;}
}
```


## Why we care about DDD?
- Principles and patterns to solve difficult problems
- History of success with complex projects
- Aligns with practices from our own experience
- Clear, testable code that represents the domain

## Important
			# Solve Problems
	## Understanding Client Needs
		### Build Sofrware
			#### Write Code
			
	- Nobody wants your code. Everyone wants the solutions of problems!
	
	 - Creation application is not about writing code, it is about solving problems!
	
## Importance of Communication Skills to develope a software, which solves any problems.

Eric Evans: "Cultivate your ability to communicate with business people, to free up people's creativity for modeling, etc."

## Notes:
- Interaction with Domain Experts
- Model a single Sub-Domain at a time
- Implementation of Sub-Domains

## Benefits of DDD
- Flexible
- Customer's vision/perspective of the problem
- Path through a very complex problem
- Well-organized and easily tested code
- Business logic lives in one place
- Many great patterns to leverage

## Important: DDD is not a solution for all problems.
"While Domain-Driven Design provides many technical benefits, such as maintainability, it should be applied only to complex domains where the model and the linguistic process provide clear benefits in the communication of complex information, and in the formulation of a common understanding of the domain."

## Drawbacks of DDD
- Time and Effort
	- Discuss & model the problem with domain experts
	- Isolate domain logic from other parts of application
- Learning curve
	- New principles
	- New patterns
	- New processes
- Only makes sense when there is complexity in the problem
	- Not just CRUD or data-driven applications
	- Not just technical complexity without business domain complexity
- Team or Company Buy-In to DDD

## Associations
Eric Evans:
"A bidirectional association means that both objects can be understood only together. When application requirements do not call for traversal on both directions, addin a traversal direction reduces interdependence and simplifies the design."
So, start with one-way relationships.


## Value Object

Has some specific characteristics:

- Measures, quantifies, or describes a thing in the domain.
- Identify is based on composition of values.
- Immutable.
- Compared using all values.
- No side effects.

Example of value object is String.

So. ummutability (can not be changed) is one of the key property of value objects.

For example, ToUpper() method does not change target string. This method returns a copy of the string converted to uppercase.


- Vaughn Vernon, author of "Implementing Domain-Drive Design":

"It may surprise you to learn that we should strive to model using Value Objects instead of Entities wherever possible. Even when a domain concept must be modeled as an Entity, the Entity's design should be biased toward serving as a value container tather than a child Entity container."

Eric Evans (from pluralsight course): "Value objects are a really good place to put methods and logic... a better place than entities.
An example: Dates are a classic value object... and there are a lot of logic"


## Domain Services
- Important operations that don't belong to a particular Entity or Value Object

### Good Domain Services:
- Not a natural part of an Entity or Value Object
- Have an  interface defined in terms of other domain model elements
- Are stateless (but may have side effects)

### Examples of Services in Different Layers:
- UI Layer & Applicataion Layer. Ex.: message sending, message processing, xml parsing, ui services
- Domain (Application Core). Ex.: transfer between accounts, process order
- Infrastructure. Usually contains implementations of interfaces from "Application Core". Ex.: send email, log to a file.

### Some Terms

#### Anemic Domain Model - model with classes focused on state management. Good for CRUD.

#### Rich Domain Model - model with logic focused on behavior, not just state. Preferred for DDD.

#### Entity - a mutable class with an identity used for tracking and persistence.

#### Immutable - refers to a type whose state cannot be changed once the object has been instantiated.

#### Value Object - an immutable class whose identity is dependent on the combination of its values.

#### Services - provide a place in the model to hold behavior that doesn't belong elsewhere in the domain.

#### Side Effects - changes in the state of the application or interaction with the outside world (e.g. infrastructure)


## DDD helps with complex domains


### Aggregates

Ex.:
- Customer Aggregate
Customer (1) -> (N) Address
Address is a part of customer
##### Customer is an aggregate root

- Product Aggregate
Product (1) -> (N) Component
Component is a part of product
##### Product is an aggregate root

Customer aggregate is one transaction
Product aggregate is one transaction

#### Aggregate root is a parent object of all members of an aggregate 


### Data changes should be ACID
A - atomic
C - consistent
I - isolated
D - durable

With aggregation:
if you delete aggregation root, then you should delete members of aggregation. It means, if you delete product, then you should delete all components of its product.

#### Eric Evans, author of Domain-Driven Desing:
"An aggregate is a cluster of associated objects that we treat as a unit for the purpose of data changes."


### We should not use DDD patterns for all cases of software development due to the fact that each application requers different efforts and has different complexity.

We can data-centric design pattens when compexity is not big bacuse it is faster and our code are still readable and maintaable.

However when we have s complex system then we should think about DDD patterns.

Also, except Object-oriented models, we can take a look:
- Functional models
- CQRS
- Classic 3-tier
- 2-tiers


### DDD (based on pluralsight course of Modern software architecture domain models)
You design the system driven by your knowledge of the domain.


### Steve Smith: "As software developers, we fail in 2 ways:
we build the thing wrong, or we build the wrong thing."

### Bounded context
Eric Evans: "Explicitly define the context within which a model applies... Keep the model strictly consistent within these bounds, but don't be distracted or confused bu issues outside."

### Distinct Data/Code/Teams per Bounded Context?
Steve Smith:
"- Rarely see that level of separation in real world
- You can introduce separation through
	- Namespaces (packages)
	- Folders
	- Projects
- While 100% test coverage is not achievable, strive for it"
	
Julie Lerman:
"- At least keep the concept in mind for guidance
- Not hard rules, but guidance. Let DDD guide you"

#### Difference between sub-domains and bounded contexts

Eric Evans: "
- Sub-domain is a problem space concept.
- Bounded context is a solution space concept."

DDD is more about effective communication, and not about specific code we produce.