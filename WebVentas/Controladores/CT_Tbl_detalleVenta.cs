using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Tbl_detalleVenta
	{
		#region Variables

		EN_Tbl_detalleVenta oEN_Tbl_detalleVenta = new EN_Tbl_detalleVenta();
		AD_Tbl_detalleVenta oAD_Tbl_detalleVenta = new AD_Tbl_detalleVenta();

		#endregion

		#region Constructors

		public CT_Tbl_detalleVenta()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Tbl_detalleVenta
		/// </summary>
		public string Insert(EN_Tbl_detalleVenta tbl_detalleventa)
		{
			string resultado = oAD_Tbl_detalleVenta.Insert(tbl_detalleventa);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public List<EN_Tbl_detalleVenta> SelectAllByProducto_id(int producto_id)
		{
			return oAD_Tbl_detalleVenta.SelectAllByProducto_id(producto_id);
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public List<EN_Tbl_detalleVenta> SelectAllByVenta_id(int venta_id)
		{
			return oAD_Tbl_detalleVenta.SelectAllByVenta_id(venta_id);
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table.
		/// </summary>
		public DataSet Tbl_detalleVentaSelectAll()
		{
			return oAD_Tbl_detalleVenta.SelectAll();
		}

		/// <summary>
		/// Selects all records from the tbl_detalleVenta table.
		/// </summary>
		public List<EN_Tbl_detalleVenta> SelectAllList()
		{
			return oAD_Tbl_detalleVenta.SelectAllList();
		}

#region En desarrollo. . .
/*
		/// <summary>
		/// Deletes a record from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public string DeleteAllByProducto_id(int producto_id)
		{
			string resultado = oAD_Tbl_detalleVenta.Delete();
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Deletes a record from the tbl_detalleVenta table by a foreign key.
		/// </summary>
		public string DeleteAllByVenta_id(int venta_id)
		{
			string resultado = oAD_Tbl_detalleVenta.Delete();
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Creates a new instance of the tbl_detalleVenta class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected EN_Tbl_detalleVenta MakeTbl_detalleVenta()
		{
			Tbl_detalleVenta tbl_detalleVenta = new Tbl_detalleVenta();
			return tbl_detalleVenta;
		}

*/
#endregion

		#endregion
	}
}
