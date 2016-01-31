using UnityEngine;
using System.Collections;

public class PigController : MonoBehaviour {

	[SerializeField] private float turnSpeed;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float eatDistance;

	private GameObject tgt;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Yolk" && tgt == null) {
			tgt = other.gameObject;
			StartCoroutine (FaceTgt());
		}
	}

	IEnumerator FaceTgt() {
		// Use our own y-position so we dont look up or down
		Vector3 tgtPosition = new Vector3 (tgt.transform.position.x, transform.position.y, tgt.transform.position.z);
		Quaternion tgtRotation = Quaternion.LookRotation (tgtPosition, transform.up);

		while (tgt != null && Quaternion.Angle(transform.rotation, tgtRotation) > 1f) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, tgtRotation, turnSpeed * Time.deltaTime);
			yield return null;
		}
		StartCoroutine (WalkToTgt());
	}

	IEnumerator WalkToTgt() {
		while (tgt != null /*&& Vector3.Distance (transform.position, tgt.transform.position) < eatDistance*/) {
			transform.position = Vector3.MoveTowards (transform.position, tgt.transform.position, walkSpeed * Time.deltaTime);
			yield return null;
		}
	}
}
