namespace DesignPatterns.Visitor
{
	interface IAsset
	{
		void Accept(IVisitor visitor);
	}
}
