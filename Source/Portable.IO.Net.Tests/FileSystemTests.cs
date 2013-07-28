namespace Portable.IO.Net.Tests
{
	using System.IO;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class FileSystemTests
	{
		[Test]
		public void ShouldCreateFileSystem()
		{
			// Arrange & Act
			IFileSystem fileSystem = FileSystem.Current;

			// Assert
			(fileSystem is NetFileSystem).Should().BeTrue();
		}

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

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void ShouldThrowOnFileAsDirectory()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			fileSystem.GetDirectory("Files/file.txt");
		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public async void ShouldThrowOnFileAsDirectoryAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			await fileSystem.GetDirectoryAsync("Files/file.txt");
		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void ShouldThrowOnDirectoryAsFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			fileSystem.GetFile("Files");
		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public async void ShouldThrowOnDirectoryAsFileAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;

			// Act
			await fileSystem.GetFileAsync("Files");
		}
	}
}