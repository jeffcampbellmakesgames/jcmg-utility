/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/
using System;
using System.Collections.Generic;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for the commandline.
	/// </summary>
	public static class CommandLineTools
	{
	    /// <summary>
	    /// Returns a dictionary of command line argument parameters to their value.
	    /// </summary>
		public static Dictionary<string, string> GetNamedCommandlineArguments(char delimiter)
		{
			var dict = new Dictionary<string, string>();
			var args = Environment.GetCommandLineArgs();
			for (var i = 0; i < args.Length; i++)
			{
				var splitArg = args[i].Split(delimiter);
				if (splitArg.Length <= 1 || dict.ContainsKey(splitArg[0]))
				{
					continue;
				}

				dict.Add(splitArg[0], splitArg[1]);
			}

			return dict;
		}
	}
}
