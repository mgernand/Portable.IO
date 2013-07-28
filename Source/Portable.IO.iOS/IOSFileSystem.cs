namespace Portable.IO
{
	using System;

	internal sealed class IOSFileSystem : FileSystemBase
	{
		public override IFile GetFile(string path)
		{
			throw new NotImplementedException();
		}

		public override IDirectory GetDirectory(string path)
		{
			throw new NotImplementedException();
		}
	}
}