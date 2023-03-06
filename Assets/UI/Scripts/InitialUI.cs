using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts
{
	[RequireComponent(typeof(UIDocument))]
	public class InitialUI : MonoBehaviour
	{
		[SerializeField]
		string activeGameSceneName;

		UIDocument uiDoc;

		void Awake()
		{
			uiDoc = GetComponent <UIDocument>();
		}
		void Start()
		{
			uiDoc.rootVisualElement.Q<Button>("PlayButton").clicked += () =>
			{
				SceneManager.LoadScene(activeGameSceneName);
			};

			SetControlsScheme();
		}

		void SetControlsScheme()
		{
			var actions = new DefaultActions();

			uiDoc.rootVisualElement.Q<Label>("MovementControlsText").text = GetMovementText();
			var gamepadControlsFoldout = uiDoc.rootVisualElement.Q<Foldout>("Gamepad");

			string GetMovementText()
			{
				string movementControls = string.Empty;

				foreach (var movementControl in actions.Movement.Accelerate.controls)
				{
					movementControls += movementControl.displayName + " / ";
				}

				return movementControls;
			}
		}
	}
}
