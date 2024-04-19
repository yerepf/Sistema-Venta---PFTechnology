using PFTechnology.Backend;
using Sistema_Venta___PFTechnology.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta___PFTechnology
{
    public partial class loginForm : Form
    {
        

        public loginForm()
        {
            InitializeComponent();
            ActiveControl = pictureBox1;
        }

        public static class Login
        {
            public static string user, pass;
        }

        bool passVisible, successlogin;
        BackendLogin backend = new BackendLogin();
        public int idusuario;

        private void button1_Click(object sender, EventArgs e)
        {
            Login.user = usuarioBox.Text;
            Login.pass = contraseñaBox.Text;
            successlogin = backend.IniciarSesion(Login.user, Login.pass);

            if (successlogin)
            {
                idusuario = backend.GetID(Login.user, Login.pass);
                InicioForm forminicio = new InicioForm(idusuario);
                this.Hide();
                forminicio.ShowDialog();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                pictureBox4.Image = Properties.Resources.vista;
                passVisible = true;
                contraseñaBox.PasswordChar = '\0';
            }
            else
            {
                pictureBox4.Image = Properties.Resources.esconder;
                passVisible = false;
                contraseñaBox.PasswordChar = '*';
            }
        }

        private void usuarioBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se procese la tecla "Enter"
                contraseñaBox.Focus();
            }
        }

        private void contraseñaBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se procese la tecla "Enter"
                button1.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
