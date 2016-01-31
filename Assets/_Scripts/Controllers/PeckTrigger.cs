using UnityEngine;
using System.Collections;

public class PeckTrigger : MonoBehaviour {

	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void OnTriggerEnter(Collider other) {
		IPeckable p = InterfaceUtils.GetInterface<IPeckable> (other.gameObject);
		if (p != null) {
			p.Peck (player.forward);
		}
	}
}
