using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Create difficulty config", order = 51)]
public class DifficultyConfig : ScriptableObject
{
	[SerializeField]
	int maxAliveAsteroids;
	[SerializeField]
	int maxAliveSaurces;
	[SerializeField]
	float safetySpawnDistance;
	[SerializeField]
	int minDebriesPerAsteroid;
	[SerializeField]
	int maxDebriesPerAsteroid;
	[SerializeField]
	float minSaurceSpawnCooldown;
	[SerializeField]
	float maxSaurceSpawnCooldown;

	internal int MaxAliveAsteroids => maxAliveAsteroids;
	internal int MaxAliveSaurces => maxAliveSaurces;
	internal float SafetySpawnDistance => safetySpawnDistance;
	internal int MinDebriesPerAsteroid => minDebriesPerAsteroid;
	internal int MaxDebriesPerAsteroid => maxDebriesPerAsteroid;
	internal float MinSaurceSpawnCooldown => minSaurceSpawnCooldown;
	internal float MaxSaurceSpawnCooldown => maxSaurceSpawnCooldown;
}
