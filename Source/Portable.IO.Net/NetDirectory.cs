namespace Portable.IO
{
	internal sealed class NetDirectory : IDirectory
	{
		public NetDirectory(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public string Name { get; private set; }

		public string Path { get; private set; }

		public bool Exists
		{
			get { return System.IO.Directory.Exists(this.Path); }
		}
	}
}