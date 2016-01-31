using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PigController : MonoBehaviour {

	[SerializeField] private float turnSpeed;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float eatDistance;

	private Queue<GameObject> tgts;

	void Start() {
		tgts = new Queue<GameObject> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Yolk") {
			tgts.Enqueue(other.gameObject);
		}
	}

	void Update() {
		if (tgts.Count > 0) {
			GameObject tgt = tgts.Peek ();

			// Use our own y-position so we dont look up or down
			Vector3 tgtPosition = new Vector3 (tgt.transform.position.x, transform.position.y, tgt.transform.position.z);
			Quaternion tgtRotation = Quaternion.LookRotation (tgtPosition, transform.up);

			if (Quaternion.Angle(transform.rotation, tgtRotation) > 1f) {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, tgtRotation, turnSpeed * Time.deltaTime);
			}
			else if (Vector3.Distance (transform.position, tgt.transform.position) > eatDistance) {
				transform.position = Vector3.MoveTowards (transform.position, tgt.transform.position, walkSpeed * Time.deltaTime);
			}
			else {
				Destroy (tgts.Dequeue());
			}
		}
	}
}
