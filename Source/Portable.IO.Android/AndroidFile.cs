namespace Portable.IO
{
	using System;
	using System.IO;

	internal sealed class AndroidFile : FileBase
	{
		public AndroidFile(string path)
		{
			path = System.IO.Path.GetFullPath(path);
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override bool Exists
		{
			get { return System.IO.File.Exists(this.Path); }
		}

		public override Stream Open(FileAccess fileAccess)
		{
			Stream result;

			switch(fileAccess)
			{
				case FileAccess.Read:
					result = System.IO.File.OpenRead(this.Path);
					break;
				case FileAccess.Write:
					result = System.IO.File.OpenWrite(this.Path);
					break;
				case FileAccess.ReadWrite:
					result = File.Open(this.Path, FileMode.Open, System.IO.FileAccess.ReadWrite);
					break;
				default:
					throw new ArgumentOutOfRangeException("fileAccess");
			}

			return result;
		}

		public override void Delete()
		{
			System.IO.File.Delete(this.Path);
		}

		public override long Length
		{
			get
			{
				long length = 0;

				if (this.Exists)
				{
					length = new FileInfo(this.Path).Length;
				}

				return length;
			}
		}
	}
}
