using System;

using Assets.Scripts.Entities;

using UnityEngine;

namespace Assets.Scripts.Damage
{
	[RequireComponent(typeof(Collider2D))]
	public class DamageReceiver : MonoBehaviour
	{
		public Action<DamageSource> DamageReceived = delegate { };

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent<DamageSource>(out var dmgSrc))
			{
				DamageReceived(dmgSrc);
			}
		}
	}
}