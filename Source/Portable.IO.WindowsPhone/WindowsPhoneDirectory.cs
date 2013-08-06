namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using System.IO.IsolatedStorage;
	using System.Linq;

	internal sealed class WindowsPhoneDirectory : DirectoryBase
	{
		private readonly IsolatedStorageFile root;

		public WindowsPhoneDirectory(IsolatedStorageFile root, string path)
		{
			this.root = root;

			path = System.IO.Path.GetFullPath(path);
			if (path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture)))
			{
				path = path.Substring(0, path.Length - 1);
			}
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override bool Exists
		{
			get { return this.root.DirectoryExists(this.Path); }
		}

		public override IFile CreateFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			new IsolatedStorageFileStream(newPath, FileMode.OpenOrCreate, this.root).Dispose();
			return new WindowsPhoneFile(this.root, newPath);
		}

		public override IFile GetFile(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new WindowsPhoneFile(this.root, newPath);
		}

		public override IEnumerable<IFile> GetFiles()
		{
			return this.root.GetFileNames().Select(x => new WindowsPhoneFile(this.root, System.IO.Path.Combine(this.Path, x))).ToArray();
		}

		public override IDirectory CreateDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			this.root.CreateDirectory(newPath);
			return new WindowsPhoneDirectory(this.root, newPath);
		}

		public override IDirectory GetDirectory(string name)
		{
			string newPath = System.IO.Path.Combine(this.Path, name);
			return new WindowsPhoneDirectory(this.root, newPath);
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			return this.root.GetDirectoryNames().Select(x => new WindowsPhoneDirectory(this.root, System.IO.Path.Combine(this.Path, x))).ToArray();
		}

		public override void Delete()
		{
			this.root.DeleteDirectory(this.Path);
		}
	}
}