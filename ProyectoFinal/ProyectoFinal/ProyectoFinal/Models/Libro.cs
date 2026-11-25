/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 03:16 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal.Models
{
	/// <summary>
	/// Description of Libro.
	/// </summary>
	public class Libro
	{
		public int IdLibro { 
			get; 
			set; 
		}
		
        public string CodigoBarras { 
			get; 
			set; 
		}
		
        public string Titulo { 
			get; 
			set; 
		}
		
        public string Autor { 
			get; 
			set; 
		}
		
        public string Editorial { 
			get; 
			set; 
		}
		
        public string Categoria { 
			get; 
			set; 
		}
		
        public int CantidadTotal { 
			get; 
			set; 
		}
		
        public int CantidadDisponible { 
			get; 
			set; 
		}
	}
}
