using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Tbl_venta
	{
		#region Variables

		EN_Tbl_venta oEN_Tbl_venta = new EN_Tbl_venta();
		AD_Tbl_venta oAD_Tbl_venta = new AD_Tbl_venta();

		#endregion

		#region Constructors

		public CT_Tbl_venta()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Tbl_venta
		/// </summary>
		public string Insert(EN_Tbl_venta tbl_venta)
		{
			string resultado = oAD_Tbl_venta.Insert(tbl_venta);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects a single record from the tbl_venta table.
		/// </summary>
		public EN_Tbl_venta Select(int venta_id)
		{
			return oAD_Tbl_venta.Select(venta_id);
		}

		/// <summary>
		/// Actualizar datos en la Entidad EN_Tbl_venta
		/// </summary>
		public string Update(EN_Tbl_venta tbl_venta)
		{
			string resultado = oAD_Tbl_venta.Update(tbl_venta);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_venta table by a foreign key.
		/// </summary>
		public List<EN_Tbl_venta> SelectAllByCliente_id(int cliente_id)
		{
			return oAD_Tbl_venta.SelectAllByCliente_id(cliente_id);
		}

		/// <summary>
		/// Deletes a record from the tbl_venta table by its primary key.
		/// </summary>
		public string Delete(int venta_id)
		{
			string resultado = oAD_Tbl_venta.Delete(venta_id);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_venta table.
		/// </summary>
		public DataSet Tbl_ventaSelectAll()
		{
			return oAD_Tbl_venta.SelectAll();
		}

		/// <summary>
		/// Selects all records from the tbl_venta table.
		/// </summary>
		public List<EN_Tbl_venta> SelectAllList()
		{
			return oAD_Tbl_venta.SelectAllList();
		}

#region En desarrollo. . .
/*
		/// <summary>
		/// Deletes a record from the tbl_venta table by a foreign key.
		/// </summary>
		public string DeleteAllByCliente_id(int cliente_id)
		{
			string resultado = oAD_Tbl_venta.Delete(venta_id);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_venta class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected EN_Tbl_venta MakeTbl_venta()
		{
			Tbl_venta tbl_venta = new Tbl_venta();
			return tbl_venta;
		}

*/
#endregion

		#endregion
	}
}
