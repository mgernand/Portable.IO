namespace Portable.IO
{
	using System.IO;

	internal sealed class NetFile : FileBase
	{
		public NetFile(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override string Name { get; protected set; }

		public override string Path { get; protected set; }

		public override bool Exists
		{
			get { return System.IO.File.Exists(this.Path); }
		}

		public override Stream Open(FileAccess fileAccess)
		{
			throw new System.NotImplementedException();
		}

		public override void Delete()
		{
			throw new System.NotImplementedException();
		}
	}
}