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
    }
}
