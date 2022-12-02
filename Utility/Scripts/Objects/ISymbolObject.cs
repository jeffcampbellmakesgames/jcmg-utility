using System;

namespace JCMG.Utility
{
	/// <summary>
	/// Represents an object that can be identified by a <see cref="ISymbolObject.Symbol"/>.
	/// </summary>
	public interface ISymbolObject<T> : ISymbolObject,
	                                    IEquatable<T>
	{
	}

	/// <summary>
	/// Represents an object that can be identified by a <see cref="Symbol"/>.
	/// </summary>
	public interface ISymbolObject
	{
		/// <summary>
		/// The human-readable identifier for this object.
		/// </summary>
		string Symbol { get; }
	}
}
