using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Tbl_detalleVenta
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Tbl_detalleVenta oEN_Tbl_detalleVenta = new EN_Tbl_detalleVenta();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Tbl_detalleVenta()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablatbl_detalleVenta
		/// </summary>
		public virtual string Insert(EN_Tbl_detalleVenta tbl_detalleVenta)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", (tbl_detalleVenta.Venta_id==0)?Convert.DBNull:tbl_detalleVenta.Venta_id),
				new SqlParameter("@producto_id", (tbl_detalleVenta.Producto_id==0)?Convert.DBNull:tbl_detalleVenta.Producto_id),
				new SqlParameter("@precio", (tbl_detalleVenta.Precio==0)?Convert.DBNull:tbl_detalleVenta.Precio),
				new SqlParameter("@cantidad", (tbl_detalleVenta.Cantidad==0)?Convert.DBNull:tbl_detalleVenta.Cantidad),
				new SqlParameter("@subtotal", (tbl_detalleVenta.Subtotal==0)?Convert.DBNull:tbl_detalleVenta.Subtotal)
			};

			try
			{
			int CodigoIdentity = -1;
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaInsert", parameters);
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Deletes a record from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public virtual void DeleteAllByProducto_id(int producto_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@producto_id", producto_id)
			};

			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaDeleteAllByProducto_id", parameters);
		}

		/// <summary>
		/// Deletes a record from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public virtual void DeleteAllByVenta_id(int venta_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", venta_id)
			};

			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaDeleteAllByVenta_id", parameters);
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_tbl_detalleVentaSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table.
		/// </summary>
		public virtual List<EN_Tbl_detalleVenta> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaSelectAll"))
			{
				List<EN_Tbl_detalleVenta> tbl_detalleVentaList = new List<EN_Tbl_detalleVenta>();
				while (dataReader.Read())
				{
					EN_Tbl_detalleVenta tbl_detalleVenta = MakeEN_Tbl_detalleVenta(dataReader);
					tbl_detalleVentaList.Add(tbl_detalleVenta);
				}

				return tbl_detalleVentaList;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public virtual List<EN_Tbl_detalleVenta> SelectAllByProducto_id(int producto_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@producto_id", producto_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaSelectAllByProducto_id", parameters))
			{
				List<EN_Tbl_detalleVenta> tbl_detalleVentaList = new List<EN_Tbl_detalleVenta>();
				while (dataReader.Read())
				{
					EN_Tbl_detalleVenta tbl_detalleVenta = MakeEN_Tbl_detalleVenta(dataReader);
					tbl_detalleVentaList.Add(tbl_detalleVenta);
				}

				return tbl_detalleVentaList;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public virtual List<EN_Tbl_detalleVenta> SelectAllByVenta_id(int venta_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@venta_id", venta_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_detalleVentaSelectAllByVenta_id", parameters))
			{
				List<EN_Tbl_detalleVenta> tbl_detalleVentaList = new List<EN_Tbl_detalleVenta>();
				while (dataReader.Read())
				{
					EN_Tbl_detalleVenta tbl_detalleVenta = MakeEN_Tbl_detalleVenta(dataReader);
					tbl_detalleVentaList.Add(tbl_detalleVenta);
				}

				return tbl_detalleVentaList;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_detalleVenta class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Tbl_detalleVenta MakeEN_Tbl_detalleVenta(SqlDataReader dataReader)
		{
			EN_Tbl_detalleVenta oeN_Tbl_detalleVenta = new EN_Tbl_detalleVenta();
			oeN_Tbl_detalleVenta.Venta_id =dataReader.IsDBNull(dataReader.GetOrdinal("venta_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("venta_id"));
			oeN_Tbl_detalleVenta.Producto_id =dataReader.IsDBNull(dataReader.GetOrdinal("producto_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("producto_id"));
			oeN_Tbl_detalleVenta.Precio =dataReader.IsDBNull(dataReader.GetOrdinal("precio"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("precio"));
			oeN_Tbl_detalleVenta.Cantidad =dataReader.IsDBNull(dataReader.GetOrdinal("cantidad"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("cantidad"));
			oeN_Tbl_detalleVenta.Subtotal =dataReader.IsDBNull(dataReader.GetOrdinal("subtotal"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("subtotal"));

			return oeN_Tbl_detalleVenta;
		}

		#endregion
	}
}
