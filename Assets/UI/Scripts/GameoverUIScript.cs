using Assets.Scripts.WorldConducting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts
{
	[RequireComponent(typeof(UIDocument))]
	public class GameoverUIScript : MonoBehaviour
	{
		[SerializeField]
		string activeGameSceneName;
		UIDocument uiDoc;

		// Start is called before the first frame update
		void Start()
		{
			uiDoc.rootVisualElement.Q<Button>("RestartButton").clicked += () =>
			{
				SceneManager.LoadScene(activeGameSceneName, LoadSceneMode.Single);
			};

			uiDoc.rootVisualElement.Q<Label>("ScoreText").text = Overseer.LastSessionPlayerScore.ToString();
		}

		void Awake()
		{
			uiDoc = GetComponent<UIDocument>();
		}
	}
}
