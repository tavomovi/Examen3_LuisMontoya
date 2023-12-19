using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_LuisMontoya
{
    public partial class encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarPartidos();
                //LlenarGrid();
                //LlenarUsuarios();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        /* protected void LlenarGrid()
         {
             string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
             using (SqlConnection con = new SqlConnection(constr))
             {
                 using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Encuesta"))
                 {
                     using (SqlDataAdapter sda = new SqlDataAdapter())
                     {
                         cmd.Connection = con;
                         sda.SelectCommand = cmd;
                         using (DataTable dt = new DataTable())
                         {
                             sda.Fill(dt);
                             datagrid.DataSource = dt;
                             datagrid.DataBind();  // actualizar el grid view
                         }
                     }
                 }
             }
         }

         protected void LlenarUsuarios()
         {
             string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
             using (SqlConnection con = new SqlConnection(constr))
             {
                 using (SqlCommand cmd = new SqlCommand("select Nombre, UsuarioID  from Usuarios"))
                 {
                     using (SqlDataAdapter sda = new SqlDataAdapter())
                     {
                         cmd.Connection = con;
                         sda.SelectCommand = cmd;
                         using (DataTable dt = new DataTable())
                         {
                             sda.Fill(dt);
                             DropDownList1.DataSource = dt;

                             DropDownList1.DataTextField = dt.Columns["Nombre"].ToString();
                             DropDownList1.DataValueField = dt.Columns["UsuarioID"].ToString();
                             DropDownList1.DataBind();
                         }
                     }
                 }
             }
         }*/

        protected void LlenarPartidos()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT PartidoID, Nombre  FROM PPoliticos", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Crear un nuevo DataTable para agregar el elemento "Clic" al inicio
                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("PartidoID");
                            dtModified.Columns.Add("Nombre");

                            // Agregar el elemento "Clic" manualmente al inicio del nuevo DataTable
                            dtModified.Rows.Add("", "Clic ");

                            // Copiar los datos de la consulta SQL al nuevo DataTable
                            foreach (DataRow row in dt.Rows)
                            {
                                dtModified.ImportRow(row);
                            }

                            // Enlazar el DropDownList con el nuevo DataTable modificado
                            DropDownList1.DataSource = dtModified;
                            DropDownList1.DataTextField = "Nombre";
                            DropDownList1.DataValueField = "PartidoID";
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones si ocurre algún error al poblar el DropDownList
            }
        }
        protected void ButtonAgregarE_Click(object sender, EventArgs e)
        {


            int resultado = Clases.Encuesta.AgregarE(tnombre.Text, int.Parse(tedad.Text), tcorreo.Text, int.Parse(DropDownList1.SelectedValue));

            if (resultado > 0)
            {
                alertas("Equipo ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                tedad.Text = string.Empty;
                tcorreo.Text = string.Empty;
                DropDownList1.Text = string.Empty;
                //LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar equipo");

            }
        }

      

        

       
       
    }
}