namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	internal abstract class DirectoryBase : FileSystemElementBase, IDirectory
	{
		public abstract IFile CreateFile(string name);

		public async Task<IFile> CreateFileAsync(string name)
		{
			return await Task.Factory.StartNew(() => this.CreateFile(name));
		}

		public abstract IFile GetFile(string name);

		public async Task<IFile> GetFileAsync(string name)
		{
			return await Task.Factory.StartNew(() => this.GetFile(name));
		}

		public abstract IEnumerable<IFile> GetFiles();

		public async Task<IEnumerable<IFile>> GetFilesAsync()
		{
			return await Task.Factory.StartNew(() => this.GetFiles());
		}

		public abstract IDirectory CreateDirectory(string name);

		public async Task<IDirectory> CreateDirectoryAsync(string name)
		{
			return await Task.Factory.StartNew(() => this.CreateDirectory(name));
		}

		public abstract IDirectory GetDirectory(string name);

		public async Task<IDirectory> GetDirectoryAsync(string name)
		{
			return await Task.Factory.StartNew(() => this.GetDirectory(name));
		}

		public abstract IEnumerable<IDirectory> GetDirectories();

		public async Task<IEnumerable<IDirectory>> GetDirectoriesAsync()
		{
			return await Task.Factory.StartNew(() => this.GetDirectories());
		}

		public abstract void Delete();

		public async Task DeleteAsync()
		{
			await Task.Factory.StartNew(this.Delete);
		}
	}
}