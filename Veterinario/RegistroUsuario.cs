using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinario
{
    public partial class RegistroUsuario : Form
    {
        Conexion conexion = new Conexion();
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String textoPassword = contraseña.Text;
            string myHash = BCrypt.Net.BCrypt.HashPassword(textoPassword, BCrypt.Net.BCrypt.GenerateSalt());

            MessageBox.Show(conexion.insertaUsuario(nombre.Text, apellidos.Text, dni.Text,
                                    gmail.Text, direccion.Text, telefono.Text,
                                    myHash));
            this.Close();
            VentanaLogin v = new VentanaLogin();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaLogin v = new VentanaLogin();
            v.Show();
        }
        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
