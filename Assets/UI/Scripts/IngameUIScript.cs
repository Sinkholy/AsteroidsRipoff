using System;

using Assets.Scripts;
using Assets.Scripts.Entities;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

using static DefaultActions;
using static DifficultyConfig;

public class IngameUIScript : MonoBehaviour
{
    UIDocument uiDoc;
    [SerializeField]
    Player player;

	#region UI elements to be updated
	Input input;
    Label laserChargerText;
    ProgressBar laserCooldownBar;
    Label rotationText;
    Label coordinatesText;
    ProgressBar accelerationBar;
    ProgressBar velocityBar;
    Label livesLeftText;
	#endregion

	PlayerMovementConfig PlayerMovement => GameManager.Difficulty.PlayerMovementConfiguration;
	PlayerArmoryConfig PlayerArmory => GameManager.Difficulty.PlayerArmoryConfiguration;

	void Awake()
	{
		uiDoc = GetComponent<UIDocument>();
	}
	void Start()
    {
        input = new Input();
		GetUIElements();

		void GetUIElements()
		{
			var root = uiDoc.rootVisualElement;

			laserCooldownBar = root.Q<ProgressBar>("LaserCooldownBar");
			laserChargerText = root.Q<Label>("LaserChargesText");
			rotationText = root.Q<Label>("RotationText");
			coordinatesText = root.Q<Label>("CoordinatesText");
			accelerationBar = root.Q<ProgressBar>("AccelerationBar");
			velocityBar = root.Q<ProgressBar>("VelocityBar");
			livesLeftText = root.Q<Label>("LivesCountText");
		}
	}
    void Update()
    {
        accelerationBar.value = input.AccelerationInput;
        UpdateVelocityUI();
        UpdateLaserUI();
        rotationText.text = Math.Round(player.RotationAngle).ToString();
        coordinatesText.text = player.WorldCoordinates.ToString();
        livesLeftText.text = player.HP.ToString();

        void UpdateVelocityUI()
        {
			velocityBar.value = GetVelocityBarValue();

			var playerVelocity = Math.Round(player.Velocity, 1);
			var playerMaxVelocity = PlayerMovement.MaxVelocity;
			velocityBar.title = $"Velocity: {playerVelocity}/{playerMaxVelocity}";


			float GetVelocityBarValue()
			{
				float maxVelocity = PlayerMovement.MaxVelocity;
				float percent = 100 / maxVelocity;

				return Mathf.Round(player.Velocity * percent);
			}
		}
        void UpdateLaserUI()
        {
			var cooldownPercents = GetLaserCooldownPercents();
			laserCooldownBar.value = cooldownPercents;
			laserCooldownBar.title = $"Charge: {cooldownPercents}%";

			var charges = player.LaserCharges;
			var maxCharges = PlayerArmory.LaserMaxCharges;
			laserChargerText.text = $"{charges}/{maxCharges}";


			float GetLaserCooldownPercents()
			{
				float percent = 100 / PlayerArmory.ChargeCooldown;

				var chargeCooldown = PlayerArmory.ChargeCooldown;
				var currentCooldown = player.LaserCurrentChargeCooldown;

				return Mathf.Round((chargeCooldown - currentCooldown) * percent);
			}
		}
    }

	class Input : IMovementActions
	{
		internal float AccelerationInput { get; private set; }

		DefaultActions actions;

		internal Input()
		{
			actions = new DefaultActions();
			actions.Movement.SetCallbacks(this);
            if (!actions.Movement.enabled)
            {
				actions.Movement.Enable();
			}
		}

		public void OnAccelerate(InputAction.CallbackContext context)
		{
			AccelerationInput = context.action.ReadValue<float>();
		}

        public void OnRotate(InputAction.CallbackContext context) { }
    }
}
