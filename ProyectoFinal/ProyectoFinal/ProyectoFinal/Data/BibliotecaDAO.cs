/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 25/11/2026
 * Time: 03:17 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoFinal.Models;


namespace ProyectoFinal.Data
{
	/// <summary>
	/// Description of BibliotecaDAO.
	/// </summary>
	public class BibliotecaDAO
	{
		public bool ConsultarLibroPorCodigo(string codigoBarras, out int idLibro, out string titulo, out int disponibles, out string mensaje)
        {
            idLibro = 0;
            titulo = string.Empty;
            disponibles = 0;
            mensaje = string.Empty;

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_consultar_libro_codigo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_codigo_barras", codigoBarras.Trim());

                        MySqlParameter outId = new MySqlParameter("p_id_libro", MySqlDbType.Int32);
                        outId.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outId);

                        MySqlParameter outTitulo = new MySqlParameter("p_titulo", MySqlDbType.VarChar, 200);
                        outTitulo.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outTitulo);

                        MySqlParameter outDisp = new MySqlParameter("p_disponibles", MySqlDbType.Int32);
                        outDisp.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outDisp);

                        cmd.ExecuteNonQuery();

                        if (outId.Value == DBNull.Value || outId.Value == null)
                        {
                            mensaje = "No se encontró ningún libro con ese código de barras.";
                            return false;
                        }

                        idLibro = Convert.ToInt32(outId.Value);
                        titulo = outTitulo.Value.ToString();
                        disponibles = Convert.ToInt32(outDisp.Value);
                        mensaje = "Libro encontrado.";
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error al consultar libro: " + ex.Message;
                return false;
            }
        }

        // 2. Llamada a sp_registrar_prestamo (Transacción explícita en MySQL)
        public bool RegistrarPrestamo(string matricula, string codigoBarras, int diasPrestamo, out string mensaje)
        {
            mensaje = string.Empty;

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_registrar_prestamo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_matricula", matricula.Trim());
                        cmd.Parameters.AddWithValue("p_codigo_barras", codigoBarras.Trim());
                        cmd.Parameters.AddWithValue("p_id_usuario", SesionActual.IdUsuario);
                        cmd.Parameters.AddWithValue("p_dias_prestamo", diasPrestamo);

                        MySqlParameter outMsg = new MySqlParameter("p_mensaje", MySqlDbType.VarChar, 150);
                        outMsg.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outMsg);

                        cmd.ExecuteNonQuery();

                        mensaje = outMsg.Value != null ? outMsg.Value.ToString() : "Sin respuesta del servidor.";
                        return !mensaje.StartsWith("Error");
                    }
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error SQL al registrar préstamo: " + ex.Message;
                return false;
            }
        }

        // 3. Llamada a sp_registrar_devolucion (Transacción explícita + fn_dias_retraso)
        public bool RegistrarDevolucion(int idPrestamo, out int diasRetraso, out string mensaje)
        {
            diasRetraso = 0;
            mensaje = string.Empty;

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_registrar_devolucion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_id_prestamo", idPrestamo);

                        MySqlParameter outDias = new MySqlParameter("p_dias_retraso", MySqlDbType.Int32);
                        outDias.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outDias);

                        MySqlParameter outMsg = new MySqlParameter("p_mensaje", MySqlDbType.VarChar, 150);
                        outMsg.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outMsg);

                        cmd.ExecuteNonQuery();

                        if (outDias.Value != DBNull.Value && outDias.Value != null)
                        {
                            diasRetraso = Convert.ToInt32(outDias.Value);
                        }
                        mensaje = outMsg.Value != null ? outMsg.Value.ToString() : "Sin respuesta del servidor.";
                        return !mensaje.StartsWith("Error");
                    }
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error SQL al procesar devolución: " + ex.Message;
                return false;
            }
        }

        // 4. Alta de libro nuevo (Dispara trg_validar_libro_before_insert y trg_auditoria_libros_insert)
        public bool RegistrarLibro(Libro libro, out string mensaje)
        {
            mensaje = string.Empty;
            string query = @"INSERT INTO libros (codigo_barras, titulo, autor, editorial, categoria, cantidad_total, cantidad_disponible)
                             VALUES (@codigo, @titulo, @autor, @editorial, @categoria, @total, @total);";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", libro.CodigoBarras.Trim());
                        cmd.Parameters.AddWithValue("@titulo", libro.Titulo.Trim());
                        cmd.Parameters.AddWithValue("@autor", libro.Autor.Trim());
                        cmd.Parameters.AddWithValue("@editorial", libro.Editorial.Trim());
                        cmd.Parameters.AddWithValue("@categoria", libro.Categoria.Trim());
                        cmd.Parameters.AddWithValue("@total", libro.CantidadTotal);

                        cmd.ExecuteNonQuery();
                        mensaje = "Libro registrado correctamente en el catálogo.";
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    mensaje = "Ya existe un libro registrado con ese código de barras.";
                else
                    mensaje = ex.Message; // Muestra el mensaje del TRIGGER si hay validación fallida
                return false;
            }
        }

        // 5. Actualizar ejemplares de libro (Dispara trg_auditoria_libros_update)
        public bool ActualizarEjemplaresLibro(string codigoBarras, int nuevaCantidadTotal, int nuevaCantidadDisponible, out string mensaje)
        {
            mensaje = string.Empty;
            string query = @"UPDATE libros 
                             SET cantidad_total = @total, cantidad_disponible = @disp 
                             WHERE codigo_barras = @codigo;";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@total", nuevaCantidadTotal);
                        cmd.Parameters.AddWithValue("@disp", nuevaCantidadDisponible);
                        cmd.Parameters.AddWithValue("@codigo", codigoBarras.Trim());

                        int filas = cmd.ExecuteNonQuery();
                        if (filas == 0)
                        {
                            mensaje = "No se encontró el libro para actualizar.";
                            return false;
                        }
                        mensaje = "Inventario actualizado y registrado en auditoría.";
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error al actualizar libro: " + ex.Message;
                return false;
            }
        }

        // 6. Buscar alumno por matrícula (para el botón de lupa junto a Matrícula)
        public bool BuscarAlumno(string matricula, out string nombreCompleto, out string carrera, out string estado, out string mensaje)
        {
            nombreCompleto = string.Empty;
            carrera = string.Empty;
            estado = string.Empty;
            mensaje = string.Empty;

            string query = "SELECT CONCAT(nombre, ' ', apellidos) AS nombre_completo, carrera, estado FROM alumnos WHERE matricula = @mat LIMIT 1;";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mat", matricula.Trim());
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                mensaje = "Matrícula no encontrada.";
                                return false;
                            }
                            nombreCompleto = reader.GetString("nombre_completo");
                            carrera = reader.GetString("carrera");
                            estado = reader.GetString("estado");
                            mensaje = "Alumno encontrado.";
                            return true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error al buscar alumno: " + ex.Message;
                return false;
            }
        }

        // 7. Consultas para llenar el DataGridView (Catálogo con función fn_libro_disponible, Préstamos, Reportes y Auditoría)
        public DataTable ObtenerCatalogoLibros()
        {
            string query = @"SELECT id_libro AS ID, codigo_barras AS 'Código Barras', titulo AS Título, 
                                    autor AS Autor, editorial AS Editorial, categoria AS Categoría,
                                    cantidad_total AS Total, cantidad_disponible AS Disponibles,
                                    IF(fn_libro_disponible(codigo_barras) = 1, 'Disponible', 'Agotado') AS Estatus
                             FROM libros ORDER BY titulo;";
            return EjecutarConsultaTabla(query);
        }

        public DataTable ObtenerPrestamosActivos()
        {
            string query = @"SELECT p.id_prestamo AS 'ID Préstamo', p.matricula AS Matrícula,
                                    CONCAT(a.nombre, ' ', a.apellidos) AS Alumno,
                                    l.codigo_barras AS 'Código Barras', l.titulo AS Libro,
                                    p.fecha_prestamo AS 'Fecha Préstamo', p.fecha_limite AS 'Fecha Límite',
                                    fn_dias_retraso(p.id_prestamo) AS 'Días Retraso'
                             FROM prestamos p
                             INNER JOIN alumnos a ON p.matricula = a.matricula
                             INNER JOIN libros l ON p.id_libro = l.id_libro
                             WHERE p.estado = 'activo'
                             ORDER BY p.fecha_limite ASC;";
            return EjecutarConsultaTabla(query);
        }

        public DataTable ObtenerReporteMasSolicitados()
        {
            return EjecutarConsultaTabla("SELECT * FROM vw_reporte_libros_mas_solicitados;");
        }

        public DataTable ObtenerReporteAlumnosVencidos()
        {
            return EjecutarConsultaTabla("SELECT * FROM vw_reporte_alumnos_vencidos;");
        }

        public DataTable ObtenerBitacoraAuditoria()
        {
            return EjecutarConsultaTabla("SELECT id_auditoria AS ID, tabla_afectada AS Tabla, tipo_operacion AS Operación, fecha_hora AS Fecha, usuario_responsable AS Usuario, info_anterior AS 'Antes', info_nueva AS 'Después' FROM auditoria ORDER BY fecha_hora DESC;");
        }

        private DataTable EjecutarConsultaTabla(string query)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
	}
}
