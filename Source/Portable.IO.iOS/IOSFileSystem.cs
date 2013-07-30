namespace Portable.IO
{
	internal sealed class IOSFileSystem : FileSystemBase
	{
		public override IFile GetFile(string path)
		{
			return new IOSFile(path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new IOSDirectory(path);
		}
	}
}