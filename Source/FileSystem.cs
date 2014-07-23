namespace Portable.IO
{
	using System;

	/// <summary>
	/// Static accessor for the current platform-specific implementation of <see cref="IFileSystem"/>.
	/// </summary>
	public static class FileSystem
	{
		private static readonly IFileSystem currentFileSystem = FileSystem.CreateFileSystem();

		/// <summary>
		/// Gets the current platform-specific implementation of <see cref="IFileSystem"/>.
		/// </summary>
		public static IFileSystem Current 
		{
			get 
			{
				if (currentFileSystem == null) 
				{
					throw new NotImplementedException ("The platform-specific implementation of IFileSystem is missing.");
				}

				return currentFileSystem;
			}
		}

		private static IFileSystem CreateFileSystem()
		{
#if NET45
			return new DektopFileSystem();
#elif WINDOWS_PHONE
			return new WindowsPhoneFileSystem();
#elif ANDROID
			return new AndroidFileSystem();
#elif IOS
			return new IOSFileSystem();
#else
			return null;
#endif
		}
	}
}
