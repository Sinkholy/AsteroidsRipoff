using System;

using Assets.Scripts.Entities;
using static Assets.Scripts.Entities.IEnemy;

namespace Assets.Scripts.WorldConducting.Spawners
{
	class AsteroidSpawner : Spawner<Asteroid>
	{
		internal event Action<DestroyingEventArgs> AsteroidDestroyed = delegate { };

		void OnSpawnedDestroyed(DestroyingEventArgs e)
		{
			aliveEntitiesCount--;
			AsteroidDestroyed(e);
		}

		private void Awake()
		{
			MaxAliveEntities = Config.MaxAliveAsteroids;
		}
		void Update()
		{
			if (AliveEntitiesCountQuotaMet)
			{
				var spawned = Spawn();
				spawned.transform.position = GetSafetySpawnCoordinates();
				spawned.Destroyed += OnSpawnedDestroyed;
				aliveEntitiesCount++;
			}
		}
	}
}
