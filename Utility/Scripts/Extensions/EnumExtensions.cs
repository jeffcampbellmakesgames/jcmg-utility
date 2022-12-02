/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using System;
using System.Linq;
using System.Runtime.Serialization;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for Enum types and values.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Returns a <see cref="string" /> representation of <see cref="Enum" /> type <typeparamref name="T" />.
		/// </summary>
		public static string ToEnumString<T>(this T type)
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Cannot convert non-enum Type to string.");
			}

			var enumType = typeof(T);
			var name = Enum.GetName(enumType, type);
			var fieldInfo = enumType.GetField(name);
			var enumMemberAttributes = (EnumMemberAttribute[])fieldInfo.GetCustomAttributes(
				typeof(EnumMemberAttribute),
				true);

			return enumMemberAttributes.Length > 0
				? enumMemberAttributes[0].Value
				: name;
		}

		/// <summary>
		/// Attempts to convert to <see cref="Enum" /> type <typeparamref name="T" /> a <see cref="string" />
		/// representation of.
		/// </summary>
		public static T ToEnum<T>(this string str)
		{
			var enumType = typeof(T);
			for (var index = 0; index < Enum.GetNames(enumType).Length; index++)
			{
				var name = Enum.GetNames(enumType)[index];
				var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name)
						.GetCustomAttributes(typeof(EnumMemberAttribute), true))
					.Single();

				if (enumMemberAttribute.Value == str)
				{
					return (T)Enum.Parse(enumType, name);
				}
			}

			throw new ArgumentException($"{str} has no convertible equivalent for Enum of type [{enumType}].");
		}
	}
}
