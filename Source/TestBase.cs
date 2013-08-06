namespace Portable.IO.Tests
{
	using NUnit.Framework;

	public abstract class TestBase
	{
		[SetUp]
		public void SetUp()
		{
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory root = fileSystem.GetDirectory(".");
			IDirectory files = root.CreateDirectory("Files");
			files.CreateFile("file.txt");
			IDirectory subfolder = files.CreateDirectory("Subfolder");
			subfolder.CreateFile("file.txt");
		}

		[TearDown]
		public void TearDown()
		{
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");
			directory.Delete();
		}
	}
}