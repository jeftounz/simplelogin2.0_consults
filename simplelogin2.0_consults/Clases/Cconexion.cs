using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace simplelogin2._0_consults.Clases
{
    class Cconexion
    {
        NpgsqlConnection conex = new NpgsqlConnection();
        static string servidor= "localhost";
        static string bd= "simplelogin";
        static string usuario="postgres";
        static string password="admin";
        static string puerta= "5432";


        string CadenaConexion = "server=" + servidor + ";" + "port=" + puerta + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";


        public  NpgsqlConnection EstablecerConexion() 
        {
            try
            {
                conex.ConnectionString = CadenaConexion;
                conex.Open();
                MessageBox.Show("Conexion exitosa!");
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("No se puede conectar a la base de datos de PostgreSQL, error: "+e.ToString());
            }


            return conex;
        }

        public void VerificarCredenciales(string user, string password)
        {
            string consulta = "SELECT * FROM tbl_login WHERE username = @User AND password = @Password";
            
                using (NpgsqlCommand comando = new NpgsqlCommand(consulta, conex))
                {
                    comando.Parameters.AddWithValue("@User", user);
                    comando.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login exitoso");
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña errados");
                    }
                }
            
        }





    }
}
