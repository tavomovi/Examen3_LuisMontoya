using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen3_LuisMontoya.Clases
{
    public class Encuesta
    {
        public static int EncuestaID { get; set; }
        public static string Nombre { get; set; }
        public static int Edad { get; set; }
        public static string CorreoElectronico { get; set; }
        public static int PartidoID { get; set; }



        public Encuesta(int encuestaID, string nombre, int edad, string correoElectronico, int partidoID)
        {
            EncuestaID = encuestaID;
            Nombre = nombre;
            Edad = edad;
            CorreoElectronico = correoElectronico;
            PartidoID = partidoID;
        }

       /* public Encuesta(string tipo, string modelo, int usuarioID)
        {
            TipoEquipo = tipo;
            Modelo = modelo;
            UsuarioID = usuarioID;
        }

        public Encuesta() { }*/

        public static int AgregarE(string nombre, int edad, string correoElectronico, int partidoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEncuesta", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Edad", edad));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@PartidoID", partidoID));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
/*
        public static int BorrarE(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", id));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;


        }

        public void consultar()
        {

        }

        public static int ModificarE(int Id, string tipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", Id));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo varchar", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static List<Encuesta> consultaFiltroE(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Encuesta> Equipos = new List<Encuesta>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipoFiltro", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Encuesta Equipo1 = new Encuesta(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));  // instancia
                            Equipos.Add(Equipo1);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Equipos;
        }





        public static List<Encuesta> ObtenerUsuario()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Encuesta> Equipos = new List<Encuesta>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Encuesta Equipo1 = new Encuesta(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));  // instancia
                            Equipos.Add(Equipo1);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Equipos;
       }*/ 
    }
}
