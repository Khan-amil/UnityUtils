using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
	[CustomPropertyDrawer(typeof(AssertSup))]
	public class AssertSupDrawer : PropertyDrawer {

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			AssertSup assert=attribute as AssertSup;
			if (assert != null)
			{
				label.tooltip = "Min value : " + assert._min.ToString();
				if (property.propertyType == SerializedPropertyType.Float)
				{
					property.floatValue = Mathf.Max(assert._min, EditorGUI.FloatField(position, label, property.floatValue));
				}
				else if (property.propertyType == SerializedPropertyType.Integer)
					property.intValue = Mathf.Max((int) assert._min, EditorGUI.IntField(position, label, property.intValue));
				else
					EditorGUI.LabelField(position, label.text, "Use AssertSup with float or int.");
			}
		}
	}
}
