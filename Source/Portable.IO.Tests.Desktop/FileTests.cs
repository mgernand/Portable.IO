namespace Portable.IO.Tests
{
	using System.IO;
	using System.Runtime;
	using System.Threading.Tasks;
	using NUnit.Framework;

	[TestFixture]
	public class FileTests : TestBase
	{
		[Test]
		public void ShouldOpenFileRead()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.Read))
			{
				// Assert
				Assert.IsNotNull(stream);
				Assert.IsTrue(stream.CanRead);
				Assert.IsFalse(stream.CanWrite);
			}
		}

		[Test]
		public void ShouldOpenFileWrite()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.Write))
			{
				// Assert
				Assert.IsNotNull(stream);
				Assert.IsFalse(stream.CanRead);
				Assert.IsTrue(stream.CanWrite);
			}	
		}

		[Test]
		public void ShouldOpenFileReadWrite()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.ReadWrite))
			{
				// Assert
				Assert.IsNotNull(stream);
				Assert.IsTrue(stream.CanRead);
				Assert.IsTrue(stream.CanWrite);
			}
		}

		//[Test]
		//public async void ShouldOpenFileReadAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;
		//	IFile file = fileSystem.GetFile("Files/file.txt");

		//	// Act
		//	using (Stream stream = await file.OpenAsync(Portable.IO.FileAccess.Read))
		//	{
		//		// Assert
		//		Assert.IsNotNull(stream);
		//		Assert.IsTrue(stream.CanRead);
		//		Assert.IsFalse(stream.CanWrite);
		//	}
		//}

		//[Test]
		//public async void ShouldOpenFileWriteAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;
		//	IFile file = fileSystem.GetFile("Files/file.txt");

		//	// Act
		//	using (Stream stream = await file.OpenAsync(Portable.IO.FileAccess.Write))
		//	{
		//		// Assert
		//		Assert.IsNotNull(stream);
		//		Assert.IsFalse(stream.CanRead);
		//		Assert.IsTrue(stream.CanWrite);
		//	}
		//}

		//[Test]
		//public async void ShouldOpenFileReadWriteAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;
		//	IFile file = fileSystem.GetFile("Files/file.txt");

		//	// Act
		//	using (Stream stream = await file.OpenAsync(Portable.IO.FileAccess.ReadWrite))
		//	{
		//		// Assert
		//		Assert.IsNotNull(stream);
		//		Assert.IsTrue(stream.CanRead);
		//		Assert.IsTrue(stream.CanWrite);
		//	}
		//}

		[Test]
		public void ShouldDeleteFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/demo.txt");
			file.Open(Portable.IO.FileAccess.Write).Dispose();
			Assert.IsTrue(file.Exists);

			// Act
			file.Delete();

			// Assert
			Assert.IsFalse(file.Exists);
		}

		//[Test]
		//public async void ShouldDeleteFileAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;
		//	IFile file = fileSystem.GetFile("Files/demo.txt");
		//	file.Open(Portable.IO.FileAccess.Write).Dispose();
		//	Assert.IsTrue(file.Exists);

		//	// Act
		//	await file.DeleteAsync();

		//	// Assert
		//	Assert.IsFalse(file.Exists);
		//}
	}
}