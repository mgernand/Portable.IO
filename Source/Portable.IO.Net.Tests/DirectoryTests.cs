namespace Portable.IO.Net.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class DirectoryTests : TestBase
	{
		[Test]
		public void ShouldCreateFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IFile file = directory.CreateFile("demo.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
			file.Delete();
		}

		[Test]
		public async void ShouldCreateFileAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IFile file = await directory.CreateFileAsync("demo.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
			file.Delete();
		}

		[Test]
		public void ShouldGetFile()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IFile file = directory.GetFile("file.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
		}

		[Test]
		public async void ShouldGetFileAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IFile file = await directory.GetFileAsync("file.txt");

			// Assert
			file.Should().NotBeNull();
			file.Exists.Should().BeTrue();
		}

		[Test]
		public void ShouldGetFiles()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IEnumerable<IFile> files = directory.GetFiles();

			// Assert
			files.Count().Should().Be(1);
		}

		[Test]
		public async void ShouldGetFilesAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IEnumerable<IFile> files = await directory.GetFilesAsync();

			// Assert
			files.Count().Should().Be(1);
		}

		[Test]
		public void ShouldCreateDirectory()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			string name = Guid.NewGuid().ToString();
			IDirectory newDirectory = directory.CreateDirectory(name);

			// Assert
			newDirectory.Should().NotBeNull();
			newDirectory.Exists.Should().BeTrue();
			newDirectory.Delete();
		}

		[Test]
		public async void ShouldCreateDirectoryAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			string name = Guid.NewGuid().ToString();
			IDirectory newDirectory = await directory.CreateDirectoryAsync(name);

			// Assert
			newDirectory.Should().NotBeNull();
			newDirectory.Exists.Should().BeTrue();
			newDirectory.Delete();
		}

		[Test]
		public void ShouldGetDirectory()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IDirectory subDirectory = directory.GetDirectory("Subfolder");

			// Assert
			subDirectory.Should().NotBeNull();
			subDirectory.Exists.Should().BeTrue();
		}

		[Test]
		public async void ShouldGetDirectoryAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IDirectory subDirectory = await directory.GetDirectoryAsync("Subfolder");

			// Assert
			subDirectory.Should().NotBeNull();
			subDirectory.Exists.Should().BeTrue();
		}

		[Test]
		public void ShouldGetDirectories()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IEnumerable<IDirectory> directories = directory.GetDirectories();

			// Assert
			directories.Count().Should().Be(1);
		}

		[Test]
		public async void ShouldGetDirectoriesAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");

			// Act
			IEnumerable<IDirectory> directories = await directory.GetDirectoriesAsync();

			// Assert
			directories.Count().Should().Be(1);
		}

		[Test]
		public void ShouldDeleteDirectory()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");
			IDirectory temp = directory.CreateDirectory("Temp");
			temp.Exists.Should().BeTrue();

			// Act
			temp.Delete();

			// Assert
			temp.Exists.Should().BeFalse();
		}

		[Test]
		public async void ShouldDeleteDirectoryAsync()
		{
			// Arrange
			IFileSystem fileSystem = FileSystem.Current;
			IDirectory directory = fileSystem.GetDirectory("Files");
			IDirectory temp = directory.CreateDirectory("Temp");
			temp.Exists.Should().BeTrue();

			// Act
			await temp.DeleteAsync();

			// Assert
			temp.Exists.Should().BeFalse();
		}
	}
}