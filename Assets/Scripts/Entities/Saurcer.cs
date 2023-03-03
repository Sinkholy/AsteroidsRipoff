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
		float minSpeed;
		[SerializeField]
		float maxSpeed;
		[SerializeField]
		string playerTag;
		[SerializeField]
		int maxHp;
		#endregion

		ChaserMovementBehaviour chaserMovement;
		Health health;

		public int ScoreReward { get; }
		public bool IsDestroyed { get; }

		public event Action<DestroyingEventArgs> Destroyed = delegate { };

		#region Unity callbacks
		void Awake()
		{
			chaserMovement = GetComponent<ChaserMovementBehaviour>();

			health = new Health(maxHp, maxHp);
		}
		void Start()
		{
			var target = GameObject.FindGameObjectWithTag(playerTag);

			chaserMovement.Target = target;
			chaserMovement.Speed = UnityEngine.Random.Range(minSpeed, maxSpeed);

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
