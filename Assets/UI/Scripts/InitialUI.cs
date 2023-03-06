using Assets.Scripts;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts
{
	[RequireComponent(typeof(UIDocument))]
	public class InitialUI : MonoBehaviour
	{
		UIDocument uiDoc;

		void Awake()
		{
			uiDoc = GetComponent <UIDocument>();
		}
		void Start()
		{
			uiDoc.rootVisualElement.Q<Button>("PlayButton").clicked += () =>
			{
				GameManager.LoadGame();
			};
		}
	}
}
