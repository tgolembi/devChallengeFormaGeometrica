using Xunit;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Services;

namespace DevelopmentChallenge.Data.Tests
{
	public class DataTests
	{
		[Fact]
		public void TestResumenListaVacia()
		{
			var resumen = ReportGenerator.Imprimir(new List<IFormaGeometrica>(), Idioma.Castellano);
			Assert.Equal("<h1>Lista vacía de formas!</h1>", resumen);
		}

		[Fact]
		public void TestResumenListaVaciaFormasEnIngles()
		{
			var resumen = ReportGenerator.Imprimir(new List<IFormaGeometrica>(), Idioma.Ingles);
			Assert.Equal("<h1>Empty list of shapes!</h1>", resumen);
		}

		[Fact]
		public void TestResumenListaConUnCuadrado()
		{
			var formas = new List<IFormaGeometrica> { new Cuadrado(5) };
			var resumen = ReportGenerator.Imprimir(formas, Idioma.Castellano);
			Assert.Equal("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25,00 | Perimetro 20,00 <br/>TOTAL:<br/>1 formas Perimetro 20,00 Area 25,00", resumen);
		}

		[Fact]
		public void TestResumenListaConMasCuadrados()
		{
			var formas = new List<IFormaGeometrica>
			{
				new Cuadrado(5),
				new Cuadrado(1),
				new Cuadrado(3)
			};
			var resumen = ReportGenerator.Imprimir(formas, Idioma.Ingles);
			Assert.Equal("<h1>Shapes report</h1>3 Squares | Area 35.00 | Perimeter 36.00 <br/>TOTAL:<br/>3 shapes Perimeter 36.00 Area 35.00", resumen);
		}

		[Fact]
		public void TestResumenListaConMasTipos()
		{
			var formas = new List<IFormaGeometrica>
			{
				new Cuadrado(5),
				new Circulo(3),
				new TrianguloEquilatero(4),
				new Cuadrado(2),
				new TrianguloEquilatero(9),
				new Circulo(2.75m),
				new TrianguloEquilatero(4.2m)
			};

			var resumen = ReportGenerator.Imprimir(formas, Idioma.Ingles);
			Assert.Contains("Shapes report", resumen);
			Assert.Contains("TOTAL:", resumen);
		}

		[Fact]
		public void TestResumenListaConMasTiposEnCastellano()
		{
			var formas = new List<IFormaGeometrica>
			{
				new Cuadrado(5),
				new Circulo(3),
				new TrianguloEquilatero(4),
				new Cuadrado(2),
				new TrianguloEquilatero(9),
				new Circulo(2.75m),
				new TrianguloEquilatero(4.2m)
			};

			var resumen = ReportGenerator.Imprimir(formas, Idioma.Castellano);
			Assert.Contains("Reporte de Formas", resumen);
			Assert.Contains("TOTAL:", resumen);
		}
	}
}
