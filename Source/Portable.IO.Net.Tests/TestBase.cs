namespace Portable.IO.Net.Tests
{
	using NUnit.Framework;

	public abstract class TestBase
	{
		[TestFixtureSetUp]
		public void FixtureSetUp()
		{
			IFileSystem fileSystem = FileSystem.Current;

			IDirectory root = fileSystem.GetDirectory("");
			IDirectory files = root.CreateDirectory("Files");
			IFile file = files.CreateFile("file.txt");
			IDirectory subfolder = files.CreateDirectory("Subfolder");
			subfolder.CreateFile("file.txt");
		}

		[TestFixtureTearDown]
		public void FixtureTearDown()
		{
			IFileSystem fileSystem = FileSystem.Current;

			IDirectory directory = fileSystem.GetDirectory("Files");
			directory.Delete();
		}
	}
}