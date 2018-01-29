using UnityEngine;

namespace Utils
{
	[ExecuteInEditMode]
	public class HideInEditor : MonoBehaviour {

		// Use this for initialization
		void Start () {
#if UNITY_EDITOR
			if(!Application.isPlaying)
				gameObject.SetActive(false);
#endif
		}

	}
}
