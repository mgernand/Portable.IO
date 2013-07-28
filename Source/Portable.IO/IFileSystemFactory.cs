namespace Portable.IO
{
	/// <summary>
	/// Contract for all implementations of <see cref="IFileSystemFactory"/>.
	/// </summary>
	public interface IFileSystemFactory
	{
		/// <summary>
		/// Creates an platform specific implementation of <see cref="IFileSystem"/>.
		/// </summary>
		/// <returns></returns>
		IFileSystem CreateFileSystem();
	}
}