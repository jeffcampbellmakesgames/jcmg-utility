using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for <see cref="IKeyedObject"/>.
	/// </summary>
	public static class IKeyedObjectExtensions
	{
		/// <summary>
		/// Returns true if a <typeparamref name="TKeyedObject"/> can be found for <paramref name="key"/>, otherwise
		/// false. If true, <paramref name="keyedObject"/> will be initialized.
		/// </summary>
		public static bool TryGet<TKeyedObject, TKey>(
			this IReadOnlyList<TKeyedObject> keyedObjects,
			TKey key,
			out TKeyedObject keyedObject)
			where TKeyedObject : class, IKeyedObject<TKey>
		{
			keyedObject = null;

			for (var i = 0; i < keyedObjects.Count; i++)
			{
				if (!Equals(keyedObjects[i].Key, key))
				{
					continue;
				}

				keyedObject = keyedObjects[i];
				break;
			}

			return keyedObject != null;
		}

		/// <summary>
		/// Returns a <typeparamref name="TKeyedObject"/> for matching <paramref name="key"/>.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if a <typeparamref name="TKeyedObject"/> is not found
		/// for matching <paramref name="key"/>.</exception>
		public static TKeyedObject Get<TKeyedObject, TKey>(
			this IReadOnlyList<TKeyedObject> keyedObjects,
			TKey key)
			where TKeyedObject : class, IKeyedObject<TKey>
		{
			TKeyedObject keyedObject = null;

			for (var i = 0; i < keyedObjects.Count; i++)
			{
				if (!Equals(keyedObjects[i].Key, key))
				{
					continue;
				}

				keyedObject = keyedObjects[i];
				break;
			}

			Assert.IsNotNull(keyedObject);

			if (keyedObject == null)
			{
				throw new Exception($"No {typeof(TKeyedObject).Name} can be found for key value {key}");
			}

			return keyedObject;
		}
	}
}
