using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject playerCamera;
	[SerializeField] private GameObject carCamera;
	[SerializeField] private EventTrigger carTrigger;
	[SerializeField] private CarController car;

	private GameObject player;

	private bool canEnterCar;

	public bool CanEnterCar {
		get { return canEnterCar; }
		private set { canEnterCar = value; }
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		carTrigger.OnPlayerEnter += OnCarTriggerEnter;
		carTrigger.OnPlayerExit  += OnCarTriggerExit;
	}

	private void OnCarTriggerEnter () {
		if(!canEnterCar)
			canEnterCar = true;
	}

	private void OnCarTriggerExit () {
		canEnterCar = false;
	}

	public void ToggleCar() {
		// Get in car if not in car
		if (playerCamera.activeSelf) {
			playerCamera.SetActive (false);
			carCamera.SetActive (true);
			player.transform.SetParent (car.transform);
			player.GetComponent<Rigidbody> ().isKinematic = true;
			car.TurnOn ();
		}
		// get out of car otherwise
		else {
			playerCamera.SetActive (true);
			carCamera.SetActive (false);
			player.transform.parent = null;
			player.GetComponent<Rigidbody> ().isKinematic = false;
			car.TurnOff ();
		}
	}
	
	void Update () {
	
	}
}
