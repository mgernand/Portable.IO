namespace Portable.IO
{
	internal abstract class DirectoryBase : IDirectory
	{
		public abstract string Name { get; protected set; }
		public abstract string Path { get; protected set; }
		public abstract bool Exists { get; }
	}
}