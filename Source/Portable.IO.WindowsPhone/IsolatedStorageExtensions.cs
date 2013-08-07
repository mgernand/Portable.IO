namespace Portable.IO
{
	using System.IO;
	using System.IO.IsolatedStorage;

	/// <summary>
	/// See. http://metronuggets.com/2012/01/19/deleting-all-content-from-an-isolatedstorage-folder/
	/// </summary>
	internal static class IsolatedStorageExtensions
	{
		/// <summary>
		/// Deletes the folder.
		/// </summary>
		/// The isolated storage folder.
		/// The path to delete.
		public static void DeleteDirectoryEx(this IsolatedStorageFile root, string path)
		{
			if(!root.DirectoryExists(path))
			{
				return;
			}

			// Get the subfolders that reside under path
			string[] folders = root.GetDirectoryNames(Path.Combine(path, "*"));

			// Iterate through the subfolders and check for further subfolders           
			foreach (string folder in folders)
			{
				string folderName = path + "/" + folder;
				root.DeleteDirectory(folderName);
			}

			// Delete all files at the root level in that folder.
			foreach (string file in root.GetFileNames(Path.Combine(path, "*")))
			{
				root.DeleteFile(Path.Combine(path, file));
			}

			// Finally delete the path
			root.DeleteDirectory(path);
		}
	}
}