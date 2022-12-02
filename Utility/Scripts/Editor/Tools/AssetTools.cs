/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace JCMG.Utility.Editor
{
	/// <summary>
	/// Helper methods for project assets.
	/// </summary>
	public static class AssetTools
	{
		private const string AssetsFolderName = "Assets";

		/// <summary>
		/// Returns the asset folder relative to the asset at <paramref name="absoluteFilePath"/>.
		/// </summary>
		public static string GetAsseFolderRelativeFilePath(string absoluteFilePath)
		{
			var splitSaveName = absoluteFilePath.Split('/');
			var sb = new List<string>();

			var hasFoundAssetFolder = false;
			for (var i = 0; i < splitSaveName.Length; i++)
			{
				if (splitSaveName[i] == AssetsFolderName)
				{
					hasFoundAssetFolder = true;
				}

				if (hasFoundAssetFolder)
				{
					sb.Add(splitSaveName[i]);
				}
			}

			var relativeFilePath = "";
			foreach (var str in sb)
			{
				relativeFilePath = Path.Combine(relativeFilePath, str);
			}

			return relativeFilePath.Replace("\\", "/");
		}

		/// <summary>
		/// Returns a list of all scene paths in the project.
		/// </summary>
		public static List<string> GetAllScenePaths()
		{
			var assetPaths = AssetDatabase.FindAssets("t:scene");
			var scenePaths = new List<string>();

			for (var i = 0; i < assetPaths.Length; i++)
			{
				scenePaths.Add(AssetDatabase.GUIDToAssetPath(assetPaths[i]));
			}

			return scenePaths;
		}
	}
}
