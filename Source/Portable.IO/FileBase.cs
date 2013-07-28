namespace Portable.IO
{
	internal abstract class FileBase : IFile
	{
		public abstract string Name { get; protected set; }
		public abstract string Path { get; protected set; }
		public abstract bool Exists { get; }
	}
}