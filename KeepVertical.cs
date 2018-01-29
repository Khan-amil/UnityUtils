using UnityEngine;

namespace Utils
{
	/// <summary>
	/// Force a gameobject to point toward a world direction
	/// </summary>
	public class KeepVertical : MonoBehaviour {

		public Vector3 _direction = Vector3.up;
		// Update is called once per frame
		void Update () {
			transform.up = _direction;
		}
	}
}
