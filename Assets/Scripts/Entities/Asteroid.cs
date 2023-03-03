using System;

using Assets.Scripts.Damage;
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
		[SerializeField]
		int maxHp;
		[SerializeField]
		float minSpeed;
		[SerializeField]
		float maxSpeed;
		[SerializeField]
		float minDirection;
		[SerializeField]
		float maxDirection;
		#endregion

		ConstantMovementBehaviour movementController;
		Health health;

		public event Action<DestroyingEventArgs> Destroyed = delegate { };

		[field: SerializeField]
		public int ScoreReward { get; private set; }
		public bool IsDestroyed { get; private set; }

		#region Unity callbacks
		void Awake()
		{
			movementController = GetComponent<ConstantMovementBehaviour>();
			health = new Health(maxHp, maxHp);
			health.RanOutOfHP += OnRanOutOfHP;
		}
		void Start()
		{
			movementController.TargetDirection = UnityRandom.Range(minDirection, maxDirection);
			movementController.TargetSpeed = UnityRandom.Range(minSpeed, maxSpeed);
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
