using UnityEditor;
using UnityEngine;

namespace Utils.Editor.Drawers
{
	[CustomPropertyDrawer(typeof(RandomChoiceAttribute))]
	public class RandomChoiceDrawer : PropertyDrawer
	{
		/// <summary>
		/// Override this method to specify how tall the GUI for this field is in pixels.
		/// </summary>
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUIUtility.singleLineHeight * 2;
		}

		/// <summary>
		/// Override this method to make your own GUI for the property.
		/// </summary>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			RandomChoiceAttribute rand = attribute as RandomChoiceAttribute;
			EditorGUI.BeginProperty(position, label, property);
			Rect test = position;
			position.width -= 84;
			position.height = EditorGUIUtility.singleLineHeight;
			var width5 = position.width / 5;
			var width35 = width5*3;

			Rect t = test;
			t.height = EditorGUIUtility.singleLineHeight;
			t.width = width5;
			EditorGUI.SelectableLabel(t, rand._a);
			Rect t2 = test;
			t2.height = EditorGUIUtility.singleLineHeight*2;
			t2.width = width35;
			t2.x += width5;
			EditorGUI.Slider(t2, property, 0, 1, GUIContent.none);
			Rect t3 = test;
			t3.height = EditorGUIUtility.singleLineHeight;
			t3.width = width5;
			t3.x += width5 + width35;
			EditorGUI.SelectableLabel(t3, rand._b);

			//second line
			test.y += EditorGUIUtility.singleLineHeight;
			Rect t4 = test;
			t4.height = EditorGUIUtility.singleLineHeight;
			t4.width = width5;
			EditorGUI.SelectableLabel(t4, (1 - property.floatValue).ToString("P"));
			Rect t6 = test;
			t6.height = EditorGUIUtility.singleLineHeight;
			t6.width = width35;
			t6.x += width5;
			EditorGUI.SelectableLabel(t6,property.displayName);
			Rect t5 = test;
			t5.height = EditorGUIUtility.singleLineHeight;
			t5.width = width5;
			t5.x += width5+ width35;
			EditorGUI.SelectableLabel(t5, property.floatValue.ToString("P"));

			EditorGUI.EndProperty();
		}

	}
}

