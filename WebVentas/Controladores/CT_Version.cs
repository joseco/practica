using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Version
	{
		#region Variables

		EN_Version oEN_Version = new EN_Version();
		AD_Version oAD_Version = new AD_Version();

		#endregion

		#region Constructors

		public CT_Version()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Version
		/// </summary>
		public string Insert(EN_Version version)
		{
			string resultado = oAD_Version.Insert(version);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the Version table.
		/// </summary>
		public DataSet VersionSelectAll()
		{
			return oAD_Version.SelectAll();
		}

		/// <summary>
		/// Selects all records from the Version table.
		/// </summary>
		public List<EN_Version> SelectAllList()
		{
			return oAD_Version.SelectAllList();
		}

#region En desarrollo. . .
/*
		/// <summary>
		/// Creates a new instance of the Version class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected EN_Version MakeVersion()
		{
			Version version = new Version();
			return version;
		}

*/
#endregion

		#endregion
	}
}
