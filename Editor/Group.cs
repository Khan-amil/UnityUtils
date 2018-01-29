using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    public class Group
    {
        static int _groupCount = 1;
        static Dictionary<Transform, Transform> _previousChildren;

        [MenuItem("GameObject/Group Selected %g")]
        static void MakeGroup()
        {
            //cache selected objects in scene:
            Transform[] selectedObjects = Selection.transforms;

            //early exit if nothing is selected:
            if (selectedObjects.Length == 0)
            {
                return;
            }

            //parent construction and hierarchy structure decision:
            bool nestParent = false;
            Undo.IncrementCurrentGroup();
            var group = Undo.GetCurrentGroup();
            Transform
                parent = new GameObject("Group " + _groupCount++).transform; //naming convention mirrors Photoshop's
            Undo.RegisterCreatedObjectUndo(parent.gameObject, "Create Group");
            Transform coreParent = selectedObjects[0].parent;
            foreach (Transform item in selectedObjects)
            {
                if (item.parent != coreParent)
                {
                    nestParent = false;
                    break;
                }
                else
                {
                    nestParent = true;
                }
            }
            if (nestParent)
            {
                Undo.SetTransformParent(parent, coreParent, "setparent");
            }

            //place group's pivot on the active transform in the scene:
            parent.position = Selection.activeTransform.position;

            //set selected objects as children of the group:
            foreach (Transform item in selectedObjects)
            {
                Undo.SetTransformParent(item, parent, "setparent");
            }
            Undo.CollapseUndoOperations(group);
        }
    }
}