namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IDirectory : IFileSystemElement
	{
		IFile CreateFile(string name);

		Task<IFile> CreateFileAsync(string name);

		IFile GetFile(string name);

		IEnumerable<IFile> GetFiles();

		//Task<IEnumerable<IFile>> GetFilesAsync();

		IEnumerable<string> GetFileNames();

		//Task<IEnumerable<string>> GetFileNamesAsync();
			
		IDirectory CreateDirectory(string name);

		Task<IDirectory> CreateDirectoryAsync(string name);

		IDirectory GetDirectory(string name);

		//Task<IDirectory> GetDirectoryAsync(string name);

		IEnumerable<IDirectory> GetDirectories();

		//Task<IEnumerable<IDirectory>> GetDirectoriesAsync();

		IEnumerable<string> GetDirectoryNames();

		//Task<IEnumerable<string>> GetDirectoryNamesAsync();

		/// <summary>
		/// Checks if the file specified by the given fileName exists in this directory.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		bool ExistsFile(string fileName);

		/// <summary>
		/// Checks if the directory specified by the given directoryName exists in this directory.
		/// </summary>
		/// <param name="directoryName"></param>
		/// <returns></returns>
		bool ExistsDirectory(string directoryName);

		void Delete();

		Task DeleteAsync();

		long FileCount { get; }

		long DirectoryCount { get; }
	}
}
