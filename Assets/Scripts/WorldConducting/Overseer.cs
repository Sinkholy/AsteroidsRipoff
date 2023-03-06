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
		// Поле необходимое для передачи данных в следующую сцену.
		#endregion

		[SerializeField]
		Player player;
		[SerializeField]
		float playerSpawnCooldown;
		float currentSpawnCooldown;
		bool playerSpawnRequested;

		void Awake()
		{
		}

		void Start()
		{
			player.HealthDecreased += OnPlayerDecreasedHP;

			playerSpawnRequested = false;
			currentSpawnCooldown = playerSpawnCooldown;
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
					currentSpawnCooldown = playerSpawnCooldown;
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
