namespace Portable.IO
{
	using System.Threading.Tasks;

	internal sealed class NetFileSystem : IFileSystem
	{
		public IFile GetFile(string path)
		{
			return new NetFile(path);
		}

		public async Task<IFile> GetFileAsync(string path)
		{
			return await Task.Run(() => this.GetFile(path));
		}

		public IDirectory GetDirectory(string path)
		{
			return new NetDirectory(path);
		}

		public async Task<IDirectory> GetDirectoryAsync(string path)
		{
			return await Task.Run(() => this.GetDirectory(path));
		}
	}
}