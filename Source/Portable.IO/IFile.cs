namespace Portable.IO
{
	using System.IO;
	using System.Threading.Tasks;

	/// <summary>
	/// Facade for a file.
	/// </summary>
	public interface IFile : IFileSystemElement
	{
		//Stream Open(FileAccess fileAccess);

		//Task<Stream> OpenAsync(FileAccess fileAccess);

		//void Delete();

		//Task DeleteAsync();
	}
}
