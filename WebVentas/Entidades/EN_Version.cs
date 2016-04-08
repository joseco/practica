using System;

namespace Entidades
{
	public class EN_Version
	{
		#region Fields

		private int versionMayor;
		private int versionMenor;
		private int patch;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EN_Version class.
		/// </summary>
		public EN_Version()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EN_Version class.
		/// </summary>
		public EN_Version(int versionMayor, int versionMenor, int patch)
		{
			this.versionMayor = versionMayor;
			this.versionMenor = versionMenor;
			this.patch = patch;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the VersionMayor value.
		/// </summary>
		public virtual int VersionMayor
		{
			get { return versionMayor; }
			set { versionMayor = value; }
		}

		/// <summary>
		/// Gets or sets the VersionMenor value.
		/// </summary>
		public virtual int VersionMenor
		{
			get { return versionMenor; }
			set { versionMenor = value; }
		}

		/// <summary>
		/// Gets or sets the Patch value.
		/// </summary>
		public virtual int Patch
		{
			get { return patch; }
			set { patch = value; }
		}

		#endregion
	}
}
