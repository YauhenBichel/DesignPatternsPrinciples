using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
	internal class Person: IAsset
	{
		public IList<IAsset> Assets { get; set; }

		public Person()
		{
			Assets = new List<IAsset>();
		}

		public void Accept(IVisitor visitor)
		{
			foreach (var asset in Assets)
				asset.Accept(visitor);
		}
	}
}