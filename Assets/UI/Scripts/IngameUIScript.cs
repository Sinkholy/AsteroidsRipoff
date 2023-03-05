using System;
using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.Entities;
using Assets.Scripts.Movement.Behaviour;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

using static DefaultActions;

public class IngameUIScript : MonoBehaviour
{
    UIDocument uiDoc;
    [SerializeField]
    Player player;

    Input input;

    Label laserChargerText;
    ProgressBar laserCooldownBar;

    Label rotationText;

    Label coordinatesText;

    ProgressBar accelerationBar;

    ProgressBar velocityBar;

    Label livesLeftText;

    // Start is called before the first frame update
    void Start()
    {
        input = new Input();
        uiDoc = GetComponent<UIDocument>();

        var root = uiDoc.rootVisualElement;

        laserCooldownBar = root.Q<ProgressBar>("LaserCooldownBar");
        laserChargerText = root.Q<Label>("LaserChargesText");

        rotationText = root.Q<Label>("RotationText");

        coordinatesText = root.Q<Label>("CoordinatesText");

        accelerationBar = root.Q<ProgressBar>("AccelerationBar");

        velocityBar = root.Q<ProgressBar>("VelocityBar");

        livesLeftText = root.Q<Label>("LivesCountText");
	}

    // Update is called once per frame
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
			velocityBar.title = $"Velocity: {Math.Round(player.Velocity, 1)}/{player.GetComponent<PlayerControllableMovementBehaviour>().MaxVelocity}";


			float GetVelocityBarValue()
			{
				float maxVelocity = player.GetComponent<PlayerControllableMovementBehaviour>().MaxVelocity;
				float percent = 100 / maxVelocity;

				return Mathf.Round(player.Velocity * percent);
			}
		}
        void UpdateLaserUI()
        {

			laserCooldownBar.value = GetLaserCooldown();
			laserChargerText.text = GetLaserChargesFormated();
			laserCooldownBar.title = $"Charge: {GetLaserCooldown()}%";


			string GetLaserChargesFormated()
			{
				return $"{player.LaserCharges}/{5}";
			}
			float GetLaserCooldown()
			{
				const float ChargeCooldown = 5;
				float percent = 100 / ChargeCooldown;

				return Mathf.Round((ChargeCooldown - player.LaserChargeCooldown) * percent);
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

        public void OnRotate(InputAction.CallbackContext context)
        {
        }
    }
}
