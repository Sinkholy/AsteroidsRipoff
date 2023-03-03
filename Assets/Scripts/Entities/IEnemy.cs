using System;

using UnityEngine;

namespace Assets.Scripts.Entities
{
	public interface IEnemy
	{
		public event Action<DestroyingEventArgs> Destroyed;
		public int ScoreReward { get; }
		public bool IsDestroyed { get; }

		public class DestroyingEventArgs : EventArgs
		{
			public Vector2 Coordinates { get; set; } // TODO: Здесь хочется init, но я не хочу разбираться с ошибкой в данный момент.
		}
	}
}
