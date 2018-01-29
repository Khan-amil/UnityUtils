using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
	public static class PrefabBreakMenuItems
	{
		#region MENU_ITEMS

		/// <summary>
		/// Breaks the prefab connection of every selected object and delete it permanently.
		/// </summary>
		[MenuItem("GameObject/Break Prefab Instance Definitive %&b", false, 29)]
		[MenuItem("CONTEXT/Object/Break Prefab Instance Definitive", false, 301)]
		static void MenuBreakInstanceDefinitive ()
		{
			GameObject[] breakTargets = Selection.gameObjects;
			Selection.activeGameObject = null;
			BreakInstancesDefinitive(breakTargets);
			Selection.objects = breakTargets;
		}

		/// <summary>
		/// Breaks the prefab connection of every selected object, but leaves the "Select - Revert - Apply" buttons.
		/// </summary>
		[MenuItem("GameObject/Break Prefab Instance", false, 28)]
		[MenuItem("CONTEXT/Object/Break Prefab Instance", false, 300)]
		static void ContextBreakInstance (MenuCommand command)
		{
			GameObject[] breakTargets = Selection.gameObjects;
			Selection.activeGameObject = null;
			BreakInstances(breakTargets);
			Selection.objects = breakTargets;
		}

		/// <summary>
		/// Checks if any elements of the selection contain prefabs.
		/// </summary>
		[MenuItem("CONTEXT/Object/Break Prefab Instance", true)]
		[MenuItem("CONTEXT/Object/Break Prefab Instance Definitive", true)]
		[MenuItem("GameObject/Break Prefab Instance", true)]
		[MenuItem("GameObject/Break Prefab Instance Definitive %&b", true)]
		static bool PrefabCheck ()
		{
			GameObject[] goSelection = Selection.gameObjects;

			return (goSelection.Any(x => PrefabUtility.GetPrefabParent(x)));
		}

		#endregion

		#region LOGIC

		/// <summary>
		/// Breaks the prefab connections of a list of GameObject and delete them permanently.
		/// Records an undo.
		/// </summary>
		public static void BreakInstancesDefinitive (GameObject[] targets)
		{
			Undo.RegisterCompleteObjectUndo(targets, "Breaking multiple prefab instances definitively");

			Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy.prefab");
			foreach (var target in targets)
			{
				PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
				PrefabUtility.DisconnectPrefabInstance(target);
			}
			AssetDatabase.DeleteAsset("Assets/dummy.prefab");

			Undo.RecordObjects(targets, "Breaking multiple prefab instances definitively");
		}


		/// <summary>
		/// Breaks the prefab connection of a single GameObject and delete it permanently.
		/// Records an undo.
		/// </summary>
		public static void BreakInstanceDefinitive (GameObject target)
		{
			Undo.RegisterCompleteObjectUndo(target, "Breaking single prefab instance definitively");

			Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy.prefab");

			PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
			PrefabUtility.DisconnectPrefabInstance(target);

			AssetDatabase.DeleteAsset("Assets/dummy.prefab");
		}

		/// <summary>
		/// Breaks the prefab connections of a list of GameObject, but leaves the "Select - Revert - Apply" buttons.
		/// Records an undo.
		/// </summary>
		public static void BreakInstances (GameObject[] targets)
		{
			Undo.RegisterCompleteObjectUndo(targets, "Breaking multiple prefab instances");

			foreach (var target in targets)
			{
				PrefabUtility.DisconnectPrefabInstance(target);
			}
		}

		/// <summary>
		/// Breaks the prefab connection of a single GameObject, but leaves the "Select - Revert - Apply" buttons.
		/// Records an undo.
		/// </summary>
		public static void BreakInstance (GameObject target)
		{
			Undo.RegisterCompleteObjectUndo(target, "Breaking single prefab instance");
			PrefabUtility.DisconnectPrefabInstance(target);
		}

		#endregion
	}
}