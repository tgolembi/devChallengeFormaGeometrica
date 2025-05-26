using System.Globalization;

namespace DevelopmentChallenge.Data.Services
{
	public interface ITraductor
	{
		CultureInfo Cultura { get; }
		string ObtenerEncabezado();
		string FormatearLinea(int cantidad, string tipo, decimal area, decimal perimetro);
		string ObtenerTotal(int cantidad, decimal area, decimal perimetro);
	}
}
