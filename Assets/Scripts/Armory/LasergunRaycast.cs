using UnityEngine;

namespace Assets.Scripts.Armory
{
	[RequireComponent(typeof(LineRenderer))]
	internal class LasergunRaycast : MonoBehaviour
	{
		[SerializeField]
		int maxCharges;
		[SerializeField]
		float chargeCooldown;
		[SerializeField]
		float chargeDuration;

		LineRenderer lineRenderer;
		float beamLength;

		LaserState state;
		int charges;
		float currentDuration;
		float currentCooldown;

		private void Awake()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		private void Start()
		{
			beamLength = Vector2.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));
		}

		private void Update()
		{
			var hits = Physics2D.RaycastAll(transform.position, transform.rotation * Vector3.up, beamLength);
			if (hits.Length > 0)
			{

			}
		}

		enum LaserState : byte
		{
			Charging,
			Firing
		}
	}
}
