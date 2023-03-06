using UnityEngine;

namespace Assets.Scripts.WorldConducting
{
	public class WorldCoordinator : MonoBehaviour
	{
		[field: SerializeField]
		public static float WorldBoundX { get; private set; }
		[field: SerializeField]
		public static float WorldBoundY { get; private set; }

		// Start is called before the first frame update
		void Awake()
		{
			WorldBoundX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
			WorldBoundY = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
		}

		public static Vector2 PickRandomCoordinatesWithinWorld()
		{
			var worldMinX = WorldCoordinator.WorldBoundX * -1;
			var worldMinY = WorldCoordinator.WorldBoundY * -1;

			return new Vector2()
			{
				x = Random.Range(worldMinX, WorldCoordinator.WorldBoundX),
				y = Random.Range(worldMinY, WorldCoordinator.WorldBoundY)
			};
		}
		public static bool IsCoordinatesWithinWorldBounds(Vector2 coords)
		{
			return coords.x <= WorldBoundX &&
					coords.y <= WorldBoundY;
		}
	}
}
