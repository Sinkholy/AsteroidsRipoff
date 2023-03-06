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

			uiDoc.rootVisualElement.Q<Label>("ScoreText").text = Overseer.LastSessionPlayerScore.ToString();
		}

		void Awake()
		{
			uiDoc = GetComponent<UIDocument>();
		}
	}
}
