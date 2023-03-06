using Assets.Scripts.Entities;
using Assets.Scripts.WorldConducting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assets.Scripts.WorldConducting
{
	public class Overseer : MonoBehaviour
	{
		[SerializeField]
		Player player;
		[SerializeField]
		string gameoverSceneName;
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

		void OnPlayerDecreasedHP()
		{
			if(player.HP <= 0)
			{
				SceneManager.LoadScene(gameoverSceneName, LoadSceneMode.Single);
			}
			else
			{
				playerSpawnRequested = true;
				player.gameObject.SetActive(false);
			}
		}
	}
}
