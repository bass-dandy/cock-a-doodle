using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject playerCamera;
	[SerializeField] private GameObject carCamera;
	[SerializeField] private EventTrigger carTrigger;
	[SerializeField] private CarController car;
	[SerializeField] private EventTrigger endGameTrigger;
	[SerializeField] private Transform endGameCameraPos;
	[SerializeField] private Text titleText;

	private GameObject player;

	private bool canEnterCar = false;
	private bool canActivateDish = true;
	private bool canEndGame = false;

	[SerializeField] private GameObject abduction;

	public bool CanEnterCar {
		get { return canEnterCar; }
		private set { canEnterCar = value; }
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		carTrigger.OnPlayerEnter += OnCarTriggerEnter;
		carTrigger.OnPlayerExit  += OnCarTriggerExit;
		endGameTrigger.OnPlayerEnter += OnEndGameTriggerEnter;
	}

	private void OnCarTriggerEnter () {
		if(!canEnterCar)
			canEnterCar = true;
	}

	private void OnCarTriggerExit () {
		canEnterCar = false;
	}

	private void OnEndGameTriggerEnter() {
		canEndGame = true;
	}

	private void OnEndGameTriggerExit() {
		canEndGame = false;
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

	public void ActivateDish() {
		if (canActivateDish) {
			canActivateDish = false;
			abduction.SetActive(true);
		}
	}

	public void EndGame() {
		if (canEndGame) {
			player.GetComponent<Rigidbody> ().isKinematic = true;
			playerCamera.GetComponent<CameraController> ().LerpTransform (endGameCameraPos);
			gameObject.GetComponent<AudioSource> ().Play ();
			StartCoroutine (FadeInText());
		}
	}

	IEnumerator FadeInText() {
		while (titleText.color.a < 0.99f) {
			titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, Mathf.Lerp (titleText.color.a, 1.0f, 0.5f * Time.deltaTime));
			yield return null;
		}
	}
}
