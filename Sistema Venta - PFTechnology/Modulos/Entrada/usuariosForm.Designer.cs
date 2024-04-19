namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    partial class usuariosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usuariosForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DatoBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.BuscarComboBox = new System.Windows.Forms.ComboBox();
            this.ActivoFiltro = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cedulaFiltroBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AnalistaCBox = new System.Windows.Forms.RadioButton();
            this.SACBox = new System.Windows.Forms.RadioButton();
            this.RHBox = new System.Windows.Forms.RadioButton();
            this.InventarioCBox = new System.Windows.Forms.RadioButton();
            this.VentaCBox = new System.Windows.Forms.RadioButton();
            this.AdministradorCBox = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.ContraseñaBox = new System.Windows.Forms.TextBox();
            this.IDEmpleadoBox = new System.Windows.Forms.TextBox();
            this.EstadocCBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CedulaEmpleadoBox = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tablaControl = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Power Smash", 70F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(541, -8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 95);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar por:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dato:";
            // 
            // DatoBox
            // 
            this.DatoBox.Location = new System.Drawing.Point(414, 36);
            this.DatoBox.Margin = new System.Windows.Forms.Padding(2);
            this.DatoBox.Multiline = true;
            this.DatoBox.Name = "DatoBox";
            this.DatoBox.Size = new System.Drawing.Size(273, 31);
            this.DatoBox.TabIndex = 2;
            this.DatoBox.TextChanged += new System.EventHandler(this.DatoBox_TextChanged);
            this.DatoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.DatoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatoBox_KeyPress);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(714, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 39);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BuscarComboBox
            // 
            this.BuscarComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuscarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuscarComboBox.FormattingEnabled = true;
            this.BuscarComboBox.Items.AddRange(new object[] {
            "ID",
            "Nombre",
            "Contraseña",
            "Estado",
            "ID Rol",
            "ID Empleado",
            "Cedula Empleado",
            "Nombre Rol "});
            this.BuscarComboBox.Location = new System.Drawing.Point(121, 33);
            this.BuscarComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BuscarComboBox.Name = "BuscarComboBox";
            this.BuscarComboBox.Size = new System.Drawing.Size(225, 34);
            this.BuscarComboBox.TabIndex = 8;
            this.BuscarComboBox.SelectedIndexChanged += new System.EventHandler(this.BuscarComboBox_SelectedIndexChanged);
            // 
            // ActivoFiltro
            // 
            this.ActivoFiltro.AutoSize = true;
            this.ActivoFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActivoFiltro.Location = new System.Drawing.Point(414, 35);
            this.ActivoFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.ActivoFiltro.Name = "ActivoFiltro";
            this.ActivoFiltro.Size = new System.Drawing.Size(85, 30);
            this.ActivoFiltro.TabIndex = 9;
            this.ActivoFiltro.Text = "Activo";
            this.ActivoFiltro.UseVisualStyleBackColor = true;
            this.ActivoFiltro.CheckedChanged += new System.EventHandler(this.ActivoFiltro_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cedulaFiltroBox);
            this.groupBox1.Controls.Add(this.ActivoFiltro);
            this.groupBox1.Controls.Add(this.BuscarComboBox);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.DatoBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(930, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Usuarios";
            // 
            // cedulaFiltroBox
            // 
            this.cedulaFiltroBox.Location = new System.Drawing.Point(414, 33);
            this.cedulaFiltroBox.Mask = "000-0000000-0";
            this.cedulaFiltroBox.Name = "cedulaFiltroBox";
            this.cedulaFiltroBox.Size = new System.Drawing.Size(162, 34);
            this.cedulaFiltroBox.TabIndex = 24;
            this.cedulaFiltroBox.Visible = false;
            this.cedulaFiltroBox.TextChanged += new System.EventHandler(this.cedulaFiltroBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AnalistaCBox);
            this.groupBox3.Controls.Add(this.SACBox);
            this.groupBox3.Controls.Add(this.RHBox);
            this.groupBox3.Controls.Add(this.InventarioCBox);
            this.groupBox3.Controls.Add(this.VentaCBox);
            this.groupBox3.Controls.Add(this.AdministradorCBox);
            this.groupBox3.Location = new System.Drawing.Point(24, 303);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(414, 148);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // AnalistaCBox
            // 
            this.AnalistaCBox.AutoSize = true;
            this.AnalistaCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnalistaCBox.ForeColor = System.Drawing.Color.Black;
            this.AnalistaCBox.Location = new System.Drawing.Point(198, 96);
            this.AnalistaCBox.Margin = new System.Windows.Forms.Padding(2);
            this.AnalistaCBox.Name = "AnalistaCBox";
            this.AnalistaCBox.Size = new System.Drawing.Size(99, 30);
            this.AnalistaCBox.TabIndex = 5;
            this.AnalistaCBox.TabStop = true;
            this.AnalistaCBox.Tag = "6";
            this.AnalistaCBox.Text = "Analista";
            this.AnalistaCBox.UseVisualStyleBackColor = true;
            // 
            // SACBox
            // 
            this.SACBox.AutoSize = true;
            this.SACBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SACBox.ForeColor = System.Drawing.Color.Black;
            this.SACBox.Location = new System.Drawing.Point(198, 40);
            this.SACBox.Margin = new System.Windows.Forms.Padding(2);
            this.SACBox.Name = "SACBox";
            this.SACBox.Size = new System.Drawing.Size(184, 30);
            this.SACBox.TabIndex = 4;
            this.SACBox.TabStop = true;
            this.SACBox.Tag = "4";
            this.SACBox.Text = "Servicio al Cliente";
            this.SACBox.UseVisualStyleBackColor = true;
            // 
            // RHBox
            // 
            this.RHBox.AutoSize = true;
            this.RHBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RHBox.ForeColor = System.Drawing.Color.Black;
            this.RHBox.Location = new System.Drawing.Point(198, 68);
            this.RHBox.Margin = new System.Windows.Forms.Padding(2);
            this.RHBox.Name = "RHBox";
            this.RHBox.Size = new System.Drawing.Size(194, 30);
            this.RHBox.TabIndex = 3;
            this.RHBox.TabStop = true;
            this.RHBox.Tag = "3";
            this.RHBox.Text = "Recursos Humanos";
            this.RHBox.UseVisualStyleBackColor = true;
            // 
            // InventarioCBox
            // 
            this.InventarioCBox.AutoSize = true;
            this.InventarioCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InventarioCBox.ForeColor = System.Drawing.Color.Black;
            this.InventarioCBox.Location = new System.Drawing.Point(38, 96);
            this.InventarioCBox.Margin = new System.Windows.Forms.Padding(2);
            this.InventarioCBox.Name = "InventarioCBox";
            this.InventarioCBox.Size = new System.Drawing.Size(120, 30);
            this.InventarioCBox.TabIndex = 2;
            this.InventarioCBox.TabStop = true;
            this.InventarioCBox.Tag = "2";
            this.InventarioCBox.Text = "Inventario";
            this.InventarioCBox.UseVisualStyleBackColor = true;
            // 
            // VentaCBox
            // 
            this.VentaCBox.AutoSize = true;
            this.VentaCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VentaCBox.ForeColor = System.Drawing.Color.Black;
            this.VentaCBox.Location = new System.Drawing.Point(38, 68);
            this.VentaCBox.Margin = new System.Windows.Forms.Padding(2);
            this.VentaCBox.Name = "VentaCBox";
            this.VentaCBox.Size = new System.Drawing.Size(80, 30);
            this.VentaCBox.TabIndex = 1;
            this.VentaCBox.TabStop = true;
            this.VentaCBox.Tag = "1";
            this.VentaCBox.Text = "Venta";
            this.VentaCBox.UseVisualStyleBackColor = true;
            // 
            // AdministradorCBox
            // 
            this.AdministradorCBox.AutoSize = true;
            this.AdministradorCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdministradorCBox.ForeColor = System.Drawing.Color.Black;
            this.AdministradorCBox.Location = new System.Drawing.Point(38, 40);
            this.AdministradorCBox.Margin = new System.Windows.Forms.Padding(2);
            this.AdministradorCBox.Name = "AdministradorCBox";
            this.AdministradorCBox.Size = new System.Drawing.Size(153, 30);
            this.AdministradorCBox.TabIndex = 0;
            this.AdministradorCBox.TabStop = true;
            this.AdministradorCBox.Tag = "5";
            this.AdministradorCBox.Text = "Administrador";
            this.AdministradorCBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(246, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 63);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(34, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 63);
            this.button2.TabIndex = 11;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(57, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID Usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(57, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(57, 209);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "ID Empleado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(57, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(57, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "Nombre";
            // 
            // IDBox
            // 
            this.IDBox.Enabled = false;
            this.IDBox.Location = new System.Drawing.Point(222, 62);
            this.IDBox.Margin = new System.Windows.Forms.Padding(2);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(203, 34);
            this.IDBox.TabIndex = 17;
            this.IDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.IDBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // NombreBox
            // 
            this.NombreBox.Location = new System.Drawing.Point(222, 109);
            this.NombreBox.Margin = new System.Windows.Forms.Padding(2);
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(203, 34);
            this.NombreBox.TabIndex = 18;
            this.NombreBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // ContraseñaBox
            // 
            this.ContraseñaBox.Location = new System.Drawing.Point(222, 157);
            this.ContraseñaBox.Margin = new System.Windows.Forms.Padding(2);
            this.ContraseñaBox.Name = "ContraseñaBox";
            this.ContraseñaBox.Size = new System.Drawing.Size(203, 34);
            this.ContraseñaBox.TabIndex = 19;
            this.ContraseñaBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // IDEmpleadoBox
            // 
            this.IDEmpleadoBox.Location = new System.Drawing.Point(222, 206);
            this.IDEmpleadoBox.Margin = new System.Windows.Forms.Padding(2);
            this.IDEmpleadoBox.Name = "IDEmpleadoBox";
            this.IDEmpleadoBox.Size = new System.Drawing.Size(174, 34);
            this.IDEmpleadoBox.TabIndex = 20;
            this.IDEmpleadoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.IDEmpleadoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // EstadocCBox
            // 
            this.EstadocCBox.AutoSize = true;
            this.EstadocCBox.Checked = true;
            this.EstadocCBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EstadocCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EstadocCBox.ForeColor = System.Drawing.Color.Black;
            this.EstadocCBox.Location = new System.Drawing.Point(222, 255);
            this.EstadocCBox.Margin = new System.Windows.Forms.Padding(2);
            this.EstadocCBox.Name = "EstadocCBox";
            this.EstadocCBox.Size = new System.Drawing.Size(85, 30);
            this.EstadocCBox.TabIndex = 21;
            this.EstadocCBox.Text = "Activo";
            this.EstadocCBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.CedulaEmpleadoBox);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.EstadocCBox);
            this.groupBox2.Controls.Add(this.IDEmpleadoBox);
            this.groupBox2.Controls.Add(this.ContraseñaBox);
            this.groupBox2.Controls.Add(this.NombreBox);
            this.groupBox2.Controls.Add(this.IDBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.groupBox2.Location = new System.Drawing.Point(948, 89);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(466, 569);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesar Usuarios";
            // 
            // CedulaEmpleadoBox
            // 
            this.CedulaEmpleadoBox.Location = new System.Drawing.Point(222, 206);
            this.CedulaEmpleadoBox.Mask = "000-0000000-0";
            this.CedulaEmpleadoBox.Name = "CedulaEmpleadoBox";
            this.CedulaEmpleadoBox.Size = new System.Drawing.Size(174, 34);
            this.CedulaEmpleadoBox.TabIndex = 23;
            this.CedulaEmpleadoBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Sistema_Venta___PFTechnology.Properties.Resources.intercambio;
            this.pictureBox1.Location = new System.Drawing.Point(398, 211);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sistema_Venta___PFTechnology.Properties.Resources.Logotipo_de_servicio_técnico_espacial_azul;
            this.pictureBox2.Location = new System.Drawing.Point(2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // tablaControl
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.tablaControl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaControl.BackgroundColor = System.Drawing.Color.White;
            this.tablaControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaControl.Location = new System.Drawing.Point(14, 173);
            this.tablaControl.Name = "tablaControl";
            this.tablaControl.Size = new System.Drawing.Size(929, 484);
            this.tablaControl.TabIndex = 5;
            this.tablaControl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaControl_CellClick);
            // 
            // usuariosForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1425, 669);
            this.Controls.Add(this.tablaControl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "usuariosForm";
            this.Text = "usuariosForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DatoBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox BuscarComboBox;
        private System.Windows.Forms.CheckBox ActivoFiltro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton AnalistaCBox;
        private System.Windows.Forms.RadioButton SACBox;
        private System.Windows.Forms.RadioButton RHBox;
        private System.Windows.Forms.RadioButton InventarioCBox;
        private System.Windows.Forms.RadioButton VentaCBox;
        private System.Windows.Forms.RadioButton AdministradorCBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.TextBox ContraseñaBox;
        private System.Windows.Forms.TextBox IDEmpleadoBox;
        private System.Windows.Forms.CheckBox EstadocCBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MaskedTextBox CedulaEmpleadoBox;
        private System.Windows.Forms.MaskedTextBox cedulaFiltroBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView tablaControl;
    }
}