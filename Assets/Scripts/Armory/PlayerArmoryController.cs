using System;

using Assets.Scripts.Entities;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using static DefaultActions;

namespace Assets.Scripts.Armory
{
	public class PlayerArmoryController : MonoBehaviour, IArmoryActions
	{
		#region Configuration
		[SerializeField]
		Lasergun lasergun;
		[SerializeField]
		ProjectileLauncher projecileLauncher;
		#endregion

		DefaultActions actions;

		internal event Action<IEnemy> HitOccured = delegate { };

		internal Lasergun Lasergun => lasergun;

		public void OnPrimaryFire(InputAction.CallbackContext context)
		{
			if (context.interaction is PressInteraction &&
				context.performed)
			{
				projecileLauncher.Fire();
			}
		}
		public void OnSecondaryFire(InputAction.CallbackContext context)
		{
			if (context.interaction is PressInteraction &&
				context.performed)
			{
				lasergun.Fire();
			}
		}

		void Awake()
		{
			if (actions is null)
			{
				actions = new DefaultActions();
				actions.Armory.SetCallbacks(this);
			}
			actions.Armory.Enable();

			lasergun.HitOccured += (e) => HitOccured(e);
			projecileLauncher.HitOccured += (e) => HitOccured(e);
		}
	}
}
