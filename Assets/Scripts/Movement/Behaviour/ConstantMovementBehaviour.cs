using UnityEngine;

namespace Assets.Scripts.Movement.Behaviour
{
	[RequireComponent(typeof(KineticBodyMovementController))]
	internal class ConstantMovementBehaviour : MonoBehaviour
	{
		KineticBodyMovementController movementController;

		internal float TargetSpeed { get; set; }
		internal float TargetDirection { get; set; }

		#region Unity callbacks
		void Awake()
		{
			movementController = GetComponent<KineticBodyMovementController>();
		}
		void FixedUpdate()
		{
			movementController.SetRotation(TargetDirection);
			movementController.SetVelocity(TargetSpeed);
		}
		#endregion
	}
}
