using System;

using Assets.Scripts.Movement;

using UnityEngine;

namespace Assets.Scripts.Entities
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(KineticBodyMovementController))]
	internal class Projectile : MonoBehaviour
	{
		KineticBodyMovementController movementController;

		#region Configuration
		[SerializeField]
		float lifetimeLimit;
		#endregion

		internal event Action<IEnemy> EnemyHit = delegate { };

		internal float Velocity { get; set; }

		#region Unity callbacks
		private void Awake()
		{
			movementController = GetComponent<KineticBodyMovementController>();
		}
		void FixedUpdate()
		{
			lifetimeLimit -= Time.deltaTime;
			if (lifetimeLimit <= 0.0F)
			{
				Destroy(gameObject);
			}

			movementController.SetVelocity(Velocity);
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.TryGetComponent<IEnemy>(out var enemy))
			{
				EnemyHit(enemy);
				Destroy(this.gameObject);
			}
		}
		#endregion
	}
}
