using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	[SerializeField] private Transform target;
	[SerializeField] private float distance;
	[SerializeField] private float elevation;
	[SerializeField] private float maxPitch;
	[SerializeField] private float minPitch;
	[SerializeField] private float defaultPitch;
	[SerializeField] private float pitchRate;
	[SerializeField] private float delay;

	private Queue<Quaternion> previousPlayerRotations;
	private Queue<Vector3> previousPlayerPositions;
	private float pitch;
	private bool isPlayerControlled;

	void Start () {
		previousPlayerRotations = new Queue<Quaternion> ();
		previousPlayerPositions = new Queue<Vector3> ();
		pitch = defaultPitch;
		isPlayerControlled = true;
	}

	void FixedUpdate () {
		if (isPlayerControlled) {
			previousPlayerRotations.Enqueue (target.rotation);
			previousPlayerPositions.Enqueue (target.position);

			// Change camera pitch based on right stick input
			pitch += Input.GetAxis ("Pitch") * pitchRate * Time.fixedDeltaTime;
			pitch = Mathf.Clamp (pitch, minPitch, maxPitch);

			// Delay the camera rotation
			if (delay > 0) {
				delay -= Time.fixedDeltaTime;
			} else {
				transform.rotation = Quaternion.Euler (previousPlayerRotations.Dequeue ().eulerAngles + new Vector3 (pitch, 0, 0));
				transform.position = previousPlayerPositions.Dequeue () - transform.forward * distance + new Vector3 (0, elevation, 0);
			}
		}
	}

	public void LerpTransform(Transform dest) {
		isPlayerControlled = false;
		StartCoroutine (LerpTransformCoroutine(dest));
	}

	IEnumerator LerpTransformCoroutine(Transform dest) {
		while (Vector3.Distance (transform.position, dest.position) > 0.1f && Quaternion.Angle (transform.rotation, dest.rotation) > 1f) {
			transform.position = Vector3.Lerp (transform.position, dest.position, 0.2f * Time.deltaTime);
			transform.rotation = Quaternion.Lerp (transform.rotation, dest.rotation, 0.2f * Time.deltaTime);
			yield return null;
		}
		SceneManager.LoadScene ("main");
	}
}
