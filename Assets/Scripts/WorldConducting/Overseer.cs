using Assets.Scripts.Entities;
using Assets.Scripts.WorldConducting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assets.Scripts.WorldConducting
{
	public class Overseer : MonoBehaviour
	{
		#region Play session data
		internal static int LastSessionPlayerScore;
		// ???? ??????????? ??? ???????? ?????? ? ????????? ?????.
		#endregion

		[SerializeField]
		Player player;
		DifficultyConfig.PlayerConfig config => GameManager.Difficulty.PlayerConfiguration;

		float currentSpawnCooldown;
		bool playerSpawnRequested;

		void Awake()
		{
		}

		void Start()
		{
			player.HealthDecreased += OnPlayerDecreasedHP;

			playerSpawnRequested = false;
			currentSpawnCooldown = config.RespawnCooldown;
		}

		void Update()
		{
			if (playerSpawnRequested) // TODO: coroutine maybe?
			{
				currentSpawnCooldown -= Time.deltaTime;
				if(currentSpawnCooldown <= 0)
				{
					player.gameObject.SetActive(true);
					player.gameObject.transform.position = new Vector2(0, 0);
					currentSpawnCooldown = config.RespawnCooldown;
					playerSpawnRequested = false;
				}
			}
		}

		void OnDestroy()
		{
			LastSessionPlayerScore = player.Score;
		}

		void OnPlayerDecreasedHP()
		{
			if(player.HP <= 0)
			{
				GameManager.LoadGameoverScreen();
			}
			else
			{
				playerSpawnRequested = true;
				player.gameObject.SetActive(false);
			}
		}
	}
}
