using System;

namespace Cryptography.TamperproofQuerystring.hash
{
	public partial class useTamperproofQueryString : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Write("a = " + Request.QueryString["a"] + "; b = " + Request.QueryString["b"] + "; c = " + Request.QueryString["c"]);
		}
	}
}