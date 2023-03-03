using System;
using System.Collections.Generic;

using Assets.Scripts.Entities;

using UnityEngine;

namespace Assets.Scripts.Armory
{
	public class Lasergun : MonoBehaviour
	{
		float ro_beamLength; // ro_ есть симулякр read-only.

		#region Configuration
		[SerializeField]
		int maxCharges;
		[SerializeField]
		float chargeCooldown;
		[SerializeField]
		float chargeDuration;
		#endregion

		int charges;
		float currentDuration;
		float currentCooldown;

		LaserState state;

		LineRenderer lineRenderer;
		Collider2D _collider;

		internal event Action<IEnemy> HitOccured = delegate { };

		internal bool ReadyToFire => state != LaserState.Firing && charges > 0;
		internal int Charges => charges;
		internal float Cooldown => currentCooldown;

		internal void Fire()
		{
			if (ReadyToFire)
			{
				state = LaserState.Firing;
				charges--;
				currentDuration = 0.0f;
				currentCooldown = chargeCooldown;
			}
		}

		#region Unity callbacks
		void Awake()
		{
			lineRenderer = gameObject.GetComponent<LineRenderer>();
			if (!TryGetComponent(out _collider))
			{
				GenerateCollider();
			}

			void GenerateCollider()
			{
				_collider = gameObject.AddComponent<EdgeCollider2D>();
				var a = lineRenderer.GetPosition(0) + (transform.right * lineRenderer.startWidth);
				var b = lineRenderer.GetPosition(0) + ((transform.right * -1) * lineRenderer.startWidth);
				var c = lineRenderer.GetPosition(1) + (transform.right * lineRenderer.startWidth);
				var d = lineRenderer.GetPosition(1) + ((transform.right * -1) * lineRenderer.startWidth);
				(_collider as EdgeCollider2D).SetPoints(new List<Vector2> { a, b, d, c, a });
				_collider.isTrigger = true;
			}
		}
		void Start()
		{
			ro_beamLength = Vector3.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));
			charges = maxCharges;
		}
		void Update()
		{
			switch (state)
			{
				case LaserState.Charging:
					Charge(); break;
				case LaserState.Firing:
					Fire(); break;
			}

			lineRenderer.enabled = state == LaserState.Firing;
			_collider.enabled = state == LaserState.Firing;



			void Charge()
			{
				if (charges < maxCharges)
				{
					currentCooldown -= Time.deltaTime;
					if (currentCooldown <= 0.0f)
					{
						charges++;
						currentCooldown = chargeCooldown;
					}
				}
			}
			void Fire()
			{
				currentDuration += Time.deltaTime;
				if (currentDuration >= chargeDuration)
				{
					state = LaserState.Charging;
				}

				lineRenderer.SetPosition(0, transform.position);
				lineRenderer.SetPosition(1, transform.position + transform.rotation * Vector3.up * ro_beamLength);
			}
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent<IEnemy>(out var enemy))
			{
				HitOccured(enemy);
			}
		}
		#endregion

		enum LaserState : byte
		{
			Charging,
			Firing
		}
	}
}
