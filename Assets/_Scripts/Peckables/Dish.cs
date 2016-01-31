using UnityEngine;
using System.Collections;

public class Dish : MonoBehaviour, IPeckable {

	private GameManager gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
	}
	
	public void Peck(Vector3 direction) {
		gm.ActivateDish ();
	}
}
