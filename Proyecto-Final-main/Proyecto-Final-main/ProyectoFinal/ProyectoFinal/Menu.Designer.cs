/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 18/11/2026
 * Time: 04:30 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProyectoFinal
{
	partial class Menu
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnDisponibilidad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnMatricula;
		private System.Windows.Forms.Button btnPrestamo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnRegistrar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox txtbRLibro;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.btnDisponibilidad = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnMatricula = new System.Windows.Forms.Button();
			this.btnPrestamo = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSalir = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnRegistrar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.txtbRLibro = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(352, 105);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 51);
			this.button2.TabIndex = 40;
			this.toolTip1.SetToolTip(this.button2, "Buscar Libro");
			this.button2.UseVisualStyleBackColor = false;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.textBox1.Location = new System.Drawing.Point(170, 122);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(171, 22);
			this.textBox1.TabIndex = 39;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Window;
			this.label4.Location = new System.Drawing.Point(11, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 23);
			this.label4.TabIndex = 38;
			this.label4.Text = "Codigo de barras:";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(93, 236);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 51);
			this.button3.TabIndex = 37;
			this.toolTip1.SetToolTip(this.button3, "Buscar Libro");
			this.button3.UseVisualStyleBackColor = false;
			// 
			// btnDisponibilidad
			// 
			this.btnDisponibilidad.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnDisponibilidad.Image = ((System.Drawing.Image)(resources.GetObject("btnDisponibilidad.Image")));
			this.btnDisponibilidad.Location = new System.Drawing.Point(12, 356);
			this.btnDisponibilidad.Name = "btnDisponibilidad";
			this.btnDisponibilidad.Size = new System.Drawing.Size(75, 51);
			this.btnDisponibilidad.TabIndex = 36;
			this.toolTip1.SetToolTip(this.btnDisponibilidad, "Disponibilidad");
			this.btnDisponibilidad.UseVisualStyleBackColor = false;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.Window;
			this.label6.Location = new System.Drawing.Point(12, 304);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(354, 49);
			this.label6.TabIndex = 35;
			this.label6.Text = "Administración";
			// 
			// btnMatricula
			// 
			this.btnMatricula.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnMatricula.Image = ((System.Drawing.Image)(resources.GetObject("btnMatricula.Image")));
			this.btnMatricula.Location = new System.Drawing.Point(711, 11);
			this.btnMatricula.Name = "btnMatricula";
			this.btnMatricula.Size = new System.Drawing.Size(75, 51);
			this.btnMatricula.TabIndex = 34;
			this.toolTip1.SetToolTip(this.btnMatricula, "Buscar Matricula");
			this.btnMatricula.UseVisualStyleBackColor = false;
			// 
			// btnPrestamo
			// 
			this.btnPrestamo.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnPrestamo.Image = ((System.Drawing.Image)(resources.GetObject("btnPrestamo.Image")));
			this.btnPrestamo.Location = new System.Drawing.Point(12, 236);
			this.btnPrestamo.Name = "btnPrestamo";
			this.btnPrestamo.Size = new System.Drawing.Size(75, 51);
			this.btnPrestamo.TabIndex = 33;
			this.toolTip1.SetToolTip(this.btnPrestamo, "Tramitar Prestamo");
			this.btnPrestamo.UseVisualStyleBackColor = false;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.Window;
			this.label5.Location = new System.Drawing.Point(12, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(247, 49);
			this.label5.TabIndex = 32;
			this.label5.Text = "Préstamos";
			// 
			// btnSalir
			// 
			this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.Location = new System.Drawing.Point(12, 484);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(75, 51);
			this.btnSalir.TabIndex = 31;
			this.btnSalir.UseVisualStyleBackColor = false;
			this.btnSalir.Click += new System.EventHandler(this.BtnSalirClick);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button1.Location = new System.Drawing.Point(1152, 484);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 51);
			this.button1.TabIndex = 30;
			this.button1.UseVisualStyleBackColor = false;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.textBox2.Location = new System.Drawing.Point(490, 21);
			this.textBox2.MaxLength = 13;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(215, 22);
			this.textBox2.TabIndex = 29;
			// 
			// btnRegistrar
			// 
			this.btnRegistrar.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.Image")));
			this.btnRegistrar.Location = new System.Drawing.Point(352, 48);
			this.btnRegistrar.Name = "btnRegistrar";
			this.btnRegistrar.Size = new System.Drawing.Size(75, 51);
			this.btnRegistrar.TabIndex = 28;
			this.toolTip1.SetToolTip(this.btnRegistrar, "Agregar Libro");
			this.btnRegistrar.UseVisualStyleBackColor = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Window;
			this.label3.Location = new System.Drawing.Point(392, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 23);
			this.label3.TabIndex = 27;
			this.label3.Text = "Matricula:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView1
			// 
			this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(436, 95);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(794, 357);
			this.dataGridView1.TabIndex = 26;
			// 
			// txtbRLibro
			// 
			this.txtbRLibro.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtbRLibro.Location = new System.Drawing.Point(171, 57);
			this.txtbRLibro.Name = "txtbRLibro";
			this.txtbRLibro.Size = new System.Drawing.Size(175, 22);
			this.txtbRLibro.TabIndex = 25;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Window;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 23);
			this.label2.TabIndex = 24;
			this.label2.Text = "Registrar Libro:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
			this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(343, 22);
			this.dateTimePicker1.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(896, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(331, 56);
			this.label1.TabIndex = 22;
			this.label1.Text = "BiblioTecnm";
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(1242, 547);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btnDisponibilidad);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnMatricula);
			this.Controls.Add(this.btnPrestamo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.btnRegistrar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.txtbRLibro);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label1);
			this.Name = "Menu";
			this.Text = "Menu";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
