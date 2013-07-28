namespace Portable.IO
{
	public interface IDirectory
	{
		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the full path of the file.
		/// </summary>
		string Path { get; }
	}
}
