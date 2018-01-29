using UnityEngine;

namespace Utils
{
	public class SliderAttribute : PropertyAttribute {

		public float _min = 0;
		public float _max = 1;

		public SliderAttribute(float min, float max)
		{
			_min = min;
			_max = max;
		}
	}
}
