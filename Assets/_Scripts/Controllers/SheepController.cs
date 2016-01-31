using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour, IPeckable {

	[SerializeField] private float walkSpeed;
	[SerializeField] private float walkDistance;

	Coroutine coroutine;

	public void Peck(Vector3 direction) {
		if (coroutine != null) {
			StopCoroutine (coroutine);
		}
		coroutine = StartCoroutine (Walk(direction));
	}

	IEnumerator Walk(Vector3 direction) {
		float distanceRemaining = walkDistance;

		while (distanceRemaining > 0) {
			transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, walkSpeed * Time.deltaTime);
			distanceRemaining -= walkSpeed * Time.deltaTime;
			yield return null;
		}
	}
}
