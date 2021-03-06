﻿namespace Portable.IO
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.IO.IsolatedStorage;

	[DebuggerDisplay("Name = {Name}")]
	internal sealed class WindowsPhoneFile : FileBase
	{
		private readonly IsolatedStorageFile root;

		public WindowsPhoneFile(IsolatedStorageFile root, string path)
		{
			this.root = root;
			this.Name = System.IO.Path.GetFileName(path);
			this.Path = path;
		}

		public override bool Exists
		{
			get { return this.root.FileExists(this.Path); }
		}

		public override Stream Open(FileAccess fileAccess)
		{
			System.IO.FileAccess nativeFileAccess;
			switch(fileAccess)
			{
				case FileAccess.Read:
					nativeFileAccess = System.IO.FileAccess.Read;
					break;
				case FileAccess.Write:
					nativeFileAccess = System.IO.FileAccess.Write;
					break;
				case FileAccess.ReadWrite:
					nativeFileAccess = System.IO.FileAccess.ReadWrite;
					break;
				default:
					throw new ArgumentOutOfRangeException("fileAccess");
			}

			IsolatedStorageFileStream stream = this.root.OpenFile(this.Path, FileMode.OpenOrCreate, nativeFileAccess, FileShare.Read);
			return stream;
		}

		public override void Delete()
		{
			this.root.DeleteFile(this.Path);
		}

		public override long Length
		{
			get
			{
				long length = 0;

				if(this.Exists)
				{
					using(IsolatedStorageFileStream stream = this.root.OpenFile(this.Path, FileMode.Open, System.IO.FileAccess.Read))
					{
						length = stream.Length;
					}
				}

				return length;
			}
		}
	}
}