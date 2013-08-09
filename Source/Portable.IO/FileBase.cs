namespace Portable.IO
{
	using System.IO;
	using System.Threading.Tasks;

	internal abstract class FileBase : FileSystemElementBase, IFile
	{
		public abstract Stream Open(FileAccess fileAccess);

		public async Task<Stream> OpenAsync(FileAccess fileAccess)
		{
			return await Task.Factory.StartNew(() => this.Open(fileAccess));
		}

		public abstract void Delete();

		public async Task DeleteAsync()
		{
			await Task.Factory.StartNew(this.Delete);
		}

		public abstract long Length { get; }
	}
}