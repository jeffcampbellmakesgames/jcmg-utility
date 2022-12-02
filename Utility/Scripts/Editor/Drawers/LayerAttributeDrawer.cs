/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/

using UnityEditor;
using UnityEngine;

namespace JCMG.Utility.Editor
{
	[CustomPropertyDrawer(typeof(LayerAttribute))]
	public class LayerAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// One line of  oxygen free code.
			property.intValue = EditorGUI.LayerField(position, label, property.intValue);
		}
	}
}
