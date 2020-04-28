using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Veterinario
{
    class Conexion
    {
        public MySqlConnection conexion;
        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = test; Uid = root; Pwd=;Port = 3306");
        }
        public String getMascotaPorNombre(String nombre)
        {

            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT ID FROM animal WHERE LOWER(Nombre) ='" + nombre + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable animal = new DataTable();
                animal.Load(resultado);
                conexion.Close();
                return animal.Rows[0]["ID"].ToString();

            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public DataTable getAnimalPorId(int id)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM animal where ID ='" + id + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable tabla = new DataTable();
                tabla.Load(resultado);
                conexion.Close();
                return tabla;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public Boolean loginVeterinario(string Usuario, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM veterinarios " +
                                     "where Usuario = @Usuario",
                                     conexion);
                consulta.Parameters.AddWithValue("@Usuario", Usuario);
             
                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string contraseña = resultado.GetString("pass");
                    if (BCrypt.Net.BCrypt.Verify(pass, contraseña))
                    {
                        return true;
                    }
                    return false;
                }
                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }
        public Boolean loginUsuario(string Usuario, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM clientes " +
                                     "where Usuario = @Usuario",
                                     conexion);
                consulta.Parameters.AddWithValue("@Usuario", Usuario);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string contraseña = resultado.GetString("pass");
                    if (BCrypt.Net.BCrypt.Verify(pass, contraseña))
                    {
                        return true;
                    }
                    return false;
                }
                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }
        public String insertaUsuario(String Nombre, String Apellidos,
                                       String DNI, String Correo,
                                       String Dirección, String Teléfono,
                                       String Usuario, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO clientes " +
                                     "VALUES (@Nombre, @Apellidos, @DNI, @Correo," +
                                     "@Dirección, @Teléfono, @Usuario, @pass)", conexion);

                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Apellidos", Apellidos);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Correo", Correo);
                consulta.Parameters.AddWithValue("@Dirección", Dirección);
                consulta.Parameters.AddWithValue("@Teléfono", Teléfono);
                consulta.Parameters.AddWithValue("@Usuario", Usuario);
                consulta.Parameters.AddWithValue("@pass", pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Registro realizado con éxito";
            }
            catch (MySqlException e)
            {
                return "No se ha podido realizar el registro";
            }

        }
        public String insertaVeterinario(String Nombre, String Apellidos,
                                     String DNI, String Correo,
                                     String Dirección, String Teléfono,
                                     String Usuario, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO veterinarios " +                              
                                     "VALUES (@Nombre, @Apellidos, @DNI, @Correo," +
                                     "@Dirección, @Teléfono, @Usuario, @pass)", conexion);

                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Apellidos", Apellidos);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Correo", Correo);
                consulta.Parameters.AddWithValue("@Dirección", Dirección);
                consulta.Parameters.AddWithValue("@Teléfono", Teléfono);
                consulta.Parameters.AddWithValue("@Usuario", Usuario);
                consulta.Parameters.AddWithValue("@pass", pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Registro realizado con éxito";
            }
            catch (MySqlException e)
            {
                return "No se ha podido realizar el registro";
            }

        }
        public String insertaMascota(String ID, String Nombre,String Tipo, String Raza,String Fecha_Nac)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO animal " +
                                     "VALUES (@ID, @Nombre, @Tipo, @Raza,@Fecha_nac)", conexion);

                consulta.Parameters.AddWithValue("@ID", ID);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Tipo", Tipo);
                consulta.Parameters.AddWithValue("@Raza", Raza);
                consulta.Parameters.AddWithValue("@Fecha_Nac", Fecha_Nac);
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Registro realizado con éxito";
            }
            catch (MySqlException e)
            {
                return "No se ha podido realizar el registro";
            }

        }
    }
}
