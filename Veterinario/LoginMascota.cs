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
        DataTable misAnimales = new DataTable();
        public int idActual = 1;//el animal que estamos viendo
        public LoginMascota()
        {
            InitializeComponent();
        }
        public void infoPokemons()
        {
            misAnimales = miConexion.getAnimalPorId(idActual);
            nombre.Text = misAnimales.Rows[0]["Nombre"].ToString();//Ponemos el nombre
            //Ponemos el ID
            if (idActual < 10)
            {
                id.Text = "Nº: 00" + idActual;

            }
            else if (idActual < 100)
            {
                id.Text = "Nº: 0" + idActual;
            }
            else
            {
                id.Text = "Nº: " + idActual;
            }

            tipo.Text = misAnimales.Rows[0]["Tipo"].ToString();
            raza.Text = misAnimales.Rows[0]["Raza"].ToString();
            fecha_nac.Text = misAnimales.Rows[0]["Fecha_Nac"].ToString();
         
        }

    }

    
}
