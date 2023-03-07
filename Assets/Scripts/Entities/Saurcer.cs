using System;

using Assets.Scripts.Movement.Behaviour;

using UnityEngine;

using static Assets.Scripts.Entities.IEnemy;

namespace Assets.Scripts.Entities
{
	[RequireComponent(typeof(ChaserMovementBehaviour))]
	[RequireComponent(typeof(Collider2D))]
	internal class Saurcer : MonoBehaviour, IEnemy
	{
		#region Configurable
		[SerializeField]
		string playerTag;
		DifficultyConfig.SaurcerConfig config => GameManager.Difficulty.SaurcerConfiguration;
		#endregion

		ChaserMovementBehaviour chaserMovement;
		Health health;

		public int ScoreReward => GameManager.Difficulty.Rewards.SaurcerReward;
		public bool IsDestroyed { get; }

		public event Action<DestroyingEventArgs> Destroyed = delegate { };

		#region Unity callbacks
		void Awake()
		{
			chaserMovement = GetComponent<ChaserMovementBehaviour>();

			health = new Health(config.MaxHp, config.MaxHp);
		}
		void Start()
		{
			var target = GameObject.FindGameObjectWithTag(playerTag);

			chaserMovement.Target = target;
			chaserMovement.Speed = UnityEngine.Random.Range(config.MinSpeed, config.MaxSpeed);

			health.RanOutOfHP += OnRanOutOfHP;
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
			Destroyed(null);
			Destroy(gameObject);
		}
	}

}
