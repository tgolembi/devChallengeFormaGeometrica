using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Models;

namespace DevelopmentChallenge.Data.Services
{
	public static class ReportGenerator
	{
		public static string Imprimir (IEnumerable<IFormaGeometrica> formas, Idioma idioma)
		{
			ITraductor traductor;

			switch (idioma)
			{
				case Idioma.Castellano:
					traductor = new CastellanoTraductor();
					break;
				case Idioma.Ingles:
					traductor = new InglesTraductor();
					break;
				case Idioma.Italiano:
					traductor = new ItalianoTraductor();
					break;
				default:
					traductor = new CastellanoTraductor();
					break;
			}

			if (formas == null || !formas.Any())
			{
				if (idioma == Idioma.Ingles)
					return "<h1>Empty list of shapes!</h1>";
				if (idioma == Idioma.Italiano)
					return "<h1>Elenco vuoto di forme</h1>";

				return "<h1>Lista vacía de formas!</h1>";
			}

			var sb = new System.Text.StringBuilder();
			sb.Append(traductor.ObtenerEncabezado());

			var resumenPorTipo = formas
				.GroupBy(f => f.Tipo)
				.Select(g => new
				{
					Tipo = g.Key,
					Cantidad = g.Count(),
					Area = g.Sum(f => f.CalcularArea()),
					Perimetro = g.Sum(f => f.CalcularPerimetro())
				});

			int totalFormas = 0;
			decimal totalArea = 0, totalPerimetro = 0;

			foreach (var r in resumenPorTipo)
			{
				sb.Append(traductor.FormatearLinea(r.Cantidad, r.Tipo, r.Area, r.Perimetro));
				totalFormas += r.Cantidad;
				totalArea += r.Area;
				totalPerimetro += r.Perimetro;
			}

			sb.Append(traductor.ObtenerTotal(totalFormas, totalArea, totalPerimetro));
			return sb.ToString();
		}
	}
}
