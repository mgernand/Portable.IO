﻿namespace Portable.IO
{
	/// <summary>
	/// Facade for a file.
	/// </summary>
	public interface IFile
	{
		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the full path of the file.
		/// </summary>
		string Path { get; }
	}
}
