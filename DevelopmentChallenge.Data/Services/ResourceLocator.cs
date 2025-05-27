using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Services
{
	public static class ResourceLocator
	{
		private static readonly ResourceManager _rm = new ResourceManager("DevelopmentChallenge.Data.Resources.Messages", typeof(ResourceLocator).Assembly);

		public static string Obter(string chave, CultureInfo cultura = null)
		{
			cultura ??= CultureInfo.CurrentUICulture;
			return _rm.GetString(chave, cultura);
		}
	}
}
