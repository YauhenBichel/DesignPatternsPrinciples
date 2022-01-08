#Notes based on https://www.educative.io/courses/grokking-adv-system-design-intvw

## Bloom Filters
In BigTable (and Cassandra), any read operation has to read from all SSTables that make up a Tablet. If these SSTables are not in memory, the read operation may end up doing many disk accesses. To reduce the number of disk accesses, BigTable uses Bloom filters.
Bloom filters are created for SSTables (particularly for the locality groups). They help reduce the number of disk accesses by predicting if an SSTable may contain data corresponding to a particular row or column pair.
## Consistent Hashing

## Quorum
## Leader and Follower
## Write-ahead Log
## Segmented Log
## High-Water mark
## Lease
## Heartbeat
## Gossip Protocol
## Phi Accrual Failure Detection
## Split-brain
## Fencing
## Checksum
## Vector Clocks
## CAP Theorem
## PACELEC Theorem
## Hinted Handoff
## Read Repair
## Merkle Trees

