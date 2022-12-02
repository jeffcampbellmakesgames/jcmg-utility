using System;

namespace JCMG.Utility
{
	/// <summary>
	/// Represents an object that can be identified by a <see cref="Key"/>.
	/// </summary>
	public interface IKeyedObject<TKey>
	{
		/// <summary>
		/// The unique identifier for this object.
		/// </summary>
		TKey Key { get; }
	}

	/// <summary>
	/// Represents an object that can be identified by a <see cref="Key"/>.
	/// </summary>
	public interface IKeyedObject
	{
		/// <summary>
		/// The unique identifier for this object.
		/// </summary>
		string Key { get; }
	}
}
