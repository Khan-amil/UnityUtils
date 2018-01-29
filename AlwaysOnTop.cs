using UnityEngine;

namespace Utils
{
	[ExecuteInEditMode]
	public class AlwaysOnTop : MonoBehaviour
	{
		
#if UNITY_EDITOR
		private void Start ()
		{
			if(Application.isPlaying)
				Destroy(this);
			else
				transform.SetAsFirstSibling();
		}
#endif
	}
}