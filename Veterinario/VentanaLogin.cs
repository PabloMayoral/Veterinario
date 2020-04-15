using System;
using System.Windows.Forms;

namespace Veterinario
{
    public partial class VentanaLogin : Form
    {
       
        Conexion miConexion = new Conexion();
      
       
        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (miConexion.loginVeterinario(user.Text, Contraseña.Text))
            {
                this.Hide();
                VentanaPrincipal v = new VentanaPrincipal();
                v.Show();
            }
            else
            {
                MessageBox.Show("usuario o contraseña incorrectos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro r = new Registro();
            r.Show();
        }
    }
    
}
