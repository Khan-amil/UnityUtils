using UnityEngine;

namespace Utils
{
	public class IntervalAttribute : PropertyAttribute
	{
		public float _min = 0;
		public float _max = 1;

		public IntervalAttribute(float min, float max)
		{
			_min = min;
			_max = max;
		}

		public IntervalAttribute()
		{
			_min = 0;
			_max = 1;
		}

	}
}
