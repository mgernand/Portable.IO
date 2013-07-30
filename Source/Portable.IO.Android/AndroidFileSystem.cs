using System;

namespace Portable.IO.Android
{
	internal sealed class AndroidFileSystem : FileSytemBase
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
