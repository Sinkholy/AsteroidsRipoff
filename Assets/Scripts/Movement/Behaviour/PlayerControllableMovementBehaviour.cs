using UnityEngine;
using UnityEngine.InputSystem;

using static DefaultActions;

namespace Assets.Scripts.Movement.Behaviour
{
	[RequireComponent(typeof(DynamicBodyMovementController))]
	public class PlayerControllableMovementBehaviour : MonoBehaviour
	{
		#region Configuration
		[SerializeField]
		float rotationFactor;
		[SerializeField]
		float accelerationFactor;
		[SerializeField]
		float maxSpeed;
		#endregion

		MovementInputReader input;
		DynamicBodyMovementController movementController;

		#region Unity callbacks
		void Awake()
		{
			input = new MovementInputReader();
			movementController = GetComponent<DynamicBodyMovementController>();
		}
		private void FixedUpdate()
		{
			var rotationOffset = (input.RotationInput * rotationFactor) * Time.deltaTime;
			movementController.Rotate(rotationOffset);

			var targetAcceleration = accelerationFactor * input.AccelerationInput;
			movementController.Accelerate(targetAcceleration, ForceMode2D.Force, maxSpeed);
		}
		#endregion

		class MovementInputReader : IMovementActions
		{
			internal float RotationInput { get; private set; }
			internal float AccelerationInput { get; private set; }

			DefaultActions actions;

			internal MovementInputReader()
			{
				actions = new DefaultActions();
				actions.Movement.SetCallbacks(this);
				actions.Movement.Enable();
			}

			public void OnAccelerate(InputAction.CallbackContext context)
			{
				AccelerationInput = context.action.ReadValue<float>();
			}
			public void OnRotate(InputAction.CallbackContext context)
			{
				RotationInput = context.action.ReadValue<float>();
			}
		}
	}
}
