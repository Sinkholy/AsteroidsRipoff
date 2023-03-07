using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	internal static class GameManager
	{
		#region Difficulty
		const string difficultiesAssetsPath = "Difficulty";
		internal static DifficultyConfig[] AvailableDifficulties { get; private set; }
		internal static DifficultyConfig Difficulty { get; set; }
		#endregion

		static GameManager()
		{
			AvailableDifficulties = Resources.LoadAll<DifficultyConfig>(difficultiesAssetsPath);
			Difficulty = AvailableDifficulties[0];
		}

		#region Scenes
		static string InitialScenePath => SceneUtility.GetScenePathByBuildIndex(0);
		static string GameScenePath => SceneUtility.GetScenePathByBuildIndex(1);
		static string GameoverScenePath => SceneUtility.GetScenePathByBuildIndex(2);

		public static void LoadInitialScreen()
		{
			SceneManager.LoadScene(InitialScenePath, LoadSceneMode.Single);
		}
		public static void LoadGame()
		{
			SceneManager.LoadScene(GameScenePath, LoadSceneMode.Single);
		}
		public static void LoadGameoverScreen()
		{
			SceneManager.LoadScene(GameoverScenePath, LoadSceneMode.Single);
		}
		#endregion
	}
}
