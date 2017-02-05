using System;

namespace Cryptography.TamperproofQuerystring
{
	public partial class TamperproofQueryString : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			hlHash.NavigateUrl = "/hash/useTamperproofQueryString.aspx?" + 
				TamperProof.HashQueryString("a=1&b=2&c=3");
		}
	}
}