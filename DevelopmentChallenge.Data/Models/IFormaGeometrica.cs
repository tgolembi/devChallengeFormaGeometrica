using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models
{
	public interface IFormaGeometrica
	{
		string Tipo { get; }
		decimal CalcularArea();
		decimal CalcularPerimetro();
	}
}
