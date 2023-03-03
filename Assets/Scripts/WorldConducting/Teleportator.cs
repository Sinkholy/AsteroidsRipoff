using UnityEngine;

namespace Assets.Scripts.WorldConducting
{
	public class Teleportator : MonoBehaviour
	{
		void FixedUpdate()
		{
			var bodies = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);
			foreach (var body in bodies)
			{
				if (IsOutOfBoundX(body.position.x))
				{
					body.position = new Vector2(body.position.x * -1, body.position.y);
				}
				if (IsOutOfBoundY(body.position.y))
				{
					body.position = new Vector2(body.position.x, body.position.y * -1);
				}
			}
		}

		bool IsOutOfBoundX(float x)
		{
			return Mathf.Abs(x) >= WorldCoordinator.WorldBoundX;
		}
		bool IsOutOfBoundY(float y)
		{
			return Mathf.Abs(y) >= WorldCoordinator.WorldBoundY;
		}
	}
}

