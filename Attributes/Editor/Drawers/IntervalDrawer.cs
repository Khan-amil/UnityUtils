using UnityEditor;
using UnityEngine;

namespace Utils.Editor.Drawers
{
	[CustomPropertyDrawer(typeof(IntervalAttribute))]
	public class IntervalDrawer : PropertyDrawer
	{
		/// <summary>
		/// Override this method to specify how tall the GUI for this field is in pixels.
		/// </summary>
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label)+ EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			IntervalAttribute assert = attribute as IntervalAttribute;
			if (assert != null)
			{
				label.tooltip = "Min, Max : " + assert._min.ToString() + ", " + assert._max.ToString();
				if (property.propertyType == SerializedPropertyType.Vector2)
				{
					EditorGUI.BeginProperty(position, label, property);
					Rect test = position;
					position.height = EditorGUIUtility.singleLineHeight;
					var value = property.vector2Value;
					EditorGUI.MinMaxSlider(label, position, ref value.x, ref value.y, assert._min, assert._max);
					Rect floatfield = position;
					var labelWidth = EditorGUIUtility.labelWidth - 30;
					floatfield.width = (floatfield.width - labelWidth) / 4;
					floatfield.x += labelWidth;
					floatfield.y += EditorGUIUtility.singleLineHeight;

					value.x = EditorGUI.FloatField(floatfield, value.x);
					floatfield.x += floatfield.width * 3;
					
					value.y = EditorGUI.FloatField(floatfield, value.y);
					value.x = Mathf.Clamp(value.x, assert._min, assert._max);
					value.y = Mathf.Clamp(value.y, assert._min, assert._max);
					if (value.x > value.y)
					{
						value.x = value.y;
					}
					property.vector2Value = value;
					EditorGUI.EndProperty();
				}
				else
					EditorGUI.LabelField(position, label.text, "Use Interval with Vector2");
			}
		}
	}
}