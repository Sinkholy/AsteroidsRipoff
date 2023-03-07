using System;

using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.WorldConducting.Spawners
{
	abstract class Spawner<T> : MonoBehaviour
		where T : Component
	{
		#region Config
		[SerializeField]
		Transform avoidable; // TODO: имя поля определенно нужно изменить
		[SerializeField]
		T spawnable;
		#endregion

		protected int aliveEntitiesCount;

		internal event Action<T> Spawned = delegate { };

		protected bool AliveEntitiesCountQuotaMet => aliveEntitiesCount < MaxAliveEntities;
		protected T Spawnable => spawnable;
		protected DifficultyConfig.SpawnerConfig Config => GameManager.Difficulty.SpawnerConfiguration;
		internal int MaxAliveEntities { get; private protected set; }

		protected void EntitySpawned(T entity)
		{
			Spawned(entity);
		}
		protected Vector2 GetSafetySpawnCoordinates()
		{
			var coordinates = WorldCoordinator.PickRandomCoordinatesWithinWorld();

			while (CoordinatesIsNotSafe())
			{
				coordinates = WorldCoordinator.PickRandomCoordinatesWithinWorld();
			}

			return coordinates;



			bool CoordinatesIsNotSafe()
			{ 
				return Vector2.Distance(coordinates, avoidable.position) <= Config.SafetySpawnDistance;
			}
		}
		protected T Spawn()
		{
			return Instantiate(Spawnable);
		}
	}



	public interface IPoolable // TODO: заготовка для пулинга.
	{
		public event Action<IPoolable> Destroyed;

		public void OnReturnedToPool();
		public void OnPooled();
	}
}
