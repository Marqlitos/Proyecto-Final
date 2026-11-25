/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 18/11/2026
 * Time: 05:03 p. m.
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
	/// Description of Registar.
	/// </summary>
	public partial class Registar : Form
	{
		private readonly UsuarioDAO _usuarioDao = new UsuarioDAO();
		
		public Registar()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ConfigurarControles();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void ConfigurarControles()
		{
			txtPassword.PasswordChar = '*';
			cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbRol.Items.Clear();
			cmbRol.Items.AddRange(new object[] { "administrador", "operador", "consulta" });
			cmbRol.SelectedIndex = 1; // "operador" por defecto
		}
		
		private void RegistarLoad(object sender, EventArgs e)
		{
			// Validación de seguridad: solo el rol administrador puede registrar cuentas
			if (SesionActual.Rol != "administrador")
			{
				MessageBox.Show("Acceso denegado. Solo un administrador puede registrar usuarios.",
				                "Permisos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.Close();
			}
		}
		
		private void LimpiarCampos()
		{
			txtPassword.Clear();
			txtUsuario.Clear();
			txtPassword.Clear();
			cmbRol.SelectedIndex = 1;
			txtPassword.Focus();
		}
		
		void BtnSalirClick(object sender, EventArgs e)
		{
			Form MainForm = new MainForm();
			
			DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas Salir?",
			                                         "Confirmación", MessageBoxButtons.YesNo,
			                                         MessageBoxIcon.Question);
			if (respuesta == DialogResult.Yes)
			{
				MessageBox.Show("Sesion Cerrada, ¡Hasta luego!.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
				MainForm.Show();
			}
			else
			{
				// Código que se ejecuta si el usuario hace clic en "No" o cierra la ventana
				MessageBox.Show("¡Operación cancelada!.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
