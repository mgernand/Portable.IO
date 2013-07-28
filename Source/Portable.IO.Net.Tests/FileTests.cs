namespace Portable.IO.Net.Tests
{
	using System.IO;
	using FluentAssertions;
	using NUnit.Framework;
	using FileAccess = Portable.IO.FileAccess;

	[TestFixture]
	public class FileTests
	{
		[Test]
		public void ShouldOpenFileRead()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using(Stream stream = file.Open(FileAccess.Read))
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
			using(Stream stream = file.Open(FileAccess.Write))
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
			using(Stream stream = file.Open(FileAccess.ReadWrite))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeTrue();
				stream.CanWrite.Should().BeTrue();	
			}
		}

		[Test]
		public async void ShouldOpenFileReadAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using(Stream stream = await file.OpenAsync(FileAccess.Read))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeTrue();
				stream.CanWrite.Should().BeFalse();
			}
		}

		[Test]
		public async void ShouldOpenFileWriteAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using(Stream stream = await file.OpenAsync(FileAccess.Write))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeFalse();
				stream.CanWrite.Should().BeTrue();	
			}
		}

		[Test]
		public async void ShouldOpenFileReadWriteAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Act
			using(Stream stream = await file.OpenAsync(FileAccess.ReadWrite))
			{
				// Assert
				stream.Should().NotBeNull();
				stream.CanRead.Should().BeTrue();
				stream.CanWrite.Should().BeTrue();	
			}
		}

		[Test]
		public void ShouldDeleteFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/demo.txt");
			file.Open(FileAccess.Write).Dispose();
			file.Exists.Should().BeTrue();

			// Act
			file.Delete();

			// Assert
			file.Exists.Should().BeFalse();
		}

		[Test]
		public async void ShouldDeleteFileAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IFile file = fileSystem.GetFile("Files/demo.txt");
			file.Open(FileAccess.Write).Dispose();
			file.Exists.Should().BeTrue();

			// Act
			await file.DeleteAsync();

			// Assert
			file.Exists.Should().BeFalse();
		}
	}
}