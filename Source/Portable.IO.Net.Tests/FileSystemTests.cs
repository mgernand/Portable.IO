namespace Portable.IO.Net.Tests
{
	using FluentAssertions;
	using NUnit.Framework;

	[TestFixture]
	public class FileSystemTests
	{
		[Test]
		public void ShouldCreateFileSystem()
		{
			// Arrange
			PortableIO.Configure(typeof(NetFileSystemFactory));

			// Act
			IFileSystem fileSystem = FileSystem.Current;

			// Assert
			(fileSystem is NetFileSystem).Should().BeTrue();
		}
	}
}