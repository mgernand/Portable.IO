namespace Portable.IO
{
	/// <summary>
	/// Contract for platform-specific entry pointsto the underlying file system. 
	/// </summary>
	public interface IFileSystem
	{
		/// <summary>
		/// Gets a file for the given path. 
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IFile GetFile(string path);

		/// <summary>
		/// Gets the directory for the given path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IDirectory GetDirectory(string path);
	}
}
