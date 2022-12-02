/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for <see cref="string"/>.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Converts a string <paramref name="s"/> in snake case to title case.
		/// </summary>
		public static string SnakeToTitleCase(string s)
		{
			if (s == null)
			{
				return null;
			}

			var capitalizeNext = true;
			var length = s.Length;
			var chars = new char[length];

			for (var i = 0; i < length; ++i)
			{
				var c = s[i];
				if (c == '_')
				{
					chars[i] = ' ';
				}
				else
				{
					chars[i] = capitalizeNext ? char.ToUpper(c) : c;
				}

				capitalizeNext = chars[i] == ' ';
			}

			return new string(chars);
		}

		/// <summary>
		/// Returns true if this string is null or empty, otherwise false.
		/// </summary>
		public static bool IsNullOrEmpty(this string s)
		{
			return string.IsNullOrEmpty(s);
		}

		/// <summary>
		/// Returns a string with all windows "/" path characters replaced with macOS "\" chars.
		/// </summary>
		public static string ReplaceWindowsPathCharsWithMacOS(this string str)
		{
			return str.Replace("/", "\\");
		}

		/// <summary>
		/// Returns a string with all windows "/" path characters replaced with macOS "\" chars.
		/// </summary>
		public static string ReplaceMacOSPathCharsWithWindows(this string str)
		{
			return str.Replace("\\", "/");
		}
	}
}
