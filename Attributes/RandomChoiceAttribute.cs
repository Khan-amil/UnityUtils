using UnityEngine;

namespace Utils
{
	public class RandomChoiceAttribute : PropertyAttribute
	{

		public string _a;
		public string _b;

		public RandomChoiceAttribute()
		{
			_a = "Choice 1";
			_b = "Choice 2";
		}

		public RandomChoiceAttribute(string a, string b)
		{
			_a = a;
			_b = b;
		}
	}
}
