namespace Portable.IO
{
	using System.IO;
	using System.Threading.Tasks;

	public interface IFile : IFileSystemElement
	{
		Stream Open(FileAccess fileAccess);

		Task<Stream> OpenAsync(FileAccess fileAccess);

		void Delete();

		Task DeleteAsync();

		long Length { get; }
	}
}
