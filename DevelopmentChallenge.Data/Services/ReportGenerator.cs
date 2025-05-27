using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Models;
using System.Globalization;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
	public static class ReportGenerator
	{
		public static string Imprimir(IEnumerable<IFormaGeometrica> formas, Idioma idioma)
		{
			var cultura = idioma switch
			{
				Idioma.Castellano => new CultureInfo("es"),
				Idioma.Ingles => new CultureInfo("en"),
				Idioma.Italiano => new CultureInfo("it"),
				_ => new CultureInfo("es")
			};

			CultureInfo.CurrentUICulture = cultura;

			if (formas == null || !formas.Any())
			{
				return $"<h1>{ResourceLocator.Obter("EmptyList", cultura)}</h1>";
			}

			var sb = new StringBuilder();
			sb.Append($"<h1>{ResourceLocator.Obter("ShapesReport", cultura)}</h1>");

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
				var chaveTipo = $"{r.Tipo}_{(r.Cantidad == 1 ? "Singular" : "Plural")}";
				string nomeFormaTraduzida = ResourceLocator.Obter(chaveTipo, cultura);

				sb.Append($"{r.Cantidad} {nomeFormaTraduzida} | ");
				sb.Append($"{ResourceLocator.Obter("Area", cultura)} {r.Area.ToString("N2", cultura)} | ");
				sb.Append($"{ResourceLocator.Obter("Perimeter", cultura)} {r.Perimetro.ToString("N2", cultura)} <br/>");

				totalFormas += r.Cantidad;
				totalArea += r.Area;
				totalPerimetro += r.Perimetro;
			}

			sb.Append($"{ResourceLocator.Obter("Total", cultura)}:<br/>");
			sb.Append($"{totalFormas} {ResourceLocator.Obter("Shapes", cultura)} | ");
			sb.Append($"{ResourceLocator.Obter("Area", cultura)} {totalArea.ToString("N2", cultura)} | ");
			sb.Append($"{ResourceLocator.Obter("Perimeter", cultura)} {totalPerimetro.ToString("N2", cultura)}");

			return sb.ToString();
		}
	}
}
