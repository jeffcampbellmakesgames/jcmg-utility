using System.Collections.Generic;
using UnityEngine;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for <see cref="GameObject"/>.
	/// </summary>
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Finds and returns a <see cref="GameObject"/> with <paramref name="name"/> on <paramref name="gameObject"/> and
		/// any children if found, otherwise returns null.
		/// </summary>
		public static GameObject FindRecursive(this GameObject gameObject, string name)
		{
			var transform = gameObject.transform.FindRecursive(name);
			return transform.gameObject != null ? transform.gameObject : null;
		}

		/// <summary>
		/// Gets the entire bounds of anything rendered under this game object.
		/// </summary>
		public static Bounds GetBounds(this GameObject gameObjects)
		{
			var b = new Bounds(Vector3.zero, Vector3.zero);
			var first = true;
			foreach (var renderer in gameObjects.GetComponentsInChildren<Renderer>())
			{
				if (first)
				{
					b = renderer.bounds;
				}
				else
				{
					b.Encapsulate(renderer.bounds);
				}
				first = false;
			}

			return b;
		}

		/// <summary>
		/// Get the entire bounds of anything within a list of GameObjects.
		/// </summary>
		public static Bounds GetBounds(this IEnumerable<GameObject> gameObjects)
		{
			var b = new Bounds();
			var first = true;
			foreach (var gameObject in gameObjects)
			{
				if (first)
				{
					b = gameObject.GetBounds();
				}
				else
				{
					b.Encapsulate(gameObject.GetBounds());
				}

				first = false;
			}

			return b;
		}

		/// <summary>
		/// Adds all children if any of <paramref name="gameObjectToSearch"/> to <paramref name="list"/>.
		/// </summary>
		private static void GetChildrenRecursiveNonAlloc(this GameObject gameObjectToSearch, ref List<GameObject> list)
		{
			gameObjectToSearch.transform.GetChildrenRecursiveNonAlloc(ref list);
		}

		/// <summary>
		/// Sets the <paramref name="layer"/> on this <paramref name="transform"/> and all sub-transforms.
		/// </summary>
		public static void SetLayerRecursive(this GameObject gameObject, int layer)
		{
			gameObject.layer = layer;
			gameObject.transform.SetLayerRecursive(layer);
		}

		/// <summary>
		/// Returns true or false if <paramref name="targetObject"/> is in a scene or not.
		/// </summary>
		public static bool IsSceneObject(this GameObject targetObject)
		{
			return targetObject != null &&
				   !string.IsNullOrEmpty(targetObject.scene.name) ||
			       targetObject.scene.rootCount != 0;
		}
	}
}
