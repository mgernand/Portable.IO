namespace Portable.IO.Tests
{
	using NUnit.Framework;

	public abstract class TestBase
	{
		protected IFileSystem FileSystem { get; private set; }

		[SetUp]
		public void SetUp()
		{
			//IFileSystem fileSystem = FileSystem.Current;

			//IDirectory root = fileSystem.GetDirectory("");
			//IDirectory files = root.CreateDirectory("Files");
			//IFile file = files.CreateFile("file.txt");
			//IDirectory subfolder = files.CreateDirectory("Subfolder");
			//subfolder.CreateFile("file.txt");
		}

		[TearDown]
		public void TearDown()
		{
			//IFileSystem fileSystem = FileSystem.Current;

			//IDirectory directory = fileSystem.GetDirectory("Files");
			//directory.Delete();
		}
	}
}