using System;
using System.Windows.Forms;


namespace Veterinario
{
    public partial class Registro : Form
    {
       
        public Registro()
        {
            InitializeComponent();
        }
        Conexion conexion = new Conexion();

        private void button1_Click(object sender, EventArgs e)
        {
                String textoPassword = contraseña.Text;
                string myHash = BCrypt.Net.BCrypt.HashPassword(textoPassword, BCrypt.Net.BCrypt.GenerateSalt());

                MessageBox.Show(conexion.insertaVeterinario(nombre.Text, apellidos.Text, dni.Text,
                                        gmail.Text, direccion.Text, telefono.Text,
                                        nombre_usuario.Text, myHash));
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

    }
}
