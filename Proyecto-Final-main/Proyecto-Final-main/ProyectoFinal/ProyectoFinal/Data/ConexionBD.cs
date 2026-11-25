/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 02:57 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
	/// <summary>
	/// Description of Conexion.
	/// </summary>
	public class Conexion
	{
		private const string Servidor = "localhost";
        private const string BaseDatos = "bibliotecnm";

        public static MySqlConnection ObtenerConexion()
        {
            string usuarioMysql = "usr_consulta";
            string passwordMysql = "ConsBiblio2026!";

            if (SesionActual.Rol == "administrador")
            {
                usuarioMysql = "usr_admin";
                passwordMysql = "AdminBiblio2026!";
            }
            else if (SesionActual.Rol == "operador")
            {
                usuarioMysql = "usr_operador";
                passwordMysql = "OpBiblio2026!";
            }

            string cadena = string.Format(
                "Server={0};Database={1};Uid={2};Pwd={3};Charset=utf8mb4;",
                Servidor, BaseDatos, usuarioMysql, passwordMysql
            );

            return new MySqlConnection(cadena);
        }

        // Conexión exclusiva para validar credenciales antes de conocer el rol
        public static MySqlConnection ObtenerConexionLogin()
        {
            string cadena = string.Format(
                "Server={0};Database={1};Uid=usr_admin;Pwd=AdminBiblio2026!;Charset=utf8mb4;",
                Servidor, BaseDatos
            );
            return new MySqlConnection(cadena);
        }
	}
}
