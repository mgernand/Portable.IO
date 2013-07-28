namespace Portable.IO
{
	internal abstract class FileSystemElementBase : IFileSystemElement
	{
		public string Name { get; protected set; }
		public string Path { get; protected set; }
		public abstract bool Exists { get; }
	}
}