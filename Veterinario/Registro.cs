using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace Veterinario
{
    public partial class Registro : Form
    {
       
        public Registro()
        {
            InitializeComponent();
        }
        Conexion conexion = new Conexion();
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaLogin v = new VentanaLogin();
            v.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            String textoPassword = contraseña.Text;
            string myHash = BCrypt.Net.BCrypt.HashPassword(textoPassword, BCrypt.Net.BCrypt.GenerateSalt());

            MessageBox.Show(conexion.insertaUsuario(nombre.Text, apellidos.Text, dni.Text,
                                    gmail.Text, direccion.Text, telefono.Text,
                                    nombre_usuario.Text,myHash));
            //VentanaLogin login = new VentanaLogin();
            this.Close();
            //MessageBox.Show("Ha sigo registrado correctamente");
            //login.Show();
        }
    }
}
