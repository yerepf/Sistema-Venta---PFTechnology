namespace Sistema_Venta___PFTechnology.Modulos
{
    partial class GenerarCodigo
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
            this.label1 = new System.Windows.Forms.Label();
            this.tablaControl = new System.Windows.Forms.DataGridView();
            this.codigoBarrasPB = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BuscarComboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.DatoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CantidadBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasPB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Power Smash", 70F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(230, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(945, 95);
            this.label1.TabIndex = 19;
            this.label1.Text = "Generar Codigo Barras";
            // 
            // tablaControl
            // 
            this.tablaControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaControl.BackgroundColor = System.Drawing.Color.White;
            this.tablaControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tablaControl.Location = new System.Drawing.Point(16, 185);
            this.tablaControl.Margin = new System.Windows.Forms.Padding(2);
            this.tablaControl.Name = "tablaControl";
            this.tablaControl.ReadOnly = true;
            this.tablaControl.RowTemplate.Height = 28;
            this.tablaControl.Size = new System.Drawing.Size(824, 478);
            this.tablaControl.TabIndex = 20;
            this.tablaControl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaControl_CellClick);
            // 
            // codigoBarrasPB
            // 
            this.codigoBarrasPB.BackColor = System.Drawing.Color.White;
            this.codigoBarrasPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.codigoBarrasPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoBarrasPB.Location = new System.Drawing.Point(866, 150);
            this.codigoBarrasPB.Name = "codigoBarrasPB";
            this.codigoBarrasPB.Size = new System.Drawing.Size(539, 409);
            this.codigoBarrasPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.codigoBarrasPB.TabIndex = 21;
            this.codigoBarrasPB.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(856, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Codigo De:";
            // 
            // IDBox
            // 
            this.IDBox.Enabled = false;
            this.IDBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDBox.Location = new System.Drawing.Point(951, 105);
            this.IDBox.Multiline = true;
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(183, 39);
            this.IDBox.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.BuscarComboBox);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.DatoBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(16, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(824, 79);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Productos";
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
            "ID Categoria"});
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
            this.button3.Location = new System.Drawing.Point(692, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 39);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscar por:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Cascadia Code", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1066, 617);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(339, 45);
            this.button1.TabIndex = 25;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CantidadBox
            // 
            this.CantidadBox.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantidadBox.Location = new System.Drawing.Point(1285, 582);
            this.CantidadBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CantidadBox.Name = "CantidadBox";
            this.CantidadBox.Size = new System.Drawing.Size(120, 32);
            this.CantidadBox.TabIndex = 32;
            this.CantidadBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1146, 586);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 28);
            this.label5.TabIndex = 33;
            this.label5.Text = "Cantidad:";
            // 
            // NombreBox
            // 
            this.NombreBox.Enabled = false;
            this.NombreBox.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreBox.Location = new System.Drawing.Point(1140, 105);
            this.NombreBox.Multiline = true;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(265, 39);
            this.NombreBox.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Cascadia Code", 20.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(866, 617);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 45);
            this.button2.TabIndex = 35;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GenerarCodigo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1417, 674);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CantidadBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codigoBarrasPB);
            this.Controls.Add(this.tablaControl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerarCodigo";
            this.Text = "GenerarCodigo";
            this.VisibleChanged += new System.EventHandler(this.GenerarCodigo_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tablaControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasPB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox codigoBarrasPB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox BuscarComboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox DatoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown CantidadBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView tablaControl;
    }
}