using UnityEngine;
using UnityRandom = UnityEngine.Random;

using Assets.Scripts.Entities;

namespace Assets.Scripts.WorldConducting.Spawners
{
	class SaurcerSpawner : Spawner<Saurcer>
	{
		float cooldown;

		internal float TimeTillNextSpawn => cooldown;

		float GetNextCooldown()
		{
			return UnityRandom.Range(Config.MinSaurceSpawnCooldown, Config.MaxSaurceSpawnCooldown);
		}

		private void Awake()
		{
			cooldown = GetNextCooldown();
			MaxAliveEntities = Config.MaxAliveSaurces;
		}
		void Update()
		{
			if (AliveEntitiesCountQuotaMet)
			{
				cooldown -= Time.deltaTime;
				if (cooldown <= 0.0f)
				{
					var spawned = Spawn();
					spawned.transform.position = GetSafetySpawnCoordinates();
					spawned.Destroyed += (e) => OnSpawnedDestroyed(); 
					cooldown = GetNextCooldown();
					aliveEntitiesCount++;
				}
			}
		}
		void OnSpawnedDestroyed()
		{
			aliveEntitiesCount--;
		}
	}
}
