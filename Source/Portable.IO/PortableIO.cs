namespace Portable.IO
{
	using System;

	public static class PortableIO
	{
		public static void Configure(Type fileSystemFactoryType)
		{
			FileSystem.FileSystemFactoryType = fileSystemFactoryType;
		}
	}
}