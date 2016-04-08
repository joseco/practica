using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Tbl_venta
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Tbl_venta oEN_Tbl_venta = new EN_Tbl_venta();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Tbl_venta()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablatbl_venta
		/// </summary>
		public virtual string Insert(EN_Tbl_venta tbl_venta)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@fecha", (tbl_venta.Fecha==String.Empty)?Convert.DBNull:tbl_venta.Fecha),
				new SqlParameter("@cliente_id", (tbl_venta.Cliente_id==0)?Convert.DBNull:tbl_venta.Cliente_id),
				new SqlParameter("@total", (tbl_venta.Total==0)?Convert.DBNull:tbl_venta.Total)
			};

			try
			{
			int CodigoIdentity = -1;
			tbl_venta.Venta_id = (int) SqlHelper.ExecuteScalar(cn, CommandType.StoredProcedure, "sp_tbl_ventaInsert", parameters);
			CodigoIdentity = tbl_venta.Venta_id;
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Actualizar filas en tbl_venta table.
		/// </summary>
		public virtual string Update(EN_Tbl_venta tbl_venta)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", (tbl_venta.Venta_id==0)?Convert.DBNull:tbl_venta.Venta_id),
				new SqlParameter("@fecha", (tbl_venta.Fecha==String.Empty)?Convert.DBNull:tbl_venta.Fecha),
				new SqlParameter("@cliente_id", (tbl_venta.Cliente_id==0)?Convert.DBNull:tbl_venta.Cliente_id),
				new SqlParameter("@total", (tbl_venta.Total==0)?Convert.DBNull:tbl_venta.Total)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_ventaUpdate", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Elimina filas desde tbl_venta table by its primary key.
		/// </summary>
		public virtual string Delete(int venta_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", venta_id)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_ventaDelete", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Deletes a record from the tbl_venta table by a foreign key.
		/// </summary>
		public virtual void DeleteAllByCliente_id(int cliente_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@cliente_id", cliente_id)
			};

			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_ventaDeleteAllByCliente_id", parameters);
		}

		/// <summary>
		/// Seleccionar una fila desde tbl_venta table.
		/// </summary>
		public virtual EN_Tbl_venta Select(int venta_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", venta_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_ventaSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeEN_Tbl_venta(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the tbl_venta table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_tbl_ventaSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the tbl_venta table.
		/// </summary>
		public virtual List<EN_Tbl_venta> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_ventaSelectAll"))
			{
				List<EN_Tbl_venta> tbl_ventaList = new List<EN_Tbl_venta>();
				while (dataReader.Read())
				{
					EN_Tbl_venta tbl_venta = MakeEN_Tbl_venta(dataReader);
					tbl_ventaList.Add(tbl_venta);
				}

				return tbl_ventaList;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_venta table by a foreign key.
		/// </summary>
		public virtual List<EN_Tbl_venta> SelectAllByCliente_id(int cliente_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@cliente_id", cliente_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_ventaSelectAllByCliente_id", parameters))
			{
				List<EN_Tbl_venta> tbl_ventaList = new List<EN_Tbl_venta>();
				while (dataReader.Read())
				{
					EN_Tbl_venta tbl_venta = MakeEN_Tbl_venta(dataReader);
					tbl_ventaList.Add(tbl_venta);
				}

				return tbl_ventaList;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_venta class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Tbl_venta MakeEN_Tbl_venta(SqlDataReader dataReader)
		{
			EN_Tbl_venta oeN_Tbl_venta = new EN_Tbl_venta();
			oeN_Tbl_venta.Venta_id =dataReader.IsDBNull(dataReader.GetOrdinal("venta_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("venta_id"));
			oeN_Tbl_venta.Fecha =dataReader.IsDBNull(dataReader.GetOrdinal("fecha"))? String.Empty : dataReader.GetString(dataReader.GetOrdinal("fecha"));
			oeN_Tbl_venta.Cliente_id =dataReader.IsDBNull(dataReader.GetOrdinal("cliente_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("cliente_id"));
			oeN_Tbl_venta.Total =dataReader.IsDBNull(dataReader.GetOrdinal("total"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("total"));

			return oeN_Tbl_venta;
		}

		#endregion
	}
}
