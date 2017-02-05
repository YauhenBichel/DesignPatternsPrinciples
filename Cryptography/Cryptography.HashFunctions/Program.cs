using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.HashFunctions
{
	class Program
	{
		static void Main(string[] args)
		{
			string plainText = "I feel the need ... the need of speed!";

			SHA512Managed hashSvc = new SHA512Managed();

			//SHA512 returns 512 bits (64 bytes = 512 / 8) for the hash
			//hash shown by default as 2 hex characters per byte: FB-2F-C8...
			byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plainText));

			var hashString = BitConverter.ToString(hash);

			Console.WriteLine(hashString);

			//remove the "-" separator creates a 128 character string represented in hex
			string hex = hashString.Replace("-", "");

			Console.WriteLine(hex);

			Console.ReadKey();
		}
	}
}
