namespace Portable.IO
{
	using System.IO;
	using System.IO.IsolatedStorage;

	internal sealed class WindowsPhoneFile : FileBase
	{
		private static IsolatedStorageFile Root = IsolatedStorageFile.GetUserStoreForApplication();

		public WindowsPhoneFile(string path)
		{
			throw new System.NotImplementedException();
		}

		public override string Name { get; protected set; }

		public override string Path { get; protected set; }

		public override bool Exists
		{
			get { throw new System.NotImplementedException(); }
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