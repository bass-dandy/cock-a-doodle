using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider FrontLeftWheel;
	public WheelCollider FrontRightWheel;

	[SerializeField] private float engineTorque;
	[SerializeField] private float steerCoefficient;

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
	}

	public void TurnOff() {
		isOn = false;
	}
}
