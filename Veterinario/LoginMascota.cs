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
    
    public partial class LoginMascota : Form
    {
        Conexion miConexion = new Conexion();
       public DataTable datosMascotas = new DataTable();
        public static int indice = 1;//el animal que estamos viendo
       
        public LoginMascota()
        {
            InitializeComponent();
            //infoAnimales();
        }
        public void infoAnimales()
        {
         //datosMascotas = miConexion.getMascotasPorId(indice);
         //   id.Text = datosMascotas.Rows[0]["ID"].ToString();//Ponemos el nombre
         //   nombre.Text = datosMascotas.Rows[0]["Nombre"].ToString();//Ponemos el nombre
         //   tipo.Text = datosMascotas.Rows[0]["Tipo"].ToString();
         //   raza.Text = datosMascotas.Rows[0]["Raza"].ToString();
         //  // fecha_nac.Text = datosMascotas.Rows[0]["Fecha_Nac"].ToString();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    idActual--;
        //    if (idActual <= 0)
        //    {
        //        idActual = 0;
        //    }
        //    infoAnimales();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    idActual++;
        //    if (idActual >= 1000)
        //    {
        //        idActual = 1000;
        //    }
        //    infoAnimales();
        }
    }

    
}
