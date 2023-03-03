using System;

using UnityEngine;

namespace Assets.Scripts.Damage
{
	public class DamageSource : MonoBehaviour
	{
		[SerializeField]
		public int damage;
		[SerializeField]
		public DamageType DamageType;

		public int Damage
			=> damage;

		public Action<DamageReceiver> DamageAccepted = delegate { }; // TODO: нейминги в кино водил
	}
}
