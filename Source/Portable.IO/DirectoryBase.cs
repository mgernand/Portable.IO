namespace Portable.IO
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	internal abstract class DirectoryBase : FileSystemElementBase, IDirectory
	{
		public abstract IFile CreateFile(string name);

		public Task<IFile> CreateFileAsync(string name)
		{
			return Task.Factory.StartNew(() => this.CreateFile(name));
		}

		public abstract IFile GetFile(string name);

		//public Task<IFile> GetFileAsync(string name)
		//{
		//	return Task.Factory.StartNew(() => this.GetFile(name));
		//}

		public abstract IEnumerable<IFile> GetFiles();

		//public Task<IEnumerable<IFile>> GetFilesAsync()
		//{
		//	return Task.Factory.StartNew(() => this.GetFiles());
		//}

		public IEnumerable<string> GetFileNames()
		{
			return this.GetFiles().Select(x => x.Name);
		}

		//public Task<IEnumerable<string>> GetFileNamesAsync()
		//{
		//	return Task.Factory.StartNew(() => this.GetFileNames());
		//}

		public abstract IDirectory CreateDirectory(string name);

		public Task<IDirectory> CreateDirectoryAsync(string name)
		{
			return Task.Factory.StartNew(() => this.CreateDirectory(name));
		}

		public abstract IDirectory GetDirectory(string name);

		//public Task<IDirectory> GetDirectoryAsync(string name)
		//{
		//	return Task.Factory.StartNew(() => this.GetDirectory(name));
		//}

		public abstract IEnumerable<IDirectory> GetDirectories();

		//public Task<IEnumerable<IDirectory>> GetDirectoriesAsync()
		//{
		//	return Task.Factory.StartNew(() => this.GetDirectories());
		//}

		public IEnumerable<string> GetDirectoryNames()
		{
			return this.GetDirectories().Select(x => x.Name);
		}

		//public Task<IEnumerable<string>> GetDirectoryNamesAsync()
		//{
		//	return Task.Factory.StartNew(() => this.GetDirectoryNames());
		//}

		public bool ExistsFile(string fileName)
		{
			return this.GetFileNames().Contains(fileName);
		}

		public bool ExistsDirectory(string directoryName)
		{
			return this.GetDirectoryNames().Contains(directoryName);
		}

		public abstract void Delete();

		public Task DeleteAsync()
		{
			return Task.Factory.StartNew(this.Delete);
		}

		public long FileCount
		{
			get { return this.GetFileNames().LongCount(); }
		}

		public long DirectoryCount
		{
			get { return this.GetDirectoryNames().LongCount(); }
		}
	}
}