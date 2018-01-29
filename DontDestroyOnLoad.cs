using UnityEngine;

namespace Utils
{
	/// <summary>
	/// Enable DontDestroyOnLoad on this GameObject
	/// </summary>
	public class DontDestroyOnLoad : MonoBehaviour {

		// Use this for initialization
		void Awake () 
		{
			DontDestroyOnLoad(gameObject);
		}

	}
}
