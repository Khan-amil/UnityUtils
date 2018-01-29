using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
	/// <summary>
	/// Remove all "missing scripts" components
	/// </summary>
	public class SelectMissingScript
	{
		[MenuItem("Tools/RemoveMissing")]
		static public void SelectMissing ()
		{
			GameObject[] obj = Object.FindObjectsOfType<GameObject>();
			for (int i = 0; i < obj.Length; ++i)
			{
				Component[] comp = obj[i].GetComponents<Component>();
				var serializedObject = new SerializedObject(obj[i]);
				var prop = serializedObject.FindProperty("m_Component");
				int r = 0;

				while (r < prop.arraySize)
				{
					SerializedProperty prop2 = prop.GetArrayElementAtIndex(r);
					prop2.Next(true);
					prop2.Next(false);

					if (prop2.objectReferenceValue == null)
					{
						prop.DeleteArrayElementAtIndex(r);
					}
					else
					{
						r++;
					}
				}

				// Apply our changes to the game object
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}