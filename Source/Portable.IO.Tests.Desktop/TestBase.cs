namespace Portable.IO.Tests
{
	using System;
	using NUnit.Framework;

	public abstract class TestBase
	{
		[SetUp]
		public void SetUp()
		{
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory root = fileSystem.GetDirectory(".");
			IDirectory files = root.CreateDirectory("Files");
			IFile file1 = files.CreateFile("file.txt");
			IDirectory subfolder = files.CreateDirectory("Subfolder");
			IFile file2 = subfolder.CreateFile("file.txt");
		}

		[TearDown]
		public void TearDown()
		{
			try
			{
				IFileSystem fileSystem = FileSystem.Current;
				IDirectory directory = fileSystem.GetDirectory("Files");
				directory.Delete();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}