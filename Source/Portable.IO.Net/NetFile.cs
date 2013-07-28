namespace Portable.IO
{
	internal sealed class NetFile : IFile
	{
		public NetFile(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public string Name { get; private set; }

		public string Path { get; private set; }

		public bool Exists
		{
			get { return System.IO.File.Exists(this.Path); }
		}
	}
}