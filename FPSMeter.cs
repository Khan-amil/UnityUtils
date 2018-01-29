using UnityEngine;
using UnityEngine.UI;

// Display FPS on a Unity UGUI Text Panel
// To use: Drag onto a game object with Text component
namespace Utils
{
	public class FpsMeter : MonoBehaviour 
	{
		public Text _text;
		private const int TargetFps = 75;
		private const float UpdateInterval = 0.5f;
	
		private int _framesCount; 
		private float _framesTime;
		private float _fps;

		void Start()
		{ 
			// no text object set? see if our gameobject has one to use
			if (_text == null) 
			{ 
				_text = GetComponent<Text>(); 
			}
		}
	
		void Update()
		{	
			// monitoring frame counter and the total time
			_framesCount++;
			_framesTime += Time.unscaledDeltaTime; 
		
			// measuring interval ended, so calculate FPS and display on Text
			if (_framesTime > UpdateInterval)
			{
				if (_text != null)
				{
					_fps = _framesCount/_framesTime;
					_text.text = System.String.Format("{0:F2} FPS", _fps);
					_text.color = (_fps > (TargetFps-5) ? Color.green :
						(_fps > (TargetFps-30) ?  Color.yellow : 
							Color.red));
				}
				// reset for the next interval to measure
				_framesCount = 0;
				_framesTime = 0;
			}
		
		}
	}
}