
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Models
{
	public class Circulo : IFormaGeometrica
	{
		private readonly decimal _radio;

		public string Tipo => TipoFormaGeometrica.Circulo.ToString();

		public Circulo (decimal radio)
		{
			_radio = radio;
		}

		public decimal CalcularArea ()
		{
			return (decimal)Math.PI * _radio * _radio;
		}

		public decimal CalcularPerimetro ()
		{
			return 2 * (decimal)Math.PI * _radio;
		}
	}
}
