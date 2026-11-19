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
			if(txtBUsuario.Text=="admin" && txtContraseña.Text=="123")
			{

				//MessageBox.Show("entra el formulario");
				//llamar al formulario
				Form MainForm = new Menu();
				MainForm.Show();
				//Oculta el formulario login
				this.Hide();

			}
			else if(txtBUsuario.Text=="user" && txtContraseña.Text =="123")
			{
				//MessageBox.Show("entra el formulario");
				//llamar al formulario
				Form MainForm = new Menu();
				MainForm.Show();
				//Oculta el formulario login
				this.Hide();
			}
			else
			{

				if(MessageBox.Show("Usuario o contraseña incorrectos, ¿Desea volver a intentar?","Datos Incorrectos",
				                   MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
				{
					//Liapiar las cajas
					txtBUsuario.Clear();
					txtContraseña.Clear();

				}

				else
				{
					//Cerrar el formulario
					this.Close();
				}
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
