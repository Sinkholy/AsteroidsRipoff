using System;

using Assets.Scripts.Movement.Behaviour;

using UnityEngine;

using static Assets.Scripts.Entities.IEnemy;

using UnityRandom = UnityEngine.Random;

namespace Assets.Scripts.Entities
{
	[RequireComponent(typeof(ConstantMovementBehaviour))]
	internal class Asteroid : MonoBehaviour, IEnemy
	{
		#region Configurable
		DifficultyConfig.AsteroidConfig config => GameManager.Difficulty.AsteroidConfiguration;
		#endregion

		ConstantMovementBehaviour movementController;
		Health health;

		public event Action<DestroyingEventArgs> Destroyed = delegate { };

		public int ScoreReward => GameManager.Difficulty.Rewards.AsteroidReward;
		public bool IsDestroyed { get; private set; }

		#region Unity callbacks
		void Awake()
		{
			movementController = GetComponent<ConstantMovementBehaviour>();
			health = new Health(config.MaxHp, config.MaxHp);
			health.RanOutOfHP += OnRanOutOfHP;
		}
		void Start()
		{
			movementController.TargetDirection = UnityRandom.Range(config.MinDirection, config.MaxDirection);
			movementController.TargetSpeed = UnityRandom.Range(config.MinSpeed, config.MaxSpeed);
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.TryGetComponent<IEnemy>(out _))
			{
				return;
			}
			health.DecreaseHP(1);
		}
		#endregion
		void OnRanOutOfHP()
		{
			var args = new DestroyingEventArgs()
			{
				Coordinates = new Vector2(transform.position.x, transform.position.y)
			};
			Destroyed(args);
			Destroy(this.gameObject);
		}
	}
}
