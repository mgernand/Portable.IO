namespace Portable.IO
{
	using System.IO.IsolatedStorage;

	internal sealed class WindowsPhoneFileSystem : FileSystemBase
	{
		public override IFile GetFile(string path)
		{
			return new WindowsPhoneFile(path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new WindowsPhoneDirectory(path);
		}
	}
}