using UnityEngine;

namespace Assets.Scripts.Movement
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class KineticBodyMovementController : MonoBehaviour
	{
		Rigidbody2D body;

		#region Unity callbacks
		protected virtual void Awake()
		{
			body = GetComponent<Rigidbody2D>();
		}
		#endregion

		public void SetRotation(float angle)
		{
			body.MoveRotation(angle);
		}
		public void SetVelocity(float velocity)
		{
			body.velocity = transform.up * velocity;
		}
		public void MoveTowards(Vector2 coordinates)
		{
			var targetCoordinates = Vector2.MoveTowards(body.position, coordinates, body.velocity.magnitude * Time.deltaTime);
			body.MovePosition(targetCoordinates);
		}
	}
}
