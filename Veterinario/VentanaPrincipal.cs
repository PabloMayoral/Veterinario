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
    public partial class VentanaPrincipal : Form
    {
        Conexion conexion = new Conexion();
       
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(conexion.insertaUsuario(dni.Text, nombre.Text, pass.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        { 
          MessageBox.Show(conexion.insertaMascota(id.Text, nombre.Text, tipo.Text,raza.Text, sexo.Text,historial.Text,propietario.Text,veterinario.Text));
            this.Close();
            LoginMascota l = new LoginMascota();
            l.Show();

        }
        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }

    }
}
