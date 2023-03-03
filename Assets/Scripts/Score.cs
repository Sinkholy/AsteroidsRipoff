using System;

namespace Assets.Scripts
{
	public class Score
	{
		public int Amount { get; private set; }

		public void AddScore(int amount)
		{
			Amount += amount;
		}
		public void DecreaseScore(int amount)
		{
			Amount = Math.Clamp(Amount - amount, 0, int.MaxValue);
		}
		public void ResetScore()
		{
			Amount = 0;
		}

		public static Score operator +(Score score, int amount)
		{
			score.AddScore(amount);
			return score;
		}
	}
}
