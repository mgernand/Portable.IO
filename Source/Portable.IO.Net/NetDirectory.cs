namespace Portable.IO
{
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
	}
}