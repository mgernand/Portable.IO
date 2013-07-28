namespace Portable.IO
{
	using System;

	public static class FileSystem
	{
		private static IFileSystem CurrentFileSystem;

		public static IFileSystem Current
		{
			get
			{
				if(CurrentFileSystem == null)
				{
					IFileSystemFactory fileSystemFactory = (IFileSystemFactory)Activator.CreateInstance(FileSystemFactoryType);
					CurrentFileSystem = fileSystemFactory.CreateFileSystem();
				}

				return CurrentFileSystem;
			}
		}

		internal static Type FileSystemFactoryType { private get; set; }
	}
}
