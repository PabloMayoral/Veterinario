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
    public partial class VentanaVeterinario : Form
    {
        Conexion conexion = new Conexion();
        public DataTable datosMascotas = new DataTable();
        public VentanaVeterinario()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            id.Text = "";
            nombre.Text = "";
            tipo.Text = "";
            raza.Text = "";
            sexo.Text = "";
            info.Text = "";
            propietario.Text = "";

            try
            {
                datosMascotas = conexion.buscaMascota(buscaId.Text);

                //Seleccionamos los datos y los labels donde aparecerán dentro de nuestra app
                id.Text = (id.Text = datosMascotas.Rows[0]["ID"].ToString());
                nombre.Text = (nombre.Text = datosMascotas.Rows[0]["Nombre"].ToString());
                tipo.Text = (tipo.Text = datosMascotas.Rows[0]["Tipo"].ToString());
                raza.Text = (raza.Text = datosMascotas.Rows[0]["Raza"].ToString());
                info.Text = (info.Text = datosMascotas.Rows[0]["Historial Médico"].ToString());
                sexo.Text = (sexo.Text = datosMascotas.Rows[0]["Sexo"].ToString());
                propietario.Text = (propietario.Text = datosMascotas.Rows[0]["Propietario"].ToString());

                buscaId.Text = "";//Dejamos el buscador de ID vacío
            }
            catch (Exception ex)
            //Si el id no es valido salta un aviso
            {
               // MessageBox.Show("ID no encontrado");
                buscaId.Text = "";
            }
        }
        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }

    }
    }

