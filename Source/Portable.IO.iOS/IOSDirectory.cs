namespace Portable.IO
{
	using System;
	using System.Collections.Generic;

	internal sealed class IOSDirectory : DirectoryBase
	{
		public override bool Exists
		{
			get { throw new NotImplementedException(); }
		}

		public override IFile CreateFile(string name)
		{
			throw new NotImplementedException();
		}

		public override IFile GetFile(string name)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<IFile> GetFiles()
		{
			throw new NotImplementedException();
		}

		public override IDirectory CreateDirectory(string name)
		{
			throw new NotImplementedException();
		}

		public override IDirectory GetDirectory(string name)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			throw new NotImplementedException();
		}

		public override void Delete()
		{
			throw new NotImplementedException();
		}
	}
}