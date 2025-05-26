using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models
{
	public class Cuadrado : IFormaGeometrica
	{
		private readonly decimal _lado;

		public string Tipo => TipoFormaGeometrica.Cuadrado.ToString();

		public Cuadrado(decimal lado)
		{
			_lado = lado;
		}

		public decimal CalcularArea()
		{
			return _lado * _lado;
		}

		public decimal CalcularPerimetro()
		{
			return _lado * 4;
		}
	}
}
