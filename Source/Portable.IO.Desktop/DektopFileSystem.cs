namespace Portable.IO
{
	internal sealed class DektopFileSystem : FileSystemBase
	{
		public override IFile GetFile(string path)
		{
			return new DesktopFile(path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new DesktopDirectory(path);
		}
	}
}
