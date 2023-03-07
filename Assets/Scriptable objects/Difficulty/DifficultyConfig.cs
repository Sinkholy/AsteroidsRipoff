using System;

using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Create difficulty config", order = 51)]
public class DifficultyConfig : ScriptableObject
{
	[field: SerializeField] internal string Name { get; private set; }
	[field: SerializeField] internal SpawnerConfig SpawnerConfiguration { get; private set; }
	[field: SerializeField] internal PlayerConfig PlayerConfiguration { get; private set; }
	[field: SerializeField] internal PlayerArmoryConfig PlayerArmoryConfiguration { get; private set; }
	[field: SerializeField] internal PlayerMovementConfig PlayerMovementConfiguration { get; private set; }
	[field: SerializeField] internal PlayerAbilitiesConfig PlayerAbilitiesConfiguration { get; private set; }
	[field: SerializeField] internal RewardsConfig Rewards { get; private set; }
	[field: SerializeField] internal AsteroidConfig AsteroidConfiguration { get; private set; }
	[field: SerializeField] internal SaurcerConfig SaurcerConfiguration { get; private set; }

	[Serializable]
	internal struct SpawnerConfig
	{
		[field: SerializeField, Header("General")]
		internal float SafetySpawnDistance { get; private set; }


		[field: SerializeField, Header("Asteroids")]
		internal int MaxAliveAsteroids { get; private set; }
		[field: SerializeField] internal int MinDebriesPerAsteroid { get; private set; }
		[field: SerializeField] internal int MaxDebriesPerAsteroid { get; private set; }


		[field: SerializeField, Header("Saurcers")]
		internal int MaxAliveSaurces { get; private set; }
		[field: SerializeField] internal float MinSaurceSpawnCooldown { get; private set; }
		[field: SerializeField] internal float MaxSaurceSpawnCooldown { get; private set; }
	}

	[Serializable]
	internal struct PlayerMovementConfig
	{
		[field: SerializeField] internal float MaxVelocity { get; private set; }
		[field: SerializeField] internal float AccelerationFactor { get; private set; }
		[field: SerializeField] internal float RotationFactor { get; private set; }
	}

	[Serializable]
	internal struct PlayerArmoryConfig
	{
		[field: SerializeField, Header("Turret")]
		internal float ProjectileVelocity { get; private set; }


		[field: SerializeField, Header("Laser")]
		internal int LaserMaxCharges { get; private set; }
		[field: SerializeField] internal float ChargeCooldown { get; private set; }
		[field: SerializeField] internal float ChargeDuration { get; private set; }
	}

	[Serializable]
	internal struct PlayerAbilitiesConfig
	{
		[field: SerializeField, Header("Boost")]
		internal int BoostCharges { get; private set; }
		[field: SerializeField] internal float ChargeCooldown { get; private set; }
		[field: SerializeField] internal float BoostForce { get; private set; }

		[field: SerializeField, Header("Slowmotion"), Range(0.01f, 0.99f)]
		internal float MinSlowmoEffect { get; private set; }
		[field: SerializeField] internal float SlowmoMaxCharge { get; private set; }
		[field: SerializeField] internal float SlowmoChargingRatePerSecond { get; private set; }
	}

	[Serializable]
	internal struct PlayerConfig
	{
		[field: SerializeField] internal int MaxHp { get; private set; }
		[field: SerializeField] internal float RespawnCooldown { get; private set; }
	}

	[Serializable]
	internal struct RewardsConfig
	{
		[field: SerializeField] internal int AsteroidReward { get; private set; }
		[field: SerializeField] internal int DebriesReward { get; private set; }
		[field: SerializeField] internal int SaurcerReward { get; private set; }
	}

	[Serializable]
	internal struct AsteroidConfig
	{
		[field: SerializeField] internal int MaxHp { get; private set; }
		[field: SerializeField] internal float MinSpeed { get; private set; }
		[field: SerializeField] internal float MaxSpeed { get; private set; }
		[field: SerializeField] internal float MinDirection { get; private set; }
		[field: SerializeField] internal float MaxDirection { get; private set; }
	}

	[Serializable]
	internal struct SaurcerConfig
	{

		[field: SerializeField] internal int MaxHp { get; private set; }
		[field: SerializeField] internal float MinSpeed { get; private set; }
		[field: SerializeField] internal float MaxSpeed { get; private set; }
	}
}
