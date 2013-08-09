﻿namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IDirectory : IFileSystemElement
	{
		IFile CreateFile(string name);

		Task<IFile> CreateFileAsync(string name);

		IFile GetFile(string name);

		Task<IFile> GetFileAsync(string name);

		IEnumerable<IFile> GetFiles();

		Task<IEnumerable<IFile>> GetFilesAsync();

		IEnumerable<string> GetFileNames();

		Task<IEnumerable<string>> GetFileNamesAsync();
			
		IDirectory CreateDirectory(string name);

		Task<IDirectory> CreateDirectoryAsync(string name);

		IDirectory GetDirectory(string name);

		Task<IDirectory> GetDirectoryAsync(string name);

		IEnumerable<IDirectory> GetDirectories();

		Task<IEnumerable<IDirectory>> GetDirectoriesAsync();

		IEnumerable<string> GetDirectoryNames();

		Task<IEnumerable<string>> GetDirectoryNamesAsync();

		void Delete();

		Task DeleteAsync();

		long FileCount { get; }

		long DirectoryCount { get; }
	}
}
