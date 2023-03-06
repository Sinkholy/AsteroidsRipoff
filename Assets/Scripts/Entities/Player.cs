using System;

using Assets.Scripts.Armory;

using UnityEngine;

namespace Assets.Scripts.Entities
{
	/// <summary>
	/// Класс выполняет роль медиатора и фасада.
	/// </summary>
	[RequireComponent(typeof(PlayerArmoryController))]
	internal class Player : MonoBehaviour
	{
		#region Configurable
		[SerializeField]
		int maxHp;
		#endregion

		new Rigidbody2D rigidbody;
		PlayerArmoryController armoryController;
		Health health;
		Score score;

		internal event Action HealthDecreased = delegate { };

		#region Facade
		internal int HP => health.HP;
		internal int Score => score.Amount;
		internal float Velocity => rigidbody.velocity.magnitude;
		internal Vector2 WorldCoordinates => transform.position;
		internal float RotationAngle => Mathf.DeltaAngle(0.0f, rigidbody.rotation);

		internal int LaserCharges => armoryController.Lasergun.Charges;
		internal int LaserMaxCharges => armoryController.Lasergun.MaxChargesCount;
		internal float LaserChargeCooldown => armoryController.Lasergun.ChargeCooldown;
		internal float LaserCurrentChargeCooldown => armoryController.Lasergun.CurrentChargeCooldown;
		#endregion

		#region Unity callbacks
		void Awake()
		{
			armoryController = GetComponent<PlayerArmoryController>();
			rigidbody = GetComponent<Rigidbody2D>();

			health = new Health(maxHp, maxHp);
			score = new Score();
		}
		void Start()
		{
			armoryController.HitOccured += OnArmoryHitOccured;
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.TryGetComponent<IEnemy>(out _))
			{
				health.DecreaseHP(1);
				HealthDecreased();
			}
		}
		#endregion

		void OnArmoryHitOccured(IEnemy enemy)
		{
			score += enemy.ScoreReward;
		}
	}
}
