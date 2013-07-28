namespace Portable.IO.Net
{
	internal sealed class NetFileSystemFactory : IFileSystemFactory
	{
		public IFileSystem CreateFileSystem()
		{
			return new NetFileSystem();
		}
	}
}