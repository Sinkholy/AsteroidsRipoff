using System;

using Assets.Scripts.Entities;

using UnityEngine;

namespace Assets.Scripts.Armory
{
	internal class ProjectileLauncher : MonoBehaviour
	{
		#region Configuration
		[SerializeField]
		Projectile projectile;
		[SerializeField]
		float projectileSpeed;
		#endregion

		internal event Action<IEnemy> HitOccured = delegate { };

		internal void Fire()
		{
			var proj = Instantiate(projectile);
			proj.transform.SetPositionAndRotation(transform.position, transform.rotation);
			proj.Velocity = projectileSpeed;

			proj.EnemyHit += (e) => HitOccured(e);
		}
	}
}
