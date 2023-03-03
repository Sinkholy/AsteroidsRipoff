using System;

namespace Assets.Scripts
{
	public class Health
	{
		int healthPoints;
		int maxHealthPoints;

		public event Action RanOutOfHP = delegate { };

		public Health(int initialHp, int maxHp)
		{
			healthPoints = initialHp;
			maxHealthPoints = maxHp;
		}

		public int HP => healthPoints;
		public int MaxHP => maxHealthPoints;
		public void DecreaseHP(int amount)
		{
			healthPoints -= amount;
			if (healthPoints <= 0)
			{
				RanOutOfHP();
			}
		}
		public void IncreaseHP(int amount)
		{
			healthPoints = Math.Clamp(healthPoints + amount, 0, maxHealthPoints);
		}
	}
}
