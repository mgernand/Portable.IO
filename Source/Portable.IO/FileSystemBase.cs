namespace Portable.IO
{
	using System.Threading.Tasks;

	internal abstract class FileSystemBase : IFileSystem
	{
		public IDirectory AppDirectory
		{
			get { return this.GetDirectory("."); }
		}

		public abstract IFile GetFile(string path);

		public async Task<IFile> GetFileAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.GetFile(path));
		}

		public bool ExistsFile(string path)
		{
			return this.GetFile(path).Exists;
		}

		public async Task<bool> ExistsFileAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.ExistsFile(path));
		}

		public abstract IDirectory GetDirectory(string path);

		public async Task<IDirectory> GetDirectoryAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.GetDirectory(path));
		}

		public bool ExistsDirectory(string path)
		{
			return this.GetDirectory(path).Exists;
		}

		public async Task<bool> ExistsDirectoryAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.ExistsDirectory(path));
		}
	}
}