/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 02:56 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal.Models
{
	/// <summary>
	/// Description of SesionActual.
	/// </summary>
	public class SesionActual
	{
		public static int IdUsuario { 
			get; 
			set; 
		}
		
        public static string NombreCompleto { 
			get; 
			set; 
		}
		
        public static string Username { 
			get; 
			set; 
		}
		
        public static string Rol { 
			get; 
			set; 
		}

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            NombreCompleto = string.Empty;
            Username = string.Empty;
            Rol = string.Empty;
        }
	}
}
