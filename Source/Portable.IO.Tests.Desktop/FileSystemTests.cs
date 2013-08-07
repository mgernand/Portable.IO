namespace Portable.IO.Tests
{
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class FileSystemTests : TestBase
	{
		[Test]
		public void ShouldCreateFileSystem()
		{
			// Arrange & Act
			IFileSystem fileSystem = FileSystem.Current;

			// Assert
#if NET45
			Assert.IsTrue(fileSystem is NetFileSystem);
#elif WINDOWS_PHONE
			Assert.IsTrue(fileSystem is WindowsPhoneFileSystem);
#elif ANDROID
			Assert.IsTrue(fileSystem is AndroidFileSystem);
#elif IOS
			Assert.IsTrue(fileSystem is IOSFileSystem);
#endif
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

		//[Test]
		//public async void ShouldGetFileAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;

		//	// Act
		//	IFile file = await fileSystem.GetFileAsync("Files/file.txt");

		//	// Assert
		//	Assert.IsNotNull(file);
		//	Assert.IsTrue(file.Exists);
		//	Assert.AreEqual("file.txt", file.Name);
		//}

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

		//[Test]
		//public async void ShouldGetDirectoryAsync()
		//{
		//	// Arrange
		//	IFileSystem fileSystem = FileSystem.Current;

		//	// Act
		//	IDirectory directory = await fileSystem.GetDirectoryAsync("Files");

		//	// Assert
		//	Assert.IsNotNull(directory);
		//	Assert.IsTrue(directory.Exists);
		//	Assert.AreEqual("Files", directory.Name);
		//}
	}
}