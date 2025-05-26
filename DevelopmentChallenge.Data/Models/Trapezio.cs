using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Models
{
	public class Trapezio : IFormaGeometrica
	{
		private readonly decimal _baseMaior;
		private readonly decimal _baseMenor;
		private readonly decimal _altura;
		private readonly decimal _ladoA;
		private readonly decimal _ladoB;

		public string Tipo => TipoFormaGeometrica.Trapezio.ToString();

		public Trapezio (decimal baseMaior, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
		{
			if (baseMaior <= 0 || baseMenor <= 0 || altura <= 0 || lado1 <= 0 || lado2 <= 0)
				throw new ArgumentException("Todos os lados e a altura devem ser maiores que zero.");

			_baseMaior = baseMaior;
			_baseMenor = baseMenor;
			_altura = altura;
			_ladoA = lado1;
			_ladoB = lado2;
		}

		public decimal CalcularArea ()
		{
			return (_baseMaior + _baseMenor) * _altura / 2;
		}

		public decimal CalcularPerimetro ()
		{
			return _baseMaior + _baseMenor + _ladoA + _ladoB;
		}
	}
}
