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

		internal float MaxVelocity => maxSpeed;

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
		private void OnEnable()
		{
			input.Enable();
		}
		private void OnDisable()
		{
			input.Disable();
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
			}

			internal void Enable()
			{
				actions.Enable();
			}
			internal void Disable()
			{
				actions.Disable();
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
