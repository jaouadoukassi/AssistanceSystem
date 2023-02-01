using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrusProject.LOGICA
{
    public class Lpersonal
    {
		//definir los campos de la tabla Personal.
		public int Id_personal { get; set; }
		public string Nombres { get; set; }
		public int Identificación { get; set; }
		public string Pais { get; set; }
		public int Id_cargo { get; set; }
		public double SueldoPorHora { get; set; }
		public string Estado { get; set; }
		public int Codigo { get; set; }


    }
}
