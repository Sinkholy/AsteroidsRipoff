using System;

using Assets.Scripts.Entities;
using Assets.Scripts.WorldConducting.Spawners;

using Unity.VisualScripting;

using UnityEngine;

using static Assets.Scripts.Entities.IEnemy;

using UnityRandom = UnityEngine.Random;

namespace Assets.Scripts.WorldConducting
{
	public class EnemySpawnManager : MonoBehaviour
	{
		int aliveAsteroids = 0;
		int aliveSaurces = 0;
		float saurceSpawnCooldown;

		[SerializeField]
		string playerTag;
		[SerializeField]
		DifficultyConfig difficulty;

		private void Awake()
		{
			saurceSpawnCooldown = UnityRandom.Range(difficulty.MinSaurceSpawnCooldown, difficulty.MaxSaurceSpawnCooldown);	
		}
		private void Update()
		{
			HandleAsteroidSpawn();
			HandleSaurcesSpawn();

			void HandleAsteroidSpawn()
			{
				if (aliveAsteroids < difficulty.MaxAliveAsteroids)
				{
					SpawnAsteroid();
					aliveAsteroids++;
				}
			}
			void HandleSaurcesSpawn()
			{
				if (aliveSaurces < difficulty.MaxAliveSaurces)
				{
					if (saurceSpawnCooldown <= 0)
					{
						SpawnSaurcer();
						saurceSpawnCooldown = UnityRandom.Range(difficulty.MinSaurceSpawnCooldown, difficulty.MaxSaurceSpawnCooldown);
						aliveSaurces++;
					}
					saurceSpawnCooldown -= Time.deltaTime;
				}
			}
		}
		void SpawnSaurcer()
		{
			var spawned = Instantiate(difficulty.SaurcePrefab, GetSafetySpawnCoordinates(), Quaternion.identity);
			spawned.GetComponent<IEnemy>().Destroyed += _ => OnSaurceDestroyed();
		}
		void OnSaurceDestroyed()
		{
			aliveSaurces--;
		}
		void SpawnAsteroid()
		{
			var spawned = Instantiate(difficulty.AsteroidPrefab, GetSafetySpawnCoordinates(), Quaternion.identity);
			spawned.GetComponent<IEnemy>().Destroyed += e => OnAsteroidDestroyed(e.Coordinates);
		}
		void OnAsteroidDestroyed(Vector2 coordinates)
		{
			aliveAsteroids--;
			SpawnDebris(coordinates.x, coordinates.y);
		}

		void SpawnDebris(float x, float y)
		{
			var debriesCount = UnityRandom.Range(difficulty.MinDebriesPerAsteroid, difficulty.MaxDebriesPerAsteroid);
			for (int i = 0; i < debriesCount; i++)
			{
				var spawned = Instantiate(difficulty.DebriesPrefab);
			}
		}

		Vector2 GetSafetySpawnCoordinates()
		{
			var coordinates = WorldCoordinator.PickRandomCoordinatesWithinWorld();
			var playerCoords = GameObject.FindGameObjectWithTag(playerTag).transform.position;

			while (Vector2.Distance(coordinates, playerCoords) <= difficulty.SafetySpawnDistance)
			{
				coordinates = WorldCoordinator.PickRandomCoordinatesWithinWorld();
				playerCoords = GameObject.FindGameObjectWithTag(playerTag).transform.position;
			}

			return coordinates;
		}
	}
}
