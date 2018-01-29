using UnityEditor;
using UnityEngine;

namespace Utils.Editor.Drawers
{
	[CustomPropertyDrawer(typeof(SliderAttribute))]
	public class SliderDrawer : PropertyDrawer
	{

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			SliderAttribute assert = attribute as SliderAttribute;
			if (assert != null)
			{
				label.tooltip = "Min, Max : " + assert._min.ToString() + ", " + assert._max.ToString();
				if (property.propertyType == SerializedPropertyType.Float)
				{
					property.floatValue = EditorGUI.Slider(position, label, property.floatValue, assert._min, assert._max);
				}
				else if (property.propertyType == SerializedPropertyType.Integer)
					property.intValue = (int) EditorGUI.Slider(position, label, property.intValue, assert._min, assert._max);
				else
					EditorGUI.LabelField(position, label.text, "Use Slider with float or int.");
			}
		}
	}
}

