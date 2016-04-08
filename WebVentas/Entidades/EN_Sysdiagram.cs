using System;

namespace Entidades
{
	public class EN_Sysdiagram
	{
		#region Fields

		private string name;
		private int principal_id;
		private int diagram_id;
		private int version;
		private byte[] definition;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EN_Sysdiagram class.
		/// </summary>
		public EN_Sysdiagram()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EN_Sysdiagram class.
		/// </summary>
		public EN_Sysdiagram(string name, int principal_id, int version, byte[] definition)
		{
			this.name = name;
			this.principal_id = principal_id;
			this.version = version;
			this.definition = definition;
		}

		/// <summary>
		/// Initializes a new instance of the EN_Sysdiagram class.
		/// </summary>
		public EN_Sysdiagram(string name, int principal_id, int diagram_id, int version, byte[] definition)
		{
			this.name = name;
			this.principal_id = principal_id;
			this.diagram_id = diagram_id;
			this.version = version;
			this.definition = definition;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets or sets the Principal_id value.
		/// </summary>
		public virtual int Principal_id
		{
			get { return principal_id; }
			set { principal_id = value; }
		}

		/// <summary>
		/// Gets or sets the Diagram_id value.
		/// </summary>
		public virtual int Diagram_id
		{
			get { return diagram_id; }
			set { diagram_id = value; }
		}

		/// <summary>
		/// Gets or sets the Version value.
		/// </summary>
		public virtual int Version
		{
			get { return version; }
			set { version = value; }
		}

		/// <summary>
		/// Gets or sets the Definition value.
		/// </summary>
		public virtual byte[] Definition
		{
			get { return definition; }
			set { definition = value; }
		}

		#endregion
	}
}
