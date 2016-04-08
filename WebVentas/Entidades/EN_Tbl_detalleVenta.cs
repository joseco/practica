using System;

namespace Entidades
{
	public class EN_Tbl_detalleVenta
	{
		#region Fields

		private int venta_id;
		private int producto_id;
		private int precio;
		private int cantidad;
		private int subtotal;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EN_Tbl_detalleVenta class.
		/// </summary>
		public EN_Tbl_detalleVenta()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EN_Tbl_detalleVenta class.
		/// </summary>
		public EN_Tbl_detalleVenta(int venta_id, int producto_id, int precio, int cantidad, int subtotal)
		{
			this.venta_id = venta_id;
			this.producto_id = producto_id;
			this.precio = precio;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Venta_id value.
		/// </summary>
		public virtual int Venta_id
		{
			get { return venta_id; }
			set { venta_id = value; }
		}

		/// <summary>
		/// Gets or sets the Producto_id value.
		/// </summary>
		public virtual int Producto_id
		{
			get { return producto_id; }
			set { producto_id = value; }
		}

		/// <summary>
		/// Gets or sets the Precio value.
		/// </summary>
		public virtual int Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		/// <summary>
		/// Gets or sets the Cantidad value.
		/// </summary>
		public virtual int Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}

		/// <summary>
		/// Gets or sets the Subtotal value.
		/// </summary>
		public virtual int Subtotal
		{
			get { return subtotal; }
			set { subtotal = value; }
		}

		#endregion
	}
}
