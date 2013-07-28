using System;

namespace Portable.IO.Android
{
	internal sealed class AndroidFileSystem : FileSytemBase
	{
		public override IFile GetFile (string path)
		{
			throw new NotImplementedException ();
		}

		public override IDirectory GetDirectory (string path)
		{
			throw new NotImplementedException ();
		}
	}
}
