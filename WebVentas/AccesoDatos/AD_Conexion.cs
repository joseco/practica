using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    public class AD_Conexion
    {
        public string strCadena;
        private SqlConnection con;

        //*Conexion
        public AD_Conexion()
        {
            System.Configuration.AppSettingsReader config = new System.Configuration.AppSettingsReader();
            con = new SqlConnection();
            this.con.ConnectionString = ConfigurationManager.ConnectionStrings["Venta"].ConnectionString;
            //Sin web.config o app.config usar la cadena de conexion así:
			//this.con.ConnectionString ="Server=10.10.10.10; Database=Test_database; User ID=myuser; Password=mypassword;";
			
			//Con web.config o app.config usar la cadena de conexion así:
			//this.con.ConnectionString = ConfigurationManager.ConnectionStrings["theConexionStringName"].ConnectionString;	

            strCadena = this.con.ConnectionString;
        }


        //*Propiedad para obtener la conexion
        public SqlConnection conexion
        {
            get
            {
                return con;
            }
        }


        public string CadenaConexion
        {
            get
            {
                return strCadena;
            }
        }
    }
}
