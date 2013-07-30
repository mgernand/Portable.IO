namespace Portable.IO.Tests.Net
{
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class FileSystemTests : TestBase
	{
		//[Test]
		//public void ShouldCreateFileSystem()
		//{
		//	// Arrange & Act
		//	IFileSystem fileSystem = FileSystem.Current;

		//	// Assert
		//	(fileSystem is NetFileSystem).Should().BeTrue();
		//}

		[Test]
		public void ShouldGetFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			IFile file = fileSystem.GetFile("Files/file.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
			file.Name.Should().Be("file.txt");
		}

		[Test]
		public async void ShouldGetFileAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			IFile file = await fileSystem.GetFileAsync("Files/file.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
			file.Name.Should().Be("file.txt");
		}

		[Test]
		public void ShouldGetDirectory()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Assert
			directory.Should().NotBeNull();
			directory.Exists.Should().BeTrue();
			directory.Name.Should().Be("Files");
		}

		[Test]
		public async void ShouldGetDirectoryAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			IDirectory directory = await fileSystem.GetDirectoryAsync("Files");

			// Assert
			directory.Should().NotBeNull();
			directory.Exists.Should().BeTrue();
			directory.Name.Should().Be("Files");
		}
	}
}