namespace Portable.IO
{
	internal sealed class NetFileSystem : FileSystemBase
	{
		public override IDirectory AppDirectory
		{
			get { throw new System.NotImplementedException(); }
		}

		public override IFile GetFile(string path)
		{
			return new NetFile(path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new NetDirectory(path);
		}
	}
}
