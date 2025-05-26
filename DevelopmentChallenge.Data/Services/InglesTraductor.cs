using DevelopmentChallenge.Data.Enums;
using System.Globalization;

namespace DevelopmentChallenge.Data.Services
{
	public class InglesTraductor : ITraductor
	{
		public CultureInfo Cultura => new CultureInfo("en-US");

		public string ObtenerEncabezado ()
		{
			return "<h1>Shapes report</h1>";
		}

		public string FormatearLinea (int cantidad, string tipo, decimal area, decimal perimetro)
		{
			var nombre = Enum.TryParse<TipoFormaGeometrica>(tipo, true, out var forma) ? forma switch
			{
				TipoFormaGeometrica.Cuadrado => cantidad == 1 ? "Square" : "Squares",
				TipoFormaGeometrica.Circulo => cantidad == 1 ? "Circle" : "Circles",
				TipoFormaGeometrica.TrianguloEquilatero => cantidad == 1 ? "Triangle" : "Triangles",
				TipoFormaGeometrica.Trapezio => cantidad == 1 ? "Trapezoid" : "Trapezoids",
				_ => cantidad == 1 ? tipo : tipo + "s"
			} : tipo + "s";

			return $"{cantidad} {nombre} | Area {area.ToString("N2", Cultura)} | Perimeter {perimetro.ToString("N2", Cultura)} <br/>";
		}

		public string ObtenerTotal (int cantidad, decimal area, decimal perimetro)
		{
			return $"TOTAL:<br/>{cantidad} shapes Perimeter {perimetro.ToString("N2", Cultura)} Area {area.ToString("N2", Cultura)}";
		}
	}
}
