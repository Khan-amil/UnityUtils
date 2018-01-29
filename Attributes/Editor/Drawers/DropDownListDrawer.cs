using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
	[CustomPropertyDrawer(typeof(DropDownList<>),true)]
	[CustomPropertyDrawer(typeof(DropDownListMat))]
	[CustomPropertyDrawer(typeof(DropDownListMesh))]
	[CustomPropertyDrawer(typeof(DropDownListGo))]
	public class DropDownListDrawer : PropertyDrawer
	{

		/// <summary>
		/// Override this method to specify how tall the GUI for this field is in pixels.
		/// </summary>
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var list = property.FindPropertyRelative("_list");
			//var cur = property.FindPropertyRelative("_value");
			//1 line for dropdown
			var height = EditorGUIUtility.singleLineHeight;
			if (list.arraySize > 0)
			{
				height+= EditorGUIUtility.singleLineHeight;
			}
			if (list.isExpanded)
			{
				if (list.arraySize > 0)
				{
					//2 lines for tab name and size selector
					height += EditorGUIUtility.singleLineHeight*2;
				}
				//1 line per item
				height += EditorGUIUtility.singleLineHeight * (list.arraySize + 1);
			}
			return height+7;
		}

		/// <summary>
		/// Override this method to make your own GUI for the property.
		/// </summary>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			var list = property.FindPropertyRelative("_list");
			var cur = property.FindPropertyRelative("_value");
			Rect basePosition = position;

			position.width -= 84;
			position.height = EditorGUIUtility.singleLineHeight;
			Rect popupRect = basePosition;
			if (list.arraySize > 0)
			{
				if (cur.intValue <= -1)
					cur.intValue = 0;
				var names = new string[list.arraySize];
				for (int i = 0; i < list.arraySize; i++)
				{
					var child = list.GetArrayElementAtIndex(i);
					if (child.propertyType==SerializedPropertyType.ObjectReference)
					{
						if (child.objectReferenceValue!=null)
						{
							names[i] = child.objectReferenceValue.name;
						}
						else
						{
							names[i] = i + " - NullRef";
						}
					}
					else if (child.propertyType == SerializedPropertyType.Generic)
					{
						var mesh = child.FindPropertyRelative("_mesh");
						var mat = child.FindPropertyRelative("_material");
						if (mesh != null && mesh.objectReferenceValue != null)
						{
							names[i] = i + " - " + mesh.objectReferenceValue.name;
							if (mat != null && mat.objectReferenceValue != null)
							{
								names[i] = mesh.objectReferenceValue.name+" - "+mat.objectReferenceValue.name;
							}
						}
						else
						{
							names[i] = i + " - " + child.displayName;

						}
					}
					else
					{
						names[i] = i + " - Null"+ child.propertyType;
					}
				}
				popupRect.height= base.GetPropertyHeight(cur, label);
				cur.intValue = EditorGUI.Popup(EditorGUI.PrefixLabel(popupRect, label), cur.intValue, names);
				basePosition.y += EditorGUIUtility.singleLineHeight;
				position.y += EditorGUIUtility.singleLineHeight;
			}
			else
			{
				cur.intValue = -1;
			}

			list.isExpanded = EditorGUI.Foldout(position, list.isExpanded, new GUIContent(label.text + " candidates"),true);
	
			EditorGUI.indentLevel += 1;

			Rect sizePos = basePosition;
			if (list.isExpanded)
			{
				sizePos.height= EditorGUIUtility.singleLineHeight;
				sizePos.y += EditorGUIUtility.singleLineHeight;
				basePosition.y += EditorGUIUtility.singleLineHeight;
				list.arraySize = EditorGUI.IntField(sizePos, "Size", list.arraySize);
				Rect childPosition = basePosition;
				foreach (SerializedProperty childProp in list)
				{
					childPosition.height = base.GetPropertyHeight(childProp, label);
					childPosition.y += base.GetPropertyHeight(childProp, label) + 2;
					EditorGUI.PropertyField(childPosition, childProp);
				}
			}
			EditorGUI.indentLevel -= 1;
			EditorGUI.EndProperty();
		}


		public static T GetFieldByName<T>(string fieldName, BindingFlags bindingFlags, object obj)
		{
			FieldInfo fieldInfo = obj.GetType().GetField(fieldName, bindingFlags);

			if (fieldInfo == null)
				return default(T);

			return (T)fieldInfo.GetValue(obj);
		}
	}
}