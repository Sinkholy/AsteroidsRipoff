using System.Linq;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts
{
	[RequireComponent(typeof(UIDocument))]
	public class InitialUI : MonoBehaviour
	{
		UIDocument uiDoc;
		DropdownField difficultyDDL;

		void Awake()
		{
			uiDoc = GetComponent<UIDocument>();
		}
		void Start()
		{
			uiDoc.rootVisualElement.Q<Button>("PlayButton").clicked += OnPlayButtonClicked;

			difficultyDDL = uiDoc.rootVisualElement.Q<DropdownField>("DifficultyDDL");
			difficultyDDL.choices = GameManager.AvailableDifficulties.Select(x => x.Name).ToList();
			difficultyDDL.index = 0;
		}

		void OnPlayButtonClicked()
		{
			SetDifficulty();
			LoadGame();


			void SetDifficulty()
			{
				var chosenDifficultyIndex = difficultyDDL.index;
				var chosenDifficulty = GameManager.AvailableDifficulties[chosenDifficultyIndex];
				GameManager.Difficulty = chosenDifficulty;
			}
			void LoadGame()
			{
				GameManager.LoadGame();
			}
		}
	}
}
