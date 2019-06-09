/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/
using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for the application.
	/// </summary>
	public static class AppTools
	{
		/// <summary>
		/// Attempts to quit the application.
		/// </summary>
		public static void Quit()
		{
			#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
			#else
			Application.Quit();
			#endif
		}
	}
}
