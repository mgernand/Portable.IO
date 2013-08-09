namespace Portable.IO.Tests
{
	using System.IO;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class FileTests : TestBase
	{
		[Test]
		public void ShouldSupportSeekingOnReadOpenedFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.Read))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanSeek.Should().BeTrue();
			}
		}

		[Test]
		public void ShouldSupportSeekingOnWriteOpenedFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.Write))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanSeek.Should().BeTrue();
			}
		}

		[Test]
		public void ShouldSupportSeekingOnReadWriteOpenedFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using (Stream stream = file.Open(Portable.IO.FileAccess.ReadWrite))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanSeek.Should().BeTrue();
			}
		}

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
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeTrue();
				stream.CanWrite.Should().BeFalse();
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
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeFalse();
				stream.CanWrite.Should().BeTrue();
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
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeTrue();
				stream.CanWrite.Should().BeTrue();
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
			file.Exists.Should().BeTrue();

			// Act
			file.Delete();

			// Assert
			file.Exists.Should().BeFalse();
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