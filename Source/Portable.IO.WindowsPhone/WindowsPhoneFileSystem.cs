namespace Portable.IO
{
	using System.IO.IsolatedStorage;

	internal sealed class WindowsPhoneFileSystem : FileSystemBase
	{
		private static readonly IsolatedStorageFile Root = IsolatedStorageFile.GetUserStoreForApplication();

		public override IDirectory AppDirectory
		{
			get { throw new System.NotImplementedException(); }
		}

		public override IFile GetFile(string path)
		{
			return new WindowsPhoneFile(Root, path);
		}

		public override IDirectory GetDirectory(string path)
		{
			return new WindowsPhoneDirectory(Root, path);
		}
	}
}