namespace Portable.IO
{
	internal sealed class AndroidFileSystem : FileSystemBase
	{
		public override IFile GetFile(string path)
		{
			return new AndroidFile(path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new AndroidDirectory(path);
		}
	}
}
