namespace Portable.IO
{
	using System;

	[Flags]
	public enum FileAccess
	{
		Read = 1,
		Write = 2,
		ReadWrite = Read | Write,
	}
}