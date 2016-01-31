using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider FrontLeftWheel;
	public WheelCollider FrontRightWheel;

	[SerializeField] private float engineTorque;
	[SerializeField] private float steerCoefficient;
	[SerializeField] private GameObject leftHeadlight;
	[SerializeField] private GameObject rightHeadlight;

	private bool isOn = false;

	void Update () {
		if (isOn) {
			FrontLeftWheel.motorTorque = engineTorque * Input.GetAxis ("Car Accelerate");
			FrontRightWheel.motorTorque = engineTorque * Input.GetAxis ("Car Accelerate");

			FrontLeftWheel.steerAngle = steerCoefficient * Input.GetAxis ("Strafe");
			FrontRightWheel.steerAngle = steerCoefficient * Input.GetAxis ("Strafe");
		}
	}

	public void TurnOn() {
		isOn = true;
		leftHeadlight.SetActive (true);
		rightHeadlight.SetActive (true);
	}

	public void TurnOff() {
		isOn = false;
		leftHeadlight.SetActive (false);
		rightHeadlight.SetActive (false);
	}
}
