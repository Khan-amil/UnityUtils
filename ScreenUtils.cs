using UnityEngine;

namespace Utils
{
	/// <summary>
	/// 	contains generic code to adapt the gui according to the screen resolution
	/// </summary>
	public class ScreenUtils
	{
		public static Vector2 _screenSize = new Vector2(960, 640);
	
		public static Rect GetAdaptatedPos(Rect pos)
		{
			return (
				new Rect(
					(pos.xMin / _screenSize.x) * Screen.width,
					(pos.yMin / _screenSize.y) * Screen.height,
					(pos.width / _screenSize.x) * Screen.width,
					(pos.height / _screenSize.y) * (Screen.height)
				)
			);
		}
	
		public static float  GetAdaptedNumberX(float number)
		{
			return ((number / _screenSize.x) * Screen.width);
		}

		public static float  GetAdaptedNumberY(float number)
		{
			return ((number / _screenSize.y) * Screen.height);
		}

		public static bool IsSmallScreen()
		{
			return (Screen.width < 500 && Screen.height < 500);
		}
	
	}
}
