using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Tbl_producto
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Tbl_producto oEN_Tbl_producto = new EN_Tbl_producto();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Tbl_producto()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablatbl_producto
		/// </summary>
		public virtual string Insert(EN_Tbl_producto tbl_producto)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@nombre", (tbl_producto.Nombre==String.Empty)?Convert.DBNull:tbl_producto.Nombre),
				new SqlParameter("@precio", (tbl_producto.Precio==0)?Convert.DBNull:tbl_producto.Precio)
			};

			try
			{
			int CodigoIdentity = -1;
			tbl_producto.Producto_id = (int) SqlHelper.ExecuteScalar(cn, CommandType.StoredProcedure, "sp_tbl_productoInsert", parameters);
			CodigoIdentity = tbl_producto.Producto_id;
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Actualizar filas en tbl_producto table.
		/// </summary>
		public virtual string Update(EN_Tbl_producto tbl_producto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@producto_id", (tbl_producto.Producto_id==0)?Convert.DBNull:tbl_producto.Producto_id),
				new SqlParameter("@nombre", (tbl_producto.Nombre==String.Empty)?Convert.DBNull:tbl_producto.Nombre),
				new SqlParameter("@precio", (tbl_producto.Precio==0)?Convert.DBNull:tbl_producto.Precio)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_productoUpdate", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Elimina filas desde tbl_producto table by its primary key.
		/// </summary>
		public virtual string Delete(int producto_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@producto_id", producto_id)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_tbl_productoDelete", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Seleccionar una fila desde tbl_producto table.
		/// </summary>
		public virtual EN_Tbl_producto Select(int producto_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@producto_id", producto_id)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_productoSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeEN_Tbl_producto(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the tbl_producto table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_tbl_productoSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the tbl_producto table.
		/// </summary>
		public virtual List<EN_Tbl_producto> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_tbl_productoSelectAll"))
			{
				List<EN_Tbl_producto> tbl_productoList = new List<EN_Tbl_producto>();
				while (dataReader.Read())
				{
					EN_Tbl_producto tbl_producto = MakeEN_Tbl_producto(dataReader);
					tbl_productoList.Add(tbl_producto);
				}

				return tbl_productoList;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_producto class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Tbl_producto MakeEN_Tbl_producto(SqlDataReader dataReader)
		{
			EN_Tbl_producto oeN_Tbl_producto = new EN_Tbl_producto();
			oeN_Tbl_producto.Producto_id =dataReader.IsDBNull(dataReader.GetOrdinal("producto_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("producto_id"));
			oeN_Tbl_producto.Nombre =dataReader.IsDBNull(dataReader.GetOrdinal("nombre"))? String.Empty : dataReader.GetString(dataReader.GetOrdinal("nombre"));
			oeN_Tbl_producto.Precio =dataReader.IsDBNull(dataReader.GetOrdinal("precio"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("precio"));

			return oeN_Tbl_producto;
		}

		#endregion
	}
}
