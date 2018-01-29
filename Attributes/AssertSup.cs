using UnityEngine;

namespace Utils
{
	/// <summary>
	/// Enforce that the value is >= than the value passed
	/// </summary>
	public class AssertSup : PropertyAttribute {

		public float _min = 0;

		/// <summary>
		/// Enforce that the value is >= than the value passed
		/// </summary>
		public AssertSup(float min)
		{
			_min = min;
		}
	}
}
