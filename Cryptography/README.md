# Cryptography

## Defintions
- Stenography - hide the message
- Cryptology
	- Cryptography - science of keeping messages secure
	- Cryptanalysis - breaking a secure message
- Terms
	- Plaintext - original text
	- Encryption - process of obscuring data
	- Ciphertext - encrypted data
	- Decription - process to recover original data
	
## Brief History of Cryptography
- Spartan Scytale
- Ceasar Cipher
- Substitution Ciphers
- Vigenere Cipher
- German Enigma
- DES
- AES
- Public Key Cryptography (RSA)

## Why Cryptography
- Confidentiality - protect data from being read
- Integrity - verify that data was not modified
- Authentication - identify and validate user
- Non-repudiation - sender cannot deny later that he sent a message

## When you have decided to use cryptography, 
### You have to understand what is a goal?
- Confidentiality
- Integrity
- etc.

because you should map to appropriate mechanism.

### How much is data worth? What is a risk if some data was compromised?

### How long does it need to be secured?

### What are the primary threats?
- In transit
- Access to web assets (config files, etc)
- Dump of memory (data in memory is not encrypted)
- Modify pages
- Reverse engineer assemblies
- ...

### Company security policies?
ex.: what algorithms are used?

### Regulatory compliance?

### Layered defenses, how many are enough?

## Do not be overconfident!
## Do not write own cryptography algorithms!


# Hashing

- Hash function converts a variable length input to a fixed length
	- Creates a "digest"
- "One way" so easy to compute, but can not reverse

## Common Hash Algorithms
- Abstract base HashAlgorithm
	- MD5 (128 bit hash) - it is comprimised. It is not recommended to use!
	- SHA (Secure Hash Algorithms)
		- SHA1 (160 bit hash)
		- SHA256
		- SHA384
		- SHA512
	- KeyedHashAlgorithm (Message Authentication Code)
		- HMACSHA
		- MACTripleDES
		
# Tamperproof QueryStrings
- Goal is to protect integrity of querystring
- Use a Hash-based Message Authentication Code (HMAC)
	- Compute the hash of a querystring when constructed
	- Validate querystring was not modified by computing hash querystring and comparing to oroginal hash
	- Uses a key to ensure that attacker could not create own valid hash

# Hashed Passwords
- Common attack against hashed passwords is "dictionary attack"

## So we should not keep just hash of password due to the fact it can be compromised using "dictionary attack"

# Salted Passwords
- Add some unique random data to each password
`hash(password + salt)`

Note! This does nothing to increase security for an individual password of salt is wasily found.

- to generate salt use cryptographically string random number genrator
`RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
byte[] salt = new byte[byteCount];
rng.GetBytes(salt);
Convert.ToBase64String(salt);`
- save this in column in same row with hashed password