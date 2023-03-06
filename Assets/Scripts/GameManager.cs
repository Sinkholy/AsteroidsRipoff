using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	internal static class GameManager
	{
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
	}
}
