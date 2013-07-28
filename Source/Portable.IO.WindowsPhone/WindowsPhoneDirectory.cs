namespace Portable.IO
{
	using System.Collections.Generic;
	using System.IO.IsolatedStorage;

	internal sealed class WindowsPhoneDirectory : DirectoryBase
	{
		private static IsolatedStorageFile Root = IsolatedStorageFile.GetUserStoreForApplication();

		public WindowsPhoneDirectory(string path)
		{
			throw new System.NotImplementedException();
		}

		public override string Name { get; protected set; }

		public override string Path { get; protected set; }

		public override bool Exists
		{
			get { throw new System.NotImplementedException(); }
		}

		public override IFile CreateFile(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IFile GetFile(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IEnumerable<IFile> GetFiles()
		{
			throw new System.NotImplementedException();
		}

		public override IDirectory CreateDirectory(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IDirectory GetDirectory(string name)
		{
			throw new System.NotImplementedException();
		}

		public override IEnumerable<IDirectory> GetDirectories()
		{
			throw new System.NotImplementedException();
		}

		public override void Delete()
		{
			throw new System.NotImplementedException();
		}
	}
}