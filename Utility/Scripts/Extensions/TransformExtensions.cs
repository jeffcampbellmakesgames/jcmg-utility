/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using System.Collections.Generic;
using UnityEngine;

namespace JCMG.Utility
{
	/// <summary>
	/// Extension methods for <see cref="Transform"/>.
	/// </summary>
	public static class TransformExtensions
	{
		/// <summary>
		/// Finds or creates a component on <paramref name="root"/> and returns it.
		/// </summary>
		public static T FindOrCreate<T>(this GameObject root) where T : Component
		{
			var com = root.GetComponent<T>();
			if (ReferenceEquals(com, null))
			{
				com = root.AddComponent<T>();
			}

			return com;
		}

		/// <summary>
		/// Finds or creates a component on <paramref name="root"/> and returns it.
		/// </summary>
		public static T FindOrCreate<T>(this MonoBehaviour root) where T : Component
		{
			return root.gameObject.FindOrCreate<T>();
		}

		/// <summary>
		/// Sets the <paramref name="layer"/> on this <paramref name="transform"/> and all sub-transforms.
		/// </summary>
		public static void SetLayerRecursive(this Transform transform, int layer)
		{
			transform.gameObject.layer = layer;
			for (var i = 0; i < transform.childCount; ++i)
			{
				transform.GetChild(i).SetLayerRecursive(layer);
			}
		}

		/// <summary>
		/// Finds and returns a transform with <paramref name="name"/> on <paramref name="target"/> and any children if
		/// found, otherwise returns null.
		/// </summary>
		public static Transform FindRecursive(this Transform target, string name)
		{
			if (target.name == name)
			{
				return target;
			}

			for (var index = 0; index < target.childCount; ++index)
			{
				var transform = target.GetChild(index).FindRecursive(name);
				if (!ReferenceEquals(transform, null))
				{
					return transform;
				}
			}

			return null;
		}

		/// <summary>
		/// Finds and returns a transform with <paramref name="name"/> on children of <paramref name="transform"/>,
		/// otherwise returns null.
		/// </summary>
		public static Transform FindTransformChildRecursive(this Transform transform, string name)
		{
			for (var i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				if (child.name == name)
				{
					return child;
				}

				var recursiveSearch = FindTransformChildRecursive(child, name);
				if (!ReferenceEquals(recursiveSearch, null))
				{
					return recursiveSearch;
				}
			}

			return null;
		}

		/// <summary>
		/// Resets this transform to default values.
		/// </summary>
		public static void Reset(this Transform target)
		{
			target.localPosition = Vector3.zero;
			target.localRotation = Quaternion.identity;
			target.localScale = Vector3.one;
		}

		/// <summary>
		/// Enables or disables all children of <paramref name="target"/>.
		/// </summary>
		public static void SetActiveAllChildren(this Transform target, bool isActive)
		{
			for (var i = 0; i < target.childCount; i++)
			{
				target.GetChild(i).gameObject.SetActive(isActive);
			}
		}

		/// <summary>
		/// Destroys all children transforms on <paramref name="target"/>.
		/// </summary>
		public static void DestroyChildren(this Transform target)
		{
			while (target.childCount > 0)
			{
				var t = target.GetChild(0);
				t.SetParent(null);
				Object.DestroyImmediate(t.gameObject);
			}
		}

		/// <summary>
		/// Adds all children if any of <paramref name="transformForSearch"/> to <paramref name="list"/>.
		/// </summary>
		public static void GetChildrenRecursiveNonAlloc(this Transform transformForSearch, ref List<GameObject> list)
		{
			list.Clear();

			GetChildrenRecursiveNonAllocInternal(transformForSearch, ref list);
		}

		/// <summary>
		/// Adds all children if any of <paramref name="transformForSearch"/> to <paramref name="list"/>.
		/// </summary>
		private static void GetChildrenRecursiveNonAllocInternal(Transform transformForSearch, ref List<GameObject> list)
		{
			foreach (Transform trans in transformForSearch.transform)
			{
				list.Add(trans.gameObject);
				GetChildrenRecursiveNonAlloc(trans, ref list);
			}
		}

		/// <summary>
		/// Returns a scene-formatted path of <paramref name="current"/>
		/// </summary>
		public static string GetPath(this Transform current)
		{
			if (current.parent == null)
			{
				return current.name;
			}

			return string.Format("{0}/{1}", current.parent.GetPath(), current.name);
		}
	}
}
