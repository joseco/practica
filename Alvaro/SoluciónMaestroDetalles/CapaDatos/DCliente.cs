using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;//para se importa esto, para con tipos de datos sqlServer
using System.Data.SqlClient;// para poder enviar comando desde esta app a la base d datos

namespace CapaDatos
{
    public class DCliente
    {
        private int _ClienteId;
        private string _Nombre;
        private string _Nit;
        private string _TextoBuscar;
        private int _TextoBuscarId;

       
        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Nit
        {
            get { return _Nit; }
            set { _Nit = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public int TextoBuscarId
                {
                    get { return _TextoBuscarId; }
                    set { _TextoBuscarId = value; }
                }


        //constructor vacio
        public DCliente() { }

        //constructor con parametros
        public DCliente(int clienteId, string nombre, string nit, string textoBuscar, int textoBuscarId)
        {
            this.ClienteId = clienteId;
            this.Nombre = nombre;
            this.Nit = nit;
            this.TextoBuscar = textoBuscar;
            this.TextoBuscarId = textoBuscarId;
        }
        //metodo insertar
        public string Insertar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {   //codigo
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //establecer el comando
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_InsertarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParClienteId = new SqlParameter();
                ParClienteId.ParameterName = "@intClienteId";
                ParClienteId.SqlDbType = SqlDbType.Int;
                ParClienteId.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParClienteId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@varNombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParNit = new SqlParameter();
                ParNit.ParameterName = "@varNit";
                ParNit.SqlDbType = SqlDbType.VarChar;
                ParNit.Size = 50;
                ParNit.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNit);

                //ejecutamos nuestro comando

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK Cliente Alvarito" : "No se Ingreso el Registro";
            }
            catch (Exception ex)//mostramo el posible error
            {
                rpta = ex.Message;
            }
            finally //limpia toda secuencia en ejecucuion y se cierra la conecion
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }
        //metodo eliminar
        public string Eliminar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {   //codigo
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //establecer el comando
                SqlCommand sqlCmd= new SqlCommand();
                sqlCmd.Connection=sqlCon;
                sqlCmd.CommandText="usp_EliminarCliente";
                sqlCmd.CommandType=CommandType.StoredProcedure;

                SqlParameter ParClienteId= new SqlParameter();
                ParClienteId.ParameterName="@intClienteId";
                ParClienteId.SqlDbType=SqlDbType.Int;
                ParClienteId.Value=Cliente.ClienteId;
                sqlCmd.Parameters.Add(ParClienteId);


                //ejecutamos nuestro comando

                rpta=sqlCmd.ExecuteNonQuery()==1?"OK Cliente Alvarito" : "No se Elimino el Registro";
            }
            catch (Exception ex)//mostramo el posible error
            {
                rpta = ex.Message;
            }
            finally //limpia toda secuencia en ejecucuion y se cierra la conecion
            {
                if(sqlCon.State==ConnectionState.Open)sqlCon.Close();
            }
            return rpta;
        }
        //metodo Actualizar
        public string Actualizar(DCliente Cliente)
        {
             string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {   //codigo
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //establecer el comando
                SqlCommand sqlCmd= new SqlCommand();
                sqlCmd.Connection=sqlCon;
                sqlCmd.CommandText="usp_ActualizarCliente";
                sqlCmd.CommandType=CommandType.StoredProcedure;

                SqlParameter ParClienteId= new SqlParameter();
                ParClienteId.ParameterName="@intClienteId";
                ParClienteId.SqlDbType=SqlDbType.Int;
                ParClienteId.Value=Cliente.ClienteId;
                sqlCmd.Parameters.Add(ParClienteId);

                SqlParameter ParNombre= new SqlParameter();
                ParNombre.ParameterName="@varNombre";
                ParNombre.SqlDbType=SqlDbType.VarChar;
                ParNombre.Size=50;
                ParNombre.Value=Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParNit= new SqlParameter();
                ParNit.ParameterName="@varNit";
                ParNit.SqlDbType=SqlDbType.VarChar;
                ParNit.Size=50;
                ParNit.Value=Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNit);

                //ejecutamos nuestro comando
                rpta=sqlCmd.ExecuteNonQuery()==1?"OK Cliente Alvarito" : "No se Actualizo el Registro";
            }
            catch (Exception ex)//mostramo el posible error
            {
                rpta = ex.Message;
            }
            finally //limpia toda secuencia en ejecucuion y se cierra la conecion
            {
                if(sqlCon.State==ConnectionState.Open)sqlCon.Close();
            }
            return rpta;
        }

        //metodo Mostrar
        public DataTable Mostrar()
        {
            string rpta = "";
            DataTable DtCliente = new DataTable("tbl_Clientes");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_GetCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtCliente);
            }
            catch (Exception ex)//mostramo el posible error
            {
                DtCliente = null;
                rpta = ex.Message;
            }
            return DtCliente;
        }
        //metodo buscar por nit
       
        public DataTable BuscarNit(DCliente Nit)
        {
            string rpta = "";
            DataTable DtCliente = new DataTable("tbl_Clientes");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_BuscarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parNitBuscar = new SqlParameter();
                parNitBuscar.ParameterName = "@varNit";
                parNitBuscar.SqlDbType = SqlDbType.VarChar;
                parNitBuscar.Size = 50;
                parNitBuscar.Value = Nit.TextoBuscar;
                sqlCmd.Parameters.Add(parNitBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtCliente);
            }
            catch (Exception ex)//mostramo el posible error
            {
                DtCliente = null;
                rpta = ex.Message;
            }
            return DtCliente;
        }

        public DataTable BuscarPorID(DCliente GetByID)
        {
            string rpta = "";
            DataTable DtCliente = new DataTable("tbl_Clientes");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_GetClienteById";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parNitBuscar = new SqlParameter();
                parNitBuscar.ParameterName = "@intClienteId";
                parNitBuscar.SqlDbType = SqlDbType.Int;
                parNitBuscar.Value = GetByID.TextoBuscarId;
                sqlCmd.Parameters.Add(parNitBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtCliente);
            }
            catch (Exception ex)//mostramo el posible error
            {
                DtCliente = null;
                rpta = ex.Message;
            }
            return DtCliente;
        }

    }
}