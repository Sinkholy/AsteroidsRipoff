using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
	[RequireComponent(typeof(DynamicBodyMovementController))]
	internal class BoostAbility : MonoBehaviour
	{
		DynamicBodyMovementController movementController;
		int chargesCount;
		float chargeCooldown;

		DifficultyConfig.PlayerAbilitiesConfig Config => GameManager.Difficulty.PlayerAbilitiesConfiguration;

		internal void Boost()
		{
			if (chargesCount > 0)
			{
				movementController.Accelerate(Config.BoostForce, ForceMode2D.Impulse);
				chargesCount--;
			}
		}

		void Awake()
		{
			movementController = GetComponent<DynamicBodyMovementController>();
		}
		void Start()
		{
			chargesCount = Config.BoostCharges;
			chargeCooldown = Config.ChargeCooldown;
		}
		void Update()
		{
			if (chargesCount < Config.BoostCharges)
			{
				chargeCooldown -= Time.deltaTime;
				if (chargeCooldown <= 0.0f)
				{
					chargesCount++;
					chargeCooldown = Config.ChargeCooldown;
				}
			}
		}
	}
}
