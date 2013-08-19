namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Linq;

	internal sealed class AndroidDirectory : DirectoryBase
	{
		public AndroidDirectory(string path)
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
			return new AndroidFile(newPath);
		}

		public override IFile GetFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new AndroidFile(newPath);
		}

		public override IEnumerable<IFile> GetFiles()
		{
			return System.IO.Directory.GetFiles(this.Path).Select(x => new AndroidFile(x)).ToArray();
		}

		public override IEnumerable<string> GetFileNames()
		{
			return System.IO.Directory.GetFiles(this.Path).Select(System.IO.Path.GetFileName).ToArray();
		}

		public override IDirectory CreateDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			System.IO.Directory.CreateDirectory(newPath);
			return new AndroidDirectory(newPath);
		}

		public override IDirectory GetDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new AndroidDirectory(newPath);
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			return System.IO.Directory.GetDirectories(Path).Select(x => new AndroidDirectory(x)).ToArray();
		}

		public override IEnumerable<string> GetDirectoryNames()
		{
			throw new System.NotImplementedException();
		}

		public override void Delete()
		{
			System.IO.Directory.Delete(this.Path, true);
		}
	}
}
