/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace JCMG.Utility
{
	/// <summary>
	/// Extension methods for <see cref="IList{T}"/>
	/// </summary>
	public static class IListExtensions
	{
		#region Math

		/// <summary>
		/// Returns the sum value of <paramref name="list"/>.
		/// </summary>
		public static int Aggregate<T>(this IList<int> list)
		{
			var result = 0;
			for (int i = 0; i < list.Count; i++)
			{
				result += list[i];
			}

			return result;
		}

		/// <summary>
		/// Returns the sum value of <paramref name="list"/>.
		/// </summary>
		public static float Aggregate<T>(this IList<float> list)
		{
			var result = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				result += list[i];
			}

			return result;
		}

		/// <summary>
		/// Returns the sum value of <paramref name="list"/>.
		/// </summary>
		public static double Aggregate<T>(this IList<double> list)
		{
			var result = 0d;
			for (int i = 0; i < list.Count; i++)
			{
				result += list[i];
			}

			return result;
		}

		/// <summary>
		/// Returns the total length of all animation clips in <paramref name="list"/>.
		/// </summary>
		public static float TotalClipLength(this IList<AnimationClip> list)
		{
			float length = 0;
			for (var i = 0; i < list.Count; ++i)
			{
				length += list[i].length;
			}

			return length;
		}

		#endregion

		#region IList Access

		/// <summary>
		/// Returns true if any elements in <paramref name="list"/> are present in <paramref name="other"/>.
		/// </summary>
		public static bool Overlaps<T>(this IList<T> list, IList<T> other)
		{
			for (var i = 0; i < list.Count; ++i)
			{
				if (other.Contains(list[i]))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Pops the first element from this <paramref name="list"/> and returns it.
		/// </summary>
		public static T PopFirst<T>(this IList<T> list)
		{
			Assert.IsFalse(list.Count == 0);

			var element = list[0];
			list.RemoveAt(0);
			return element;
		}

		/// <summary>
		/// Pops the first element from this <paramref name="list"/> and returns it.
		/// </summary>
		public static T PopLast<T>(this IList<T> list)
		{
			Assert.IsFalse(list.Count == 0);

			var index = list.Count - 1;
			var element = list[index];
			list.RemoveAt(index);
			return element;
		}

		/// <summary>
		/// Selects and returns a random element from <paramref name="list"/>.
		/// </summary>
		public static T SelectRandom<T>(this IList<T> list)
		{
			if (list.Count == 0)
			{
				return default(T);
			}

			var index = Random.Range(0, list.Count);
			return list[index];
		}

		#endregion

		#region IList Manipulation

		/// <summary>
		/// Adds the distinct contents of <paramref name="addList"/> to <paramref name="list"/> that are not present.
		/// </summary>
		public static void AddIfUnique<T>(this IList<T> list, IList<T> addList)
		{
			for (var i = 0; i < addList.Count; i++)
			{
				if (!list.Contains(addList[i]))
				{
					list.Add(addList[i]);
				}
			}
		}

		/// <summary>
		/// Adds <paramref name="item"/> to <paramref name="list"/> if not already present.
		/// </summary>
		public static void AddIfUnique<T>(this IList<T> list, T item)
		{
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}

		/// <summary>
		/// Shuffles the contents of <paramref name="list"/>
		/// </summary>
		public static void Shuffle<T>(this IList<T> list)
		{
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = Random.Range(0, n + 1);
				(list[k], list[n]) = (list[n], list[k]);
			}
		}

		#endregion
	}
}
