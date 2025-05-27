using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Services
{
	public static class ResourceLocator
	{
		public static string _baseName = "DevelopmentChallenge.Data.Resources.Messages";
		
		private static readonly ResourceManager _rm = new ResourceManager(_baseName, typeof(ResourceLocator).Assembly);

		public static string? Obter(string chave, CultureInfo? cultura = null)
		{
			cultura ??= CultureInfo.CurrentUICulture;
			return _rm.GetString(chave, cultura);
		}
	}
}
