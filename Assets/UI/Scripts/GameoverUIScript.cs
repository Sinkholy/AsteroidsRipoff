using Assets.Scripts;
using Assets.Scripts.WorldConducting;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts
{
	[RequireComponent(typeof(UIDocument))]
	public class GameoverUIScript : MonoBehaviour
	{
		UIDocument uiDoc;

		// Start is called before the first frame update
		void Start()
		{
			uiDoc.rootVisualElement.Q<Button>("RestartButton").clicked += () =>
			{
				GameManager.LoadGame();
			};

			uiDoc.rootVisualElement.Q<Button>("ExitButton").clicked += () =>
			{
				Quit();
			};

			uiDoc.rootVisualElement.Q<Label>("ScoreText").text = Overseer.LastSessionPlayerScore.ToString();
		}

		void Awake()
		{
			uiDoc = GetComponent<UIDocument>();
		}

		void Quit()
		{
			#if UNITY_STANDALONE
			Application.Quit();
			#endif
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}
}
