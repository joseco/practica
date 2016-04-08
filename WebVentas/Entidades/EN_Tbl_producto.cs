using System;

namespace Entidades
{
	public class EN_Tbl_producto
	{
		#region Fields

		private int producto_id;
		private string nombre;
		private int precio;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EN_Tbl_producto class.
		/// </summary>
		public EN_Tbl_producto()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EN_Tbl_producto class.
		/// </summary>
		public EN_Tbl_producto(string nombre, int precio)
		{
			this.nombre = nombre;
			this.precio = precio;
		}

		/// <summary>
		/// Initializes a new instance of the EN_Tbl_producto class.
		/// </summary>
		public EN_Tbl_producto(int producto_id, string nombre, int precio)
		{
			this.producto_id = producto_id;
			this.nombre = nombre;
			this.precio = precio;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Producto_id value.
		/// </summary>
		public virtual int Producto_id
		{
			get { return producto_id; }
			set { producto_id = value; }
		}

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public virtual string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		/// <summary>
		/// Gets or sets the Precio value.
		/// </summary>
		public virtual int Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		#endregion
	}
}
