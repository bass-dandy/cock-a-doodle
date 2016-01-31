using UnityEngine;
using System.Collections;

public class MetalRooster : MonoBehaviour, IPeckable {

	[SerializeField] private float peckForce;

	public void Peck(Vector3 direction) {
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.AddForce (direction.normalized * peckForce);
		Destroy (gameObject.GetComponent<MetalRooster>());
	}
}
