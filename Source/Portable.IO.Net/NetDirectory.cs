namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Linq;

	internal sealed class NetDirectory : DirectoryBase
	{
		public NetDirectory(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override bool Exists
		{
			get { return System.IO.Directory.Exists(this.Path); }
		}

		public override IFile CreateFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			System.IO.File.Create(newPath).Dispose();
			return new NetFile(newPath);
		}

		public override IFile GetFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new NetFile(newPath);
		}

		public override IEnumerable<IFile> GetFiles()
		{
			return System.IO.Directory.GetFiles(this.Path).Select(x => new NetFile(x)).ToArray();
		}

		public override IDirectory CreateDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			System.IO.Directory.CreateDirectory(newPath);
			return new NetDirectory(newPath);
		}

		public override IDirectory GetDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new NetDirectory(newPath);
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			return System.IO.Directory.GetDirectories(Path).Select(x => new NetDirectory(x)).ToArray();
		}

		public override void Delete()
		{
			System.IO.Directory.Delete(this.Path, true);
		}
	}
}