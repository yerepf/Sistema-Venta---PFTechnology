namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    partial class productosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(productosForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StockMinBox = new System.Windows.Forms.NumericUpDown();
            this.StockBox = new System.Windows.Forms.NumericUpDown();
            this.PrecioBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.categoriaCBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EstadocCBox = new System.Windows.Forms.CheckBox();
            this.DescripcionBox = new System.Windows.Forms.TextBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActivoFiltro = new System.Windows.Forms.CheckBox();
            this.BuscarComboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.DatoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaControl = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockMinBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.StockMinBox);
            this.groupBox2.Controls.Add(this.StockBox);
            this.groupBox2.Controls.Add(this.PrecioBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.categoriaCBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EstadocCBox);
            this.groupBox2.Controls.Add(this.DescripcionBox);
            this.groupBox2.Controls.Add(this.IDBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(947, 95);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(456, 568);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesar Productos";
            // 
            // StockMinBox
            // 
            this.StockMinBox.Location = new System.Drawing.Point(218, 278);
            this.StockMinBox.Name = "StockMinBox";
            this.StockMinBox.Size = new System.Drawing.Size(120, 34);
            this.StockMinBox.TabIndex = 32;
            // 
            // StockBox
            // 
            this.StockBox.Location = new System.Drawing.Point(218, 231);
            this.StockBox.Name = "StockBox";
            this.StockBox.Size = new System.Drawing.Size(120, 34);
            this.StockBox.TabIndex = 31;
            this.StockBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PrecioBox
            // 
            this.PrecioBox.Location = new System.Drawing.Point(218, 186);
            this.PrecioBox.Margin = new System.Windows.Forms.Padding(2);
            this.PrecioBox.Name = "PrecioBox";
            this.PrecioBox.Size = new System.Drawing.Size(203, 34);
            this.PrecioBox.TabIndex = 30;
            this.PrecioBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatoBox_KeyDown);
            this.PrecioBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrecioBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 332);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 26);
            this.label10.TabIndex = 29;
            this.label10.Text = "Categoría";
            // 
            // categoriaCBox
            // 
            this.categoriaCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categoriaCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriaCBox.ForeColor = System.Drawing.Color.Black;
            this.categoriaCBox.FormattingEnabled = true;
            this.categoriaCBox.Location = new System.Drawing.Point(218, 329);
            this.categoriaCBox.MaxDropDownItems = 100;
            this.categoriaCBox.Name = "categoriaCBox";
            this.categoriaCBox.Size = new System.Drawing.Size(204, 34);
            this.categoriaCBox.TabIndex = 28;
            this.categoriaCBox.Enter += new System.EventHandler(this.categoriaCBox_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 280);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 26);
            this.label9.TabIndex = 26;
            this.label9.Text = "Stock Minimo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 233);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 26);
            this.label7.TabIndex = 24;
            this.label7.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 26);
            this.label6.TabIndex = 22;
            this.label6.Text = "Precio";
            // 
            // EstadocCBox
            // 
            this.EstadocCBox.AutoSize = true;
            this.EstadocCBox.Checked = true;
            this.EstadocCBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EstadocCBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EstadocCBox.Location = new System.Drawing.Point(221, 379);
            this.EstadocCBox.Margin = new System.Windows.Forms.Padding(2);
            this.EstadocCBox.Name = "EstadocCBox";
            this.EstadocCBox.Size = new System.Drawing.Size(85, 30);
            this.EstadocCBox.TabIndex = 21;
            this.EstadocCBox.Text = "Activo";
            this.EstadocCBox.UseVisualStyleBackColor = true;
            // 
            // DescripcionBox
            // 
            this.DescripcionBox.Location = new System.Drawing.Point(218, 137);
            this.DescripcionBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescripcionBox.Name = "DescripcionBox";
            this.DescripcionBox.Size = new System.Drawing.Size(203, 34);
            this.DescripcionBox.TabIndex = 18;
            this.DescripcionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatoBox_KeyDown);
            // 
            // IDBox
            // 
            this.IDBox.Enabled = false;
            this.IDBox.Location = new System.Drawing.Point(218, 89);
            this.IDBox.Margin = new System.Windows.Forms.Padding(2);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(203, 34);
            this.IDBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 139);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 379);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID Producto";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(51, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 63);
            this.button2.TabIndex = 11;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(245, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 63);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sistema_Venta___PFTechnology.Properties.Resources.Logotipo_de_servicio_técnico_espacial_azul;
            this.pictureBox2.Location = new System.Drawing.Point(1, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ActivoFiltro);
            this.groupBox1.Controls.Add(this.BuscarComboBox);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.DatoBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(930, 79);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Productos";
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
            this.ActivoFiltro.Visible = false;
            this.ActivoFiltro.CheckedChanged += new System.EventHandler(this.ActivoFiltro_CheckedChanged);
            // 
            // BuscarComboBox
            // 
            this.BuscarComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuscarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuscarComboBox.FormattingEnabled = true;
            this.BuscarComboBox.Items.AddRange(new object[] {
            "ID Producto",
            "Descripción",
            "Precio",
            "Stock",
            "Stock Minimo",
            "ID Categoria",
            "Estado "});
            this.BuscarComboBox.Location = new System.Drawing.Point(121, 33);
            this.BuscarComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BuscarComboBox.Name = "BuscarComboBox";
            this.BuscarComboBox.Size = new System.Drawing.Size(225, 34);
            this.BuscarComboBox.TabIndex = 8;
            this.BuscarComboBox.SelectedIndexChanged += new System.EventHandler(this.BuscarComboBox_SelectedIndexChanged);
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
            // DatoBox
            // 
            this.DatoBox.Location = new System.Drawing.Point(414, 36);
            this.DatoBox.Margin = new System.Windows.Forms.Padding(2);
            this.DatoBox.Multiline = true;
            this.DatoBox.Name = "DatoBox";
            this.DatoBox.Size = new System.Drawing.Size(273, 31);
            this.DatoBox.TabIndex = 2;
            this.DatoBox.TextChanged += new System.EventHandler(this.DatoBox_TextChanged);
            this.DatoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatoBox_KeyDown);
            this.DatoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatoBox_KeyPress);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Power Smash", 70F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(455, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 95);
            this.label1.TabIndex = 13;
            this.label1.Text = "Productos";
            // 
            // tablaControl
            // 
            this.tablaControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaControl.BackgroundColor = System.Drawing.Color.White;
            this.tablaControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tablaControl.Location = new System.Drawing.Point(13, 178);
            this.tablaControl.Margin = new System.Windows.Forms.Padding(2);
            this.tablaControl.Name = "tablaControl";
            this.tablaControl.ReadOnly = true;
            this.tablaControl.RowTemplate.Height = 28;
            this.tablaControl.Size = new System.Drawing.Size(930, 485);
            this.tablaControl.TabIndex = 15;
            this.tablaControl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaControl_CellClick);
            // 
            // productosForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1411, 670);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tablaControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "productosForm";
            this.Text = "productosForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Enter += new System.EventHandler(this.productosForm_Enter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockMinBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox EstadocCBox;
        private System.Windows.Forms.TextBox DescripcionBox;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ActivoFiltro;
        private System.Windows.Forms.ComboBox BuscarComboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox DatoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoriaCBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PrecioBox;
        private System.Windows.Forms.NumericUpDown StockMinBox;
        private System.Windows.Forms.NumericUpDown StockBox;
        private System.Windows.Forms.DataGridView tablaControl;
    }
}