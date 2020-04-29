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
        public DataTable buscaMascota(String ID)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM animales " +
                                                         "WHERE ID ='" + ID + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable mascota = new DataTable();
                mascota.Load(resultado);
                conexion.Close();
                return mascota;

            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public Boolean loginMascota(string ID)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM animales     " +
                                     "where ID = @ID",
                                     conexion);
                consulta.Parameters.AddWithValue("@ID", ID);

                MySqlDataReader resultado = consulta.ExecuteReader();

                //if (resultado.Read())
                //{
                //    string contraseña = resultado.GetString("pass");
                //    if (BCrypt.Net.BCrypt.Verify(pass, contraseña))
                //    {
                //        return true;
                //    }
                //    return false;
                //}
                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }
        public Boolean loginVeterinario(string DNI, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM veterinarios " +
                                     "where DNI = @DNI",
                                     conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
             
                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string contraseña = resultado.GetString("Pass");
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
        public Boolean loginUsuario(string DNI, string pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM clientes " +
                                     "where DNI = @DNI",
                                     conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string contraseña = resultado.GetString("Pass");
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
                                        String Pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO clientes " +
                                     "VALUES (@Nombre, @Apellidos, @DNI, @Correo," +
                                     "@Dirección, @Teléfono, @Pass)", conexion);

                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Apellidos", Apellidos);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Correo", Correo);
                consulta.Parameters.AddWithValue("@Dirección", Dirección);
                consulta.Parameters.AddWithValue("@Teléfono", Teléfono);
                consulta.Parameters.AddWithValue("@Pass", Pass);

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
                                      String Pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO veterinarios " +                              
                                     "VALUES (@Nombre, @Apellidos, @DNI, @Correo," +
                                     "@Dirección, @Teléfono, @Pass)", conexion);

                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Apellidos", Apellidos);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Correo", Correo);
                consulta.Parameters.AddWithValue("@Dirección", Dirección);
                consulta.Parameters.AddWithValue("@Teléfono", Teléfono);
                consulta.Parameters.AddWithValue("@pass", Pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "Registro realizado con éxito";
            }
            catch (MySqlException e)
            {
                return "No se ha podido realizar el registro";
            }

        }
        public String insertaMascota(String ID, String Nombre, String Tipo, String Raza,String Sexo,String Historial_Medico,String Propietario,String Veterinario)
        {
            String resultado = "";
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO animales"+
                    "(ID, Nombre, Tipo, Raza, Sexo, Historial_Medico, Propietario, Veterinario) " +
                                     "VALUES (@ID, @Nombre, @Tipo, @Raza, @Sexo, @Historial_Medico, @Propietario, @Veterinario)", conexion);

                consulta.Parameters.AddWithValue("@ID", ID);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Tipo", Tipo);
                consulta.Parameters.AddWithValue("@Raza", Raza);
                consulta.Parameters.AddWithValue("@Sexo", Sexo);
                consulta.Parameters.AddWithValue("@Historial_Medico", Historial_Medico);
                consulta.Parameters.AddWithValue("@Propietario", Propietario);
                consulta.Parameters.AddWithValue("@Veterinario", Veterinario);

                consulta.ExecuteNonQuery();

                conexion.Close();
                resultado = "Registro realizado con éxito";
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                resultado = "No se ha podido realizar el registro";
            }
            return resultado;
        }
    }
    }

