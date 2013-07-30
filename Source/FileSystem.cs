namespace Portable.IO
{
	using System;

	/// <summary>
	/// Static accessor for the current platform-specific implementation of <see cref="IFileSystem"/>.
	/// </summary>
	public static class FileSystem
	{
		private static readonly IFileSystem CurrentFileSystem = FileSystem.CreateFileSystem ();

		/// <summary>
		/// Gets the current platform-specific implementation of <see cref="IFileSystem"/>.
		/// </summary>
		public static IFileSystem Current 
		{
			get 
			{
				if (CurrentFileSystem == null) 
				{
					throw new NotImplementedException ("The platform-specific implementation of IFileSystem is missing.");
				}

				return CurrentFileSystem;
			}
		}

		private static IFileSystem CreateFileSystem ()
		{
#if NET
			return new NetFileSystem();
#elif WINDOWS_PHONE
			return new WindowsPhoneFileSystem();
#elif IOS
			return new IOSFileSystem();
#elif ANDROID
			return new AndroidFileSystem ();
#else
			return null;
#endif
		}
	}
}
