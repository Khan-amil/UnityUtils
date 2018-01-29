using UnityEngine;

namespace Utils
{
	public class CameraFacing : MonoBehaviour
	{
		[SerializeField]
		private bool    _invertAxis = false ;
		private Transform  _facingCameraTransform;

		void Start()
		{
			_facingCameraTransform = Camera.main.transform ;
		}

		void Update()
		{
			if (_invertAxis)
				{transform.forward = (_facingCameraTransform.position - transform.position).normalized;}
			else
				{transform.forward = (transform.position - _facingCameraTransform.position).normalized;}
		}
	}
}