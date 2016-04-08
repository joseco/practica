using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Tbl_producto
	{
		#region Variables

		EN_Tbl_producto oEN_Tbl_producto = new EN_Tbl_producto();
		AD_Tbl_producto oAD_Tbl_producto = new AD_Tbl_producto();

		#endregion

		#region Constructors

		public CT_Tbl_producto()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Tbl_producto
		/// </summary>
		public string Insert(EN_Tbl_producto tbl_producto)
		{
			string resultado = oAD_Tbl_producto.Insert(tbl_producto);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects a single record from the tbl_producto table.
		/// </summary>
		public EN_Tbl_producto Select(int producto_id)
		{
			return oAD_Tbl_producto.Select(producto_id);
		}

		/// <summary>
		/// Actualizar datos en la Entidad EN_Tbl_producto
		/// </summary>
		public string Update(EN_Tbl_producto tbl_producto)
		{
			string resultado = oAD_Tbl_producto.Update(tbl_producto);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Deletes a record from the tbl_producto table by its primary key.
		/// </summary>
		public string Delete(int producto_id)
		{
			string resultado = oAD_Tbl_producto.Delete(producto_id);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_producto table.
		/// </summary>
		public DataSet Tbl_productoSelectAll()
		{
			return oAD_Tbl_producto.SelectAll();
		}

		/// <summary>
		/// Selects all records from the tbl_producto table.
		/// </summary>
		public List<EN_Tbl_producto> SelectAllList()
		{
			return oAD_Tbl_producto.SelectAllList();
		}

#region En desarrollo. . .
/*
		/// <summary>
		/// Creates a new instance of the tbl_producto class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected EN_Tbl_producto MakeTbl_producto()
		{
			Tbl_producto tbl_producto = new Tbl_producto();
			return tbl_producto;
		}

*/
#endregion

		#endregion
	}
}
