using Assets.Scripts.Entities;

using UnityEngine;

using UnityRandom = UnityEngine.Random;

namespace Assets.Scripts.WorldConducting.Spawners
{
	[RequireComponent(typeof(AsteroidSpawner))]
	internal class DebriesSpawner : Spawner<Asteroid>
	{
		AsteroidSpawner asteroidSpawner;

		private void Awake()
		{
			asteroidSpawner = GetComponent<AsteroidSpawner>();
			asteroidSpawner.AsteroidDestroyed += (e) => Spawn(e.Coordinates);
		}
		void Spawn(Vector2 coordinates)
		{
			for (int i = 0; i < GetDebriesCount(); i++)
			{
				Instantiate(Spawnable, coordinates, Quaternion.identity);
			}
		}
		int GetDebriesCount()
		{
			return UnityRandom.Range(Config.MinDebriesPerAsteroid, Config.MaxDebriesPerAsteroid);
		}
	}
}
