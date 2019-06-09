/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for <see cref="IEnumerable{T}"/>
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Returns a random element in the collection
		/// </summary>
		public static T Random<T>(this IEnumerable<T> list)
		{
			var count = list.Count();

			if (count == 0)
			{
				return default(T);
			}

			return list.ElementAt(UnityEngine.Random.Range(0, count));
		}

		/// <summary>
		/// Perform the <paramref name="action" /> on each item in <paramref name="collection"/>.
		/// </summary>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			foreach (var e in collection)
			{
				action.Invoke(e);
			}

			return collection;
		}
	}
}
