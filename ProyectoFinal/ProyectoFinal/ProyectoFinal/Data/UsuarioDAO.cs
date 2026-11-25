/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 02:59 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using ProyectoFinal.Data;

namespace ProyectoFinal.Data
{
	/// <summary>
	/// Description of UsuarioDAO.
	/// </summary>
	public class UsuarioDAO
	{
		public string CalcularSha256(string textoPlano)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public bool IniciarSesion(string username, string passwordPlano, string rolSeleccionado, out string mensajeError)
        {
            mensajeError = string.Empty;
            string hashIngresado = CalcularSha256(passwordPlano);

            string query = @"SELECT id_usuario, nombre_completo, username, rol, estado 
                             FROM usuarios_sistema 
                             WHERE username = @user AND password_hash = @hash LIMIT 1;";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexionLogin())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username.Trim());
                        cmd.Parameters.AddWithValue("@hash", hashIngresado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                mensajeError = "Usuario o contraseña incorrectos.";
                                return false;
                            }

                            string estado = reader.GetString("estado");
                            string rolReal = reader.GetString("rol");

                            if (estado != "activo")
                            {
                                mensajeError = "Esta cuenta se encuentra inactiva.";
                                return false;
                            }

                            // Valida contra el ComboBox 'Ingresar como' de tu MainForm
                            if (!string.IsNullOrEmpty(rolSeleccionado) && rolReal != rolSeleccionado.ToLower())
                            {
                                mensajeError = "El rol seleccionado no coincide con los permisos de este usuario.";
                                return false;
                            }

                            SesionActual.IdUsuario = reader.GetInt32("id_usuario");
                            SesionActual.NombreCompleto = reader.GetString("nombre_completo");
                            SesionActual.Username = reader.GetString("username");
                            SesionActual.Rol = rolReal;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error de conexión con la base de datos: " + ex.Message;
                return false;
            }
        }

        public bool RegistrarUsuario(string nombreCompleto, string username, string passwordPlano, string rol, out string mensaje)
        {
            mensaje = string.Empty;
            string hash = CalcularSha256(passwordPlano);

            string query = @"INSERT INTO usuarios_sistema (nombre_completo, username, password_hash, rol, estado) 
                             VALUES (@nombre, @user, @hash, @rol, 'activo');";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreCompleto.Trim());
                        cmd.Parameters.AddWithValue("@user", username.Trim());
                        cmd.Parameters.AddWithValue("@hash", hash);
                        cmd.Parameters.AddWithValue("@rol", rol.ToLower());

                        cmd.ExecuteNonQuery();
                        mensaje = "Usuario registrado correctamente.";
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    mensaje = "El nombre de usuario ya existe.";
                else
                    mensaje = "Error SQL: " + ex.Message;
                return false;
            }
        }
	}
}
