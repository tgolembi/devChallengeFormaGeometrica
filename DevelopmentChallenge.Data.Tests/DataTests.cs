using Xunit;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Services;

namespace DevelopmentChallenge.Data.Tests
{
	public class DataTests
	{
		[Theory]
		[InlineData(Idioma.Castellano, "<h1>Lista vacía de formas!</h1>")]
		[InlineData(Idioma.Ingles, "<h1>Empty list of shapes!</h1>")]
		[InlineData(Idioma.Italiano, "<h1>Elenco vuoto di forme!</h1>")]
		public void TestResumenListaVacia(Idioma idioma, string esperado)
		{
			var resumen = ReportGenerator.Imprimir(new List<IFormaGeometrica>(), idioma);
			Assert.Equal(esperado, resumen);
		}

		[Theory]
		[InlineData(Idioma.Castellano, "<h1>Reporte de formas</h1>1 Cuadrado | Area 25,00 | Perimetro 20,00 <br/>TOTAL:<br/>1 formas | Area 25,00 | Perimetro 20,00")]
		[InlineData(Idioma.Italiano, "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 25,00 | Perimetro 20,00 <br/>TOTAL:<br/>1 forme | Area 25,00 | Perimetro 20,00")]
		public void TestResumenListaConUnCuadrado(Idioma idioma, string esperado)
		{
			var formas = new List<IFormaGeometrica> { new Cuadrado(5) };
			var resumen = ReportGenerator.Imprimir(formas, idioma);
			Assert.Equal(esperado, resumen);
		}

		[Theory]
		[InlineData(Idioma.Castellano, "<h1>Reporte de formas</h1>1 Trapecio | Area 24,00 | Perimetro 25,00 <br/>TOTAL:<br/>1 formas | Area 24,00 | Perimetro 25,00")]
		public void TestResumenListaConUnTrapezio(Idioma idioma, string esperado)
		{
			var formas = new List<IFormaGeometrica> { new Trapezio(10, 6, 3, 5, 4) };
			var resumen = ReportGenerator.Imprimir(formas, Idioma.Castellano);
			Assert.Equal(esperado, resumen);
		}

		[Theory]
		[InlineData(Idioma.Ingles, "<h1>Shapes report</h1>3 Squares | Area 35.00 | Perimeter 36.00 <br/>TOTAL:<br/>3 shapes | Area 35.00 | Perimeter 36.00")]
		public void TestResumenListaConMasCuadrados(Idioma idioma, string esperado)
		{
			var formas = new List<IFormaGeometrica>
			{
				new Cuadrado(5),
				new Cuadrado(1),
				new Cuadrado(3)
			};
			var resumen = ReportGenerator.Imprimir(formas, idioma);
			Assert.Equal(esperado, resumen);
		}

		[Theory]
		[InlineData(Idioma.Ingles, "Shapes report")]
		[InlineData(Idioma.Castellano, "Reporte de formas")]
		[InlineData(Idioma.Italiano, "Rapporto sulle forme")]
		public void TestResumenListaConMasTipos(Idioma idioma, string encabezadoEsperado)
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

			var resumen = ReportGenerator.Imprimir(formas, idioma);
			Assert.Contains(encabezadoEsperado, resumen);
			Assert.Contains("TOTAL:", resumen);
		}
	}
}
