using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Sysdiagram
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Sysdiagram oEN_Sysdiagram = new EN_Sysdiagram();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Sysdiagram()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablasysdiagrams
		/// </summary>
		public virtual string Insert(EN_Sysdiagram sysdiagram)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@name", (sysdiagram.Name==String.Empty)?Convert.DBNull:sysdiagram.Name),
				new SqlParameter("@principal_id", (sysdiagram.Principal_id==0)?Convert.DBNull:sysdiagram.Principal_id),
				new SqlParameter("@version", (sysdiagram.Version==0)?Convert.DBNull:sysdiagram.Version),
				new SqlParameter("@definition", (sysdiagram.Definition==new byte[0])?Convert.DBNull:sysdiagram.Definition)
			};

			try
			{
			int CodigoIdentity = -1;
			sysdiagram.Diagram_id = (int) SqlHelper.ExecuteScalar(cn, CommandType.StoredProcedure, "sp_sysdiagramsInsert", parameters);
			CodigoIdentity = sysdiagram.Diagram_id;
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Actualizar filas en sysdiagrams table.
		/// </summary>
		public virtual string Update(EN_Sysdiagram sysdiagram)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@name", (sysdiagram.Name==String.Empty)?Convert.DBNull:sysdiagram.Name),
				new SqlParameter("@principal_id", (sysdiagram.Principal_id==0)?Convert.DBNull:sysdiagram.Principal_id),
				new SqlParameter("@diagram_id", (sysdiagram.Diagram_id==0)?Convert.DBNull:sysdiagram.Diagram_id),
				new SqlParameter("@version", (sysdiagram.Version==0)?Convert.DBNull:sysdiagram.Version),
				new SqlParameter("@definition", (sysdiagram.Definition==new byte[0])?Convert.DBNull:sysdiagram.Definition)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_sysdiagramsUpdate", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Elimina filas desde sysdiagrams table by its primary key.
		/// </summary>
		public virtual string Delete(int diagram_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@name", name)
			};

			try
			{
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_sysdiagramsDelete", parameters);
			return "Operacion Exitosa";
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Seleccionar una fila desde sysdiagrams table.
		/// </summary>
		public virtual EN_Sysdiagram Select(int diagram_id)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@name", name)
			};

			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_sysdiagramsSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeEN_Sysdiagram(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sysdiagrams table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_sysdiagramsSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the sysdiagrams table.
		/// </summary>
		public virtual List<EN_Sysdiagram> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_sysdiagramsSelectAll"))
			{
				List<EN_Sysdiagram> sysdiagramList = new List<EN_Sysdiagram>();
				while (dataReader.Read())
				{
					EN_Sysdiagram sysdiagram = MakeEN_Sysdiagram(dataReader);
					sysdiagramList.Add(sysdiagram);
				}

				return sysdiagramList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sysdiagrams class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Sysdiagram MakeEN_Sysdiagram(SqlDataReader dataReader)
		{
			EN_Sysdiagram oeN_Sysdiagram = new EN_Sysdiagram();
			oeN_Sysdiagram.Name =dataReader.IsDBNull(dataReader.GetOrdinal("name"))? String.Empty : dataReader.GetString(dataReader.GetOrdinal("name"));
			oeN_Sysdiagram.Principal_id =dataReader.IsDBNull(dataReader.GetOrdinal("principal_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("principal_id"));
			oeN_Sysdiagram.Diagram_id =dataReader.IsDBNull(dataReader.GetOrdinal("diagram_id"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("diagram_id"));
			oeN_Sysdiagram.Version =dataReader.IsDBNull(dataReader.GetOrdinal("version"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("version"));
			oeN_Sysdiagram.Definition =dataReader.IsDBNull(dataReader.GetOrdinal("definition"))? new byte[0] : dataReader.GetBytes(dataReader.GetOrdinal("definition"));

			return oeN_Sysdiagram;
		}

		#endregion
	}
}
