namespace Portable.IO
{
	public interface IFileSystemElement
	{
		/// <summary>
		/// Gets the name of the element (file or directory).
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the full path of the element (file or directory).
		/// </summary>
		string Path { get; }

		/// <summary>
		/// Returns <code>true</code> if the element (file or directory) exists, <code>false</code> otherwise.
		/// </summary>
		bool Exists { get; }
	}
}
