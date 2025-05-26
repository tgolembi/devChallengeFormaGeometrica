
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Models
{
	public class TrianguloEquilatero : IFormaGeometrica
	{
		private readonly decimal _lado;
		
		public string Tipo => TipoFormaGeometrica.TrianguloEquilatero.ToString();

		public TrianguloEquilatero (decimal lado)
		{
			_lado = lado;
		}

		public decimal CalcularArea ()
		{
			return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
		}

		public decimal CalcularPerimetro ()
		{
			return 3 * _lado;
		}
	}
}
