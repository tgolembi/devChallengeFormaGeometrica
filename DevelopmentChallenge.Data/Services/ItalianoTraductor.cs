using DevelopmentChallenge.Data.Enums;
using System.Globalization;

namespace DevelopmentChallenge.Data.Services
{
	public class ItalianoTraductor : ITraductor
	{
		public CultureInfo Cultura => new CultureInfo("it-IT");

		public string ObtenerEncabezado()
		{
			return "<h1>Rapporto sulle forme</h1>";
		}

		public string FormatearLinea(int cantidad, string tipo, decimal area, decimal perimetro)
		{
			var nombre = Enum.TryParse<TipoFormaGeometrica>(tipo, true, out var forma) ? forma switch
			{
				TipoFormaGeometrica.Cuadrado => cantidad == 1 ? "Quadrato" : "Quadrati",
				TipoFormaGeometrica.Circulo => cantidad == 1 ? "Cerchio" : "Cerchi",
				TipoFormaGeometrica.TrianguloEquilatero => cantidad == 1 ? "Triangolo" : "Triangoli",
				TipoFormaGeometrica.Trapezio => cantidad == 1 ? "Trapezio" : "Trapezi",
				_ => cantidad == 1 ? tipo : tipo
			} : tipo;

			return $"{cantidad} {nombre} | Area {area.ToString("N2", Cultura)} | Perimetro {perimetro.ToString("N2", Cultura)} <br/>";
		}

		public string ObtenerTotal(int cantidad, decimal area, decimal perimetro)
		{
			return $"TOTAL:<br/>{cantidad} forme Perimetro {perimetro.ToString("N2", Cultura)} Area {area.ToString("N2", Cultura)}";
		}
	}
}
