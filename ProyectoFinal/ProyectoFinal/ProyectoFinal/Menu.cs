/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 18/11/2026
 * Time: 04:30 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Menu.
	/// </summary>
	public partial class Menu : Form
	{
		private readonly BibliotecaDAO _biblioDao = new BibliotecaDAO();
		
		public Menu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			AplicarPermisosRol();
			CargarCatalogo();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void AplicarPermisosPorRol()
		{
			// Restricción de controles visuales según rol (Requerimiento C.5 y C.6)
			bool esAdmin = (SesionActual.Rol == "administrador");
			bool puedeOperar = (SesionActual.Rol == "administrador" || SesionActual.Rol == "operador");

			btnRegistrarLibro.Enabled = puedeOperar;
			btnPrestar.Enabled = puedeOperar;
			btnDevolver.Enabled = puedeOperar;

			btnAdminUsuarios.Enabled = esAdmin;
			btnVerAuditoria.Enabled = esAdmin;
		}
		
		private void TxtCodigoBarrasKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true; // Evita el sonido 'beep' de Windows
				BuscarPorCodigoBarras();
			}
		}

		private void BuscarPorCodigoBarras()
		{
			if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text)) return;

			int idLibro;
			string titulo;
			int disponibles;
			string mensaje;

			if (_biblioDao.ConsultarLibroPorCodigo(txtCodigoBarras.Text, out idLibro, out titulo, out disponibles, out mensaje))
			{
				MessageBox.Show(
					string.Format("Libro: {0}\nEjemplares disponibles: {1}", titulo, disponibles),
					"Lectura de Código de Barras",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				// Mueve el foco automáticamente a Matrícula para agilizar un préstamo
				txtMatricula.Focus();
			}
			else
			{
				MessageBox.Show(mensaje, "Código no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtCodigoBarras.SelectAll();
			}
		}
		
		private void CargarCatalogo()
        {
            try
            {
                dgvDatos.DataSource = _biblioDao.ObtenerCatalogoLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		
		void BtnSalirClick(object sender, EventArgs e)
		{
			
		}
		void BtnMatriculaClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMatricula.Text)) return;

			string nombre, carrera, estado, mensaje;
			if (_biblioDao.BuscarAlumno(txtMatricula.Text, out nombre, out carrera, out estado, out mensaje))
			{
				MessageBox.Show(
					string.Format("Alumno: {0}\nCarrera: {1}\nEstado: {2}", nombre, carrera, estado.ToUpper()),
					"Datos del Alumno",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			else
			{
				MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		void BtnPrestamoClick(object sender, EventArgs e)
		{
			private void BtnRegistrarPrestamoClick(object sender, EventArgs e)
			{
				if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text) || string.IsNullOrWhiteSpace(txtMatricula.Text))
				{
					MessageBox.Show("Escanea el código de barras del libro e ingresa la matrícula del alumno.",
					                "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string mensaje;
				// Préstamo estándar por 5 días
				if (_biblioDao.RegistrarPrestamo(txtMatricula.Text, txtCodigoBarras.Text, 5, out mensaje))
				{
					MessageBox.Show(mensaje, "Préstamo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCodigoBarras.Clear();
					txtMatricula.Clear();
					CargarCatalogo();
				}
				else
				{
					MessageBox.Show(mensaje, "No se pudo realizar el préstamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
