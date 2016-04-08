using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
	public class AD_Version
	{
		#region Variables

		protected AD_Conexion con = new AD_Conexion();
		protected EN_Version oEN_Version = new EN_Version();  
		SqlConnection cn; 

		#endregion

		#region Constructors

		public AD_Version()
		{
			cn = new SqlConnection(con.CadenaConexion);

		}

		#endregion

		#region Methods

		/// <summary>
		/// Insertar filas dentro de la tablaVersion
		/// </summary>
		public virtual string Insert(EN_Version version)
		{
			SqlCommand comComando = new SqlCommand();
			comComando.Connection = cn;

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@versionMayor", (version.VersionMayor==0)?Convert.DBNull:version.VersionMayor),
				new SqlParameter("@versionMenor", (version.VersionMenor==0)?Convert.DBNull:version.VersionMenor),
				new SqlParameter("@patch", (version.Patch==0)?Convert.DBNull:version.Patch)
			};

			try
			{
			int CodigoIdentity = -1;
			SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "sp_VersionInsert", parameters);
			return "Operacion Exitosa " + CodigoIdentity;
			}
			catch (Exception e)
			{
			return "Error: "+e;
			}
		}

		/// <summary>
		/// Selects all records from the Version table.
		/// </summary>
		public DataSet SelectAll()
		{
			SqlCommand cmd = new SqlCommand("sp_VersionSelectAll",cn);
			cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}

		/// <summary>
		/// Selects all records from the Version table.
		/// </summary>
		public virtual List<EN_Version> SelectAllList()
		{
			using (SqlDataReader dataReader = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "sp_VersionSelectAll"))
			{
				List<EN_Version> versionList = new List<EN_Version>();
				while (dataReader.Read())
				{
					EN_Version version = MakeEN_Version(dataReader);
					versionList.Add(version);
				}

				return versionList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Version class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual EN_Version MakeEN_Version(SqlDataReader dataReader)
		{
			EN_Version oeN_Version = new EN_Version();
			oeN_Version.VersionMayor =dataReader.IsDBNull(dataReader.GetOrdinal("versionMayor"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("versionMayor"));
			oeN_Version.VersionMenor =dataReader.IsDBNull(dataReader.GetOrdinal("versionMenor"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("versionMenor"));
			oeN_Version.Patch =dataReader.IsDBNull(dataReader.GetOrdinal("patch"))? 0 : dataReader.GetInt32(dataReader.GetOrdinal("patch"));

			return oeN_Version;
		}

		#endregion
	}
}
