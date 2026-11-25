/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 18/11/2026
 * Time: 04:29 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProyectoFinal.Data;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			cmbRol.Items.AddRange(new object[] { "administrador", "operador", "consulta" });
			cmbRol.SelectedIndex = 1;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnSalirClick(object sender, EventArgs e)
		{
			DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas Salir?",
			                                         "Confirmación", MessageBoxButtons.YesNo,
			                                         MessageBoxIcon.Question);
			if (respuesta == DialogResult.Yes)
			{
				MessageBox.Show("Sesion Cerrada, ¡Hasta luego!.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Application.Exit();
			}
			else
			{
				// Código que se ejecuta si el usuario hace clic en "No" o cierra la ventana
				MessageBox.Show("¡Operación cancelada!.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		void BtnVerificarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				MessageBox.Show("Ingresa usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string error;
			string rolElegido = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : string.Empty;

			if (_usuarioDao.IniciarSesion(txtUsuario.Text, txtPassword.Text, rolElegido, out error))
			{
				Menu ventanaMenu = new Menu();
				ventanaMenu.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show(error, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void BtnRegistrarClick(object sender, EventArgs e)
		{
			Form Registar = new Registar();
			Registar.Show();
			this.Hide();
		}
	}
}
