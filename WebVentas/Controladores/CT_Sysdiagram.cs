using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Sysdiagram
	{
		#region Variables

		EN_Sysdiagram oEN_Sysdiagram = new EN_Sysdiagram();
		AD_Sysdiagram oAD_Sysdiagram = new AD_Sysdiagram();

		#endregion

		#region Constructors

		public CT_Sysdiagram()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Sysdiagram
		/// </summary>
		public string Insert(EN_Sysdiagram sysdiagram)
		{
			string resultado = oAD_Sysdiagram.Insert(sysdiagram);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects a single record from the sysdiagrams table.
		/// </summary>
		public EN_Sysdiagram Select(int diagram_id)
		{
			return oAD_Sysdiagram.Select(diagram_id);
		}

		/// <summary>
		/// Actualizar datos en la Entidad EN_Sysdiagram
		/// </summary>
		public string Update(EN_Sysdiagram sysdiagram)
		{
			string resultado = oAD_Sysdiagram.Update(sysdiagram);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Deletes a record from the sysdiagrams table by its primary key.
		/// </summary>
		public string Delete(int diagram_id)
		{
			string resultado = oAD_Sysdiagram.Delete(diagram_id);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the sysdiagrams table.
		/// </summary>
		public DataSet SysdiagramSelectAll()
		{
			return oAD_Sysdiagram.SelectAll();
		}

		/// <summary>
		/// Selects all records from the sysdiagrams table.
		/// </summary>
		public List<EN_Sysdiagram> SelectAllList()
		{
			return oAD_Sysdiagram.SelectAllList();
		}

#region En desarrollo. . .
/*
		/// <summary>
		/// Creates a new instance of the sysdiagrams class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected EN_Sysdiagram MakeSysdiagram()
		{
			Sysdiagram sysdiagram = new Sysdiagram();
			return sysdiagram;
		}

*/
#endregion

		#endregion
	}
}
