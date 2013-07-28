namespace Portable.IO
{
	using System.Collections.Generic;

	internal sealed class NetDirectory : DirectoryBase
	{
		public NetDirectory(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override string Name { get; protected set; }

		public override string Path { get; protected set; }

		public override bool Exists
		{
			get { return System.IO.Directory.Exists(this.Path); }
		}

		public override IFile CreateFile(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IFile GetFile(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IEnumerable<IFile> GetFiles()
		{
			throw new System.NotImplementedException();
		}

		public override IDirectory CreateDirectory(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IDirectory GetDirectory(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			throw new System.NotImplementedException();
		}

		public override void Delete()
		{
			throw new System.NotImplementedException();
		}
	}
}