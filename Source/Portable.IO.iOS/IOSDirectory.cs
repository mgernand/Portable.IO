namespace Portable.IO
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	internal sealed class IOSDirectory : DirectoryBase
	{
		public IOSDirectory(string path)
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
			return new IOSFile(newPath);
		}

		public override IFile GetFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new IOSFile(newPath);
		}

		public override IEnumerable<IFile> GetFiles()
		{
			return System.IO.Directory.GetFiles(this.Path).Select(x => new IOSFile(x)).ToArray();
		}

		public override IEnumerable<string> GetFileNames()
		{
			return System.IO.Directory.GetFiles(this.Path).Select(System.IO.Path.GetFileName).ToArray();
		}

		public override IDirectory CreateDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			System.IO.Directory.CreateDirectory(newPath);
			return new IOSDirectory(newPath);
		}

		public override IDirectory GetDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new IOSDirectory(newPath);
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			return System.IO.Directory.GetDirectories(Path).Select(x => new IOSDirectory(x)).ToArray();
		}

		public override IEnumerable<string> GetDirectoryNames()
		{
			throw new NotImplementedException();
		}

		public override void Delete()
		{
			System.IO.Directory.Delete(this.Path, true);
		}
	}
}