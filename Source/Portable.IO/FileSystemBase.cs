namespace Portable.IO
{
	using System.Threading.Tasks;

	internal abstract class FileSystemBase : IFileSystem
	{
		public abstract IFile GetFile(string path);

		public async Task<IFile> GetFileAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.GetFile(path));
		}

		public abstract IDirectory GetDirectory(string path);

		public async Task<IDirectory> GetDirectoryAsync(string path)
		{
			return await Task.Factory.StartNew(() => this.GetDirectory(path));
		}
	}
}