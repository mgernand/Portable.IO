namespace Portable.IO
{
	using System;
	using System.IO;

	internal sealed class IOSFile : FileBase
	{
		public override bool Exists
		{
			get { throw new NotImplementedException(); }
		}

		public override Stream Open(FileAccess fileAccess)
		{
			throw new NotImplementedException();
		}

		public override void Delete()
		{
			throw new NotImplementedException();
		}
	}
}