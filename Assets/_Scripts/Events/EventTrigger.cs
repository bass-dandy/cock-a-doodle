using UnityEngine;
using System.Collections;
using System;

public class EventTrigger : MonoBehaviour {

	public event Action OnPlayerEnter;
	public event Action OnPlayerExit;

	void OnTriggerEnter(Collider other) {
		if (other != null && OnPlayerEnter != null && other.tag == "Player") {
			OnPlayerEnter ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other != null && OnPlayerExit != null && other.tag == "Player") {
			OnPlayerExit ();
		}
	}
}
