using UnityEngine;

namespace Utils
{
	public class CollisionDebugger : MonoBehaviour
	{
		[Header("Collision")]
		public bool _collisionEnter = true;
		public bool _collisionStay = true;
		public bool _collisionExit = true;
		[Header("Collision 2D")]
		public bool _collisionEnter2D = true;
		public bool _collisionStay2D = true;
		public bool _collisionExit2D = true;
		[Header("Trigger")]
		public bool _triggerEnter = true;
		public bool _triggerStay = true;
		public bool _triggerExit = true;
		[Header("Trigger 2D")]
		public bool _triggerEnter2D = true;
		public bool _triggerStay2D = true;
		public bool _triggerExit2D = true;

		[Header("Other")]
		public bool _particle = true;
		public bool _characterController = true;

		public void OnCollisionEnter (Collision collision)
		{
			if (_collisionEnter)
			{
				Debug.Log(collision.gameObject.name + " enters collision with " + name + " at : " + collision.contacts[0].point, collision.gameObject);
			}
		}

		public void OnCollisionStay (Collision collision)
		{
			if (_collisionStay)
			{
				Debug.Log(collision.gameObject.name + " still collides with " + name + " at : " + collision.contacts[0].point, collision.gameObject);
			}
		}

		public void OnCollisionExit (Collision collision)
		{
			if (_collisionExit)
			{
				Debug.Log(collision.gameObject.name + " exits collision with " + name + " at : " + collision.contacts[0].point, collision.gameObject);
			}
		}


		public void OnTriggerEnter (Collider other)
		{
			if (_triggerEnter)
			{
				Debug.Log(other.gameObject.name + " triggers with " + name, other.gameObject);
			}
		}

		public void OnTriggerStay (Collider other)
		{
			if (_triggerStay)
			{
				Debug.Log(other.gameObject.name + " still triggers with " + name, other.gameObject);
			}
		}

		public void OnTriggerExit (Collider other)
		{
			if (_triggerExit)
			{
				Debug.Log(other.gameObject.name + " exit trigger with " + name, other.gameObject);
			}
		}

		public void OnParticleCollision (GameObject other)
		{
			if (_particle)
			{
				Debug.Log(other.gameObject.name + " is a particle colliding with " + name, other.gameObject);
			}
		}

		public void OnControllerColliderHit (ControllerColliderHit hit)
		{
			if (_characterController)
			{
				Debug.Log(hit.gameObject.name + " is a controller colliding with" + name+" at "+hit.point, hit.gameObject);
			}
		}


		#region 2d

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (_triggerEnter2D)
			{
				Debug.Log(collision.gameObject.name + " triggers with " + name + " (2D)", gameObject);
			}
		}

		public void OnTriggerStay2D(Collider2D collision)
		{
			if (_triggerStay2D)
			{
				Debug.Log(collision.gameObject.name + " still triggers with " + name + " (2D)", gameObject);
			}
		}

		public void OnTriggerExit2D(Collider2D collision)
		{
			if (_triggerExit2D)
			{
				Debug.Log(collision.gameObject.name + " exit trigger with " + name + " (2D)", gameObject);
			}
		}

		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (_collisionEnter2D)
			{
				Debug.Log(collision.gameObject.name + " enters collision with " + name + " at : " + collision.contacts[0].point + " (2D)", gameObject);
			}
		}

		public void OnCollisionStay2D(Collision2D collision)
		{
			if (_collisionStay2D)
			{
				Debug.Log(collision.gameObject.name + " still collides with " + name + " at : " + collision.contacts[0].point + " (2D)", gameObject);
			}
		}

		public void OnCollisionExit2D(Collision2D collision)
		{
			if (_collisionExit2D)
			{
				Debug.Log(collision.gameObject.name + " exits collision with " + name + " at : " + collision.contacts[0].point+ " (2D)", gameObject);
			}
		}

		#endregion

	}
}
