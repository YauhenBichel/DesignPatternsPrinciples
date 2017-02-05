using System;

namespace Cryptography.TamperproofQuerystring
{
	public class BasePage: System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			if (!Request.Url.AbsoluteUri.Contains("/login.aspx"))
			{
				TamperProof.ValidateQueryString();
			}

			base.OnLoad(e);
		}
	}
}