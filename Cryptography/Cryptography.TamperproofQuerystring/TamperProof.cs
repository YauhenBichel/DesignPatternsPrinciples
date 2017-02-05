using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;

//based on "Cryptography introduction" pluralsight course
namespace Cryptography.TamperproofQuerystring
{
	public static class TamperProof
	{
		private const string QUERYSTRING_VALIDATION_NAME = "qtpval";
		private const string QUERYSTRING_VALIDATION_NAME_WITH_SEP = "&" + QUERYSTRING_VALIDATION_NAME;

		private static string ComputeHash(string data)
		{
			//add some entropy by also using the ASP Session Id
			HttpSessionState sessionState = HttpContext.Current.Session;
			data += sessionState.SessionID;
			sessionState["A"] = 5;

			byte[] plainTextBytes = Encoding.UTF8.GetBytes(data);

			//read the key to use from the web.config
			HMACSHA1 hashAlg = new HMACSHA1(Encoding.UTF8.GetBytes(WebConfigurationManager.AppSettings["Key64"]));

			byte[] hash = hashAlg.ComputeHash(plainTextBytes);

			return BitConverter.ToString(hash).Replace("-", "");
		}

		public static string HashQueryString(string queryString)
		{
			return queryString + QUERYSTRING_VALIDATION_NAME_WITH_SEP + "=" + ComputeHash(queryString);
		}

		public static void ValidateQueryString()
		{
			HttpRequest request = HttpContext.Current.Request;

			if (request.QueryString.Count == 0)
			{
				return;
			}

			string queryString = request.Url.Query.TrimStart(new char[] {'?'});

			string submittedHash = request.QueryString[QUERYSTRING_VALIDATION_NAME];

			if(submittedHash == null)
			{
				throw new ApplicationException("QueryString validation hash wan not sent.");
			}

			int hashPos = queryString.IndexOf(QUERYSTRING_VALIDATION_NAME_WITH_SEP);
			queryString = queryString.Substring(0, hashPos);

			if(ComputeHash(queryString) != submittedHash)
			{
				throw new ApplicationException("Querystring hash values do not match.");
			}


		}
	}
}