using UnityEditor;
using UnityEngine;

namespace JCMG.Utility.Editor
{
	/// <summary>
	/// Helper methods for <see cref="Object"/>
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Returns the Unity asset oath or scene path for this object.
		/// </summary>
		public static string GetObjectPath(this Object obj)
		{
			return AssetDatabase.GetAssetPath(obj) != string.Empty
				? AssetDatabase.GetAssetPath(obj)
				: obj as Component != null
					? ((Component)obj).transform.GetPath()
					: obj as GameObject != null
						? ((GameObject)obj).transform.GetPath()
						: string.Empty;
		}

		/// <summary>
		/// Returns true if this object is a project reference, otherwise false.
		/// </summary>
		public static bool IsProjectReference(this Object obj)
		{
			var assetPath = AssetDatabase.GetAssetPath(obj);

			return !string.IsNullOrEmpty(assetPath);
		}

		/// <summary>
		/// Returns true if this object is a scene reference, otherwise false.
		/// </summary>
		public static bool IsSceneReference(this Object obj)
		{
			return !IsProjectReference(obj);
		}
	}
}
