using UnityEngine;

namespace Assets.Scripts.Movement
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class DynamicBodyMovementController : MonoBehaviour
	{
		Rigidbody2D body;

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			// TODO: Нужно ли проверять является тело динамическим или кинетическим?
		}

		public void Rotate(float angle)
		{
			var targetAngle = body.rotation + angle;
			body.MoveRotation(targetAngle);
		}
		public void Accelerate(float force, ForceMode2D mode, float maxVelocity = float.MaxValue)
		{
			body.AddForce(force * body.transform.up, mode);
			body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
		}
	}
}
