using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	internal static class GameManager
	{
		static Scene InitialScene => SceneManager.GetSceneByBuildIndex(0);
		static Scene GameScene => SceneManager.GetSceneByBuildIndex(1);
		static Scene GameoverScene => SceneManager.GetSceneByBuildIndex(2);

		public static void LoadInitialScreen()
		{
			SceneManager.LoadScene(InitialScene.name, LoadSceneMode.Single);
		}
		public static void LoadGame()
		{
			SceneManager.LoadScene(GameScene.name, LoadSceneMode.Single);
		}
		public static void LoadGameoverScreen()
		{
			SceneManager.LoadScene(GameoverScene.name, LoadSceneMode.Single);
		}
	}
}
