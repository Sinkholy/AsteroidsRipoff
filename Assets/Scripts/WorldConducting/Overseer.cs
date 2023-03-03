using Assets.Scripts.Entities;
using Assets.Scripts.WorldConducting;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.WorldConducting
{
	public class Overseer : MonoBehaviour
	{
		[SerializeField]
		UIDocument doc1;
		[SerializeField]
		Player player;

		void Awake()
		{
		}
		// Start is called before the first frame update
		void Start()
		{
			doc1.enabled = false;
			//player.gameObject.SetActive(false);
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}
