using UnityEngine;

namespace Assets.Scripts.Movement.Behaviour
{
	[RequireComponent(typeof(KineticBodyMovementController))]
	public class ChaserMovementBehaviour : MonoBehaviour
	{
		KineticBodyMovementController movementController;
		internal GameObject Target { get; set; }
		internal float Speed { get; set; }

		#region Unity callbacks
		void Awake()
		{
			movementController = GetComponent<KineticBodyMovementController>();
		}
		void Start()
		{
			
		}
		void FixedUpdate()
		{
			movementController.SetVelocity(Speed);
			movementController.MoveTowards(Target.transform.position);			
		}
		#endregion
	}
}
