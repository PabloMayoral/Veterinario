using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinario
{
    class Conexion
    {
        public MySqlConnection conexion;
        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = test; Uid = root; Pwd=;Port = 3306");
        }
        public Boolean loginVeterinario(string Usuario, string Contraseña)
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
                    string contraseña = resultado.GetString("Contraseña");
                    if (BCrypt.Net.BCrypt.Verify(Contraseña, contraseña))
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
                                       String Usuario, String Contraseña)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO clientes " +
                                     "(Nombre, Apellidos, DNI, Correo, " +
                                     "Dirección, Teléfono, Usuario, Contraseña) " +
                                     "VALUES (@Nombre, @Apellidos, @DNI, @Correo," +
                                     "@Dirección, @Teléfono, @Usuario, @Contraseña)", conexion);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Apellidos", Apellidos);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Correo", Correo);
                consulta.Parameters.AddWithValue("@Dirección", Dirección);
                consulta.Parameters.AddWithValue("@Teléfono", Teléfono);
                consulta.Parameters.AddWithValue("@Usuario", Usuario);
                consulta.Parameters.AddWithValue("@Contraseña", Contraseña);

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
