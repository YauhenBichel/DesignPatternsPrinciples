## The need for transactions
 - An operation call must maintain a consistent state
	- Either the original state or a new one (in full)
	- Nothing in between
 - .NET supports transactional programming since ADO.NET 2.0
 - WCF is a fully qualified transaction resource manager

## Transaction Architecture includes:
- Resource Managers
- Transaction Types
- Transaction Protocols
- Transaction Managers

### Resource Manager
Resource Manager is a system, product, or any component that manages data participating in transactions.
Resource Manager either commits or rolls back changes.
Ex.:
- the relational database management system, such as SQL Server, is a resource manager.
- a Messaging Queing Service, such as MSMQ.
- custom in-memory Resource Managers.

### Two flavors of RMs, depending on the type of resources or data that they manage.
 - Durable: resilient to system failures.
The durable resource managers can manage transaction data that survives system failures, such as machine restarts.
Ex., SQL Server 2008 is a durable Resource Manager because it can persist data during system failure.And it memorize the state of a transaction. Later, when the machine is up again, the transaction picks up from where it stopped.
The same applies for Microsoft Message Queuing.
 - Volatile: non-resilient to system failures. Can only manage in-memory transaction data, that cannot survive system failures.
Ex., system.net transactions introduced in .NET framework 2.0


### ACID Attributes
ACID provides attributes of transactions to be sure that system is stable and valid after a transaction execution.
There are the following attributes:
 - Atomicity
 - Consistency
 - Isolation
 - Durability

#### Atomicity
Transaction succeeds or fails as a unit
i.e. all operations either commit or rollback together

#### Consistency
Resource manager remains in a consistent state after transaction completion

#### Isolation
Transactions running at the same time, is the same as if these transactions were made to run sequentially. Data is locked during the transaction.

#### Durability
A transaction result can sustain system failures
Durability indicates that once a transaction commits a result, it will never be lost.

### Transaction Types
Two types of transactions
 - Long Running
 - Atomic (Atomic transactions are not the same as ACID)

### Long Running Transactions (few hours or days)
 - Long time to complete
 - Waiting time for actions and/or messages
 - Explicit commit & rollback

### Atomic Transactions
 - Take little time to finish
 - Implicit commit & rollback

### Long Running Transactions and ACID
 - Atomicity: No (compensation musts be done)
commit and rollback are responsibility of the application
 - Consistency: Cound be Yes (can be achieved)
 - Isolation: No (isolation needs locks, long running avoid locks)
 - Durability: Could be Yes (recall that we explicitly commit a transaction)

### Atomic Transactions and ACID
The Atomic Transaction is managed by a component called Transaction Manager.
Transaction Manager enlists RM in a transaction.
Transaction Manager implicitly commits or rolls back the transaction in RMs.
 - Atomicity: Yes (managed by the TM)
 - Consistency: Yes (managed by the RM)
 - Isolation: Yes (isolation needs locks, RMs do that for Atomic transactions)
 - Durability: Yes (TM commits and durable RM preserves)

That is why the term atomic transactions frequently used as a synonym for ACID.

### Transaction Protocols
 - Transaction protocols decide type and scope of communication
 - Types of transaction protocols
	- Lightweight Protocol
	- OleTx Protocol
	- WSAT Protocol
	
### Lightweight Protocol
 - Single application in an AppDomain
 - Single durable RM
 - Multiple volatile RMs
 - No cross AppDomain calls (no client-service calls)
 
### OleTx Protocol
 - Allows cross AppDomain
 - Allows cross machine boundary calls
 - Multiple durable RMs
 - Windows Remote Procedure Calls (RPC) calls only
	- No cross platform communication
	- Usually not allowed through firewalls
	
### WSAT Protocol
 - WS-Atomic protocol, one of the WS-* standards
 - Same as OleTx plus
	- interoperable communication (Windows OS + plus Non-Windows OS / WCF + Java )
	
### Transaction Managers
 - Transaction Protocols define boundaries and communication rules
 - Transaction Managers manage transactions practically
 TMs:
	- Lightweight Transaction Manager (LTM):
		- .NET Framework
		- uses lightweight protocol
	- Distributed Transaction Manager (DTC):
		- managing transactions across process and machine boundaries
		- use either the OleTx Protocol or the WSAT Protocol
	
	
### Transaction Support in WCF
#### Binding Switch
 - TransactionFlow must be allowed on the binding
#### WCF Bindings that support TransactionFlow
 - Inter-process Communication (IPC): NetNamedPipeBinding
 - Cross Machine calls
	- TCP: NetTcpBinding, NetTcpContextBinding, NetMsMqBinding, MsmqIntegrationBinding
 - Interoperable communication:
	- WS-AT: WSHttpBinding, WSHttpContextBinding, WSDualHttpBinding, WSFederationHttpBinding
