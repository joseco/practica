using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Tbl_cliente
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Tbl_cliente oEN_Tbl_cliente = new EN_Tbl_cliente();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Tbl_cliente()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablatbl_cliente
		/// </summary>
		public virtual string Insert(EN_Tbl_cliente tbl_cliente)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@nombre", (tbl_cliente.Nombre==String.Empty)?Convert.DBNull:tbl_cliente.Nombre),
				new SqlParameter("@nit", (tbl_cliente.Nit==String.Empty)?Convert.DBNull:tbl_cliente.Nit)
			};

			try
			{
			int CodigoIdentity = -1;
			tbl_cliente.Cliente_id = (int) SqlHelper.ExecuteScalar(cn, CommandType.StoredProcedure, "sp_tbl_clienteInsert", parameters);
			CodigoIdentity = tbl_cliente.Cliente_id;
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Actualizar filas en tbl_cliente table.
		/// </summary>
		public virtual string Update(EN_Tbl_cliente tbl_cliente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@cliente_id", (tbl_cliente.Cliente_id==0)?Convert.DBNull:tbl_cliente.Cliente_id),
				new SqlParameter("@nombre", (tbl_cliente.Nombre==String.Empty)?Convert.DBNull:tbl_cliente.Nombre),
				new SqlParameter("@nit", (tbl_cliente.Nit==String.Empty)?Convert.DBNull:tbl_cliente.Nit)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_clienteUpdate", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Elimina filas desde tbl_cliente table by its primary key.
		/// </summary>
		public virtual string Delete(int cliente_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@cliente_id", cliente_id)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_clienteDelete", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Seleccionar una fila desde tbl_cliente table.
		/// </summary>
		public virtual EN_Tbl_cliente Select(int cliente_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@cliente_id", cliente_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_clienteSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeEN_Tbl_cliente(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the tbl_cliente table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_tbl_clienteSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the tbl_cliente table.
		/// </summary>
		public virtual List<EN_Tbl_cliente> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_clienteSelectAll"))
			{
				List<EN_Tbl_cliente> tbl_clienteList = new List<EN_Tbl_cliente>();
				while (dataReader.Read())
				{
					EN_Tbl_cliente tbl_cliente = MakeEN_Tbl_cliente(dataReader);
					tbl_clienteList.Add(tbl_cliente);
				}

				return tbl_clienteList;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_cliente class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Tbl_cliente MakeEN_Tbl_cliente(SqlDataReader dataReader)
		{
			EN_Tbl_cliente oeN_Tbl_cliente = new EN_Tbl_cliente();
			oeN_Tbl_cliente.Cliente_id =dataReader.IsDBNull(dataReader.GetOrdinal("cliente_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("cliente_id"));
			oeN_Tbl_cliente.Nombre =dataReader.IsDBNull(dataReader.GetOrdinal("nombre"))? String.Empty : dataReader.GetString(dataReader.GetOrdinal("nombre"));
			oeN_Tbl_cliente.Nit =dataReader.IsDBNull(dataReader.GetOrdinal("nit"))? String.Empty : dataReader.GetString(dataReader.GetOrdinal("nit"));

			return oeN_Tbl_cliente;
		}

		#endregion
	}
}
