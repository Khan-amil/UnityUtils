using UnityEngine;

namespace Utils
{
	/// <summary>
	/// Ensure a gameobject is only active on PC platform
	/// </summary>
	public class OnlyOnPC : MonoBehaviour
	{
		public bool _onlyDisable = true;
		// Use this for initialization
		void Awake ()
		{
#if (!UNITY_EDITOR && !UNITY_STANDALONE_WIN)
		if(_onlyDisable)
			gameObject.SetActive(false);
		else
			DestroyImmediate(gameObject);
#endif
		}
	
	}
}
