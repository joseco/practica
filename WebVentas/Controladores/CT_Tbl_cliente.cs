using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace Controladores
{
	public class CT_Tbl_cliente
	{
		#region Variables

		EN_Tbl_cliente oEN_Tbl_cliente = new EN_Tbl_cliente();
		AD_Tbl_cliente oAD_Tbl_cliente = new AD_Tbl_cliente();

		#endregion

		#region Constructors

		public CT_Tbl_cliente()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Almacenar datos en la Entidad EN_Tbl_cliente
		/// </summary>
		public string Insert(EN_Tbl_cliente tbl_cliente)
		{
			string resultado = oAD_Tbl_cliente.Insert(tbl_cliente);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects a single record from the tbl_cliente table.
		/// </summary>
		public EN_Tbl_cliente Select(int cliente_id)
		{
			return oAD_Tbl_cliente.Select(cliente_id);
		}

		/// <summary>
		/// Actualizar datos en la Entidad EN_Tbl_cliente
		/// </summary>
		public string Update(EN_Tbl_cliente tbl_cliente)
		{
			string resultado = oAD_Tbl_cliente.Update(tbl_cliente);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Deletes a record from the tbl_cliente table by its primary key.
		/// </summary>
		public string Delete(int cliente_id)
		{
			string resultado = oAD_Tbl_cliente.Delete(cliente_id);
			if (resultado.Contains("Error")) return resultado;
			else
			{
				return resultado;
			}
		}

		/// <summary>
		/// Selects all records from the tbl_cliente table.
		/// </summary>
		public DataSet Tbl_clienteSelectAll()
		{
			return oAD_Tbl_cliente.SelectAll();
		}

		/// <summary>
		/// Selects all records from the tbl_cliente table.
		/// </summary>
		public List<EN_Tbl_cliente> SelectAllList()
		{
			return oAD_Tbl_cliente.SelectAllList();
		}
      

        #region En desarrollo. . .
        /*
                /// <summary>
                /// Creates a new instance of the tbl_cliente class and populates it with data from the specified SqlDataReader.
                /// </summary>
                protected EN_Tbl_cliente MakeTbl_cliente()
                {
                    Tbl_cliente tbl_cliente = new Tbl_cliente();
                    return tbl_cliente;
                }

        */
        #endregion

        #endregion
    }
}
