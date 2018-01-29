/* This wizard will replace a selection with an object or prefab.
 * Scene objects will be cloned (destroying their prefab links).
 * Original coding by 'yesfish', nabbed from Unity Forums
 * 'keep parent' added by Dave A (also removed 'rotation' option, using localRotation
 */

using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
	public class ReplaceSelection : ScriptableWizard
	{
		static GameObject _replacement = null;
		static bool _keep = false;

		public GameObject _replacementObject = null;
		public bool _keepOriginals = false;

		public bool _keepSize = false;

		public Vector3 _positionOffset = Vector3.zero;
		public Vector3 _rotationOffset = Vector3.zero;

		[MenuItem("GameObject/Replace Selection...", false, 0)]
		//[MenuItem("GameObject/SetLayers",false,0)] //=>context menu dans hierarchie
		static void CreateWizard()
		{
			ScriptableWizard.DisplayWizard(
				"Replace Selection", typeof(ReplaceSelection), "Replace");
		}

		public ReplaceSelection()
		{
			_replacementObject = _replacement;
			_keepOriginals = _keep;
		}

		void OnWizardUpdate()
		{
			_replacement = _replacementObject;
			_keep = _keepOriginals;
		}

		void OnWizardCreate()
		{
			if (_replacement == null)
			{
				return;
			}


			Transform[] transforms = Selection.GetTransforms(
				SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable | SelectionMode.ExcludePrefab);

			if (transforms!=null)
			{
				Undo.RecordObjects(transforms, "Replace Selection");
				foreach (Transform t in transforms)
				{
					GameObject g;
					PrefabType pref = PrefabUtility.GetPrefabType(_replacement);
					PrefabType prefReplace = PrefabUtility.GetPrefabType(t.gameObject);
					if (prefReplace == PrefabType.Prefab || prefReplace == PrefabType.ModelPrefab)
					{
						Debug.LogError("Trying to replace a prefab?");
						return;
					}
					if (pref == PrefabType.Prefab || pref == PrefabType.ModelPrefab)
					{
						g = (GameObject) PrefabUtility.InstantiatePrefab(_replacement);
					}
					else
					{
						g = (GameObject) Instantiate(_replacement);
					}
					g.transform.parent = t.parent;
					g.name = _replacement.name;
					g.transform.localPosition = t.localPosition + _positionOffset;
					if (_keepSize)
						g.transform.localScale = t.localScale;
					else
						g.transform.localScale = _replacement.transform.localScale;
					g.transform.localRotation = t.localRotation*Quaternion.Euler(_rotationOffset);
				}
			}

			if (!_keep)
			{
				foreach (GameObject g in Selection.gameObjects)
				{
					Undo.DestroyObjectImmediate(g);
				}
			}
		}
	}
}