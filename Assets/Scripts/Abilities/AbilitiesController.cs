using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using static DefaultActions;

namespace Assets.Scripts.Abilities
{
	[RequireComponent(typeof(BoostAbility))]
	internal class AbilitiesController : MonoBehaviour, IAbilitiesActions
	{
		DefaultActions actions;
		BoostAbility boost;

		private void Awake()
		{
			actions = new DefaultActions();
			actions.Abilities.SetCallbacks(this);
			actions.Abilities.Enable();

			boost = GetComponent<BoostAbility>();
		}

		public void OnBoost(InputAction.CallbackContext context)
		{
			if(context.interaction is PressInteraction &&
			   context.performed)
			{
				boost.Boost();
			}
		}
		public void OnSlowmotion(InputAction.CallbackContext context) { }
	}
}
