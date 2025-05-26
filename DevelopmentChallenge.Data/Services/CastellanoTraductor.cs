using DevelopmentChallenge.Data.Enums;
using System.Globalization;

namespace DevelopmentChallenge.Data.Services
{
	public class CastellanoTraductor : ITraductor
	{
		public CultureInfo Cultura => new CultureInfo("es-ES");

		public string ObtenerEncabezado ()
		{
			return "<h1>Reporte de Formas</h1>";
		}

		public string FormatearLinea (int cantidad, string tipo, decimal area, decimal perimetro)
		{
			var nombre = Enum.TryParse<TipoFormaGeometrica>(tipo, true, out var forma) ? forma switch
			{
				TipoFormaGeometrica.Cuadrado => cantidad == 1 ? "Cuadrado" : "Cuadrados",
				TipoFormaGeometrica.Circulo => cantidad == 1 ? "Círculo" : "Círculos",
				TipoFormaGeometrica.TrianguloEquilatero => cantidad == 1 ? "Triángulo" : "Triángulos",
				_ => cantidad == 1 ? tipo : tipo + "s"
			} : tipo + "s";

			return $"{cantidad} {nombre} | Area {area.ToString("N2", Cultura)} | Perimetro {perimetro.ToString("N2", Cultura)} <br/>";
		}

		public string ObtenerTotal (int cantidad, decimal area, decimal perimetro)
		{
			return $"TOTAL:<br/>{cantidad} formas Perimetro {perimetro.ToString("N2", Cultura)} Area {area.ToString("N2", Cultura)}";
		}
	}
}
