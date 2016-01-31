using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour {

	[SerializeField] private float angularSpeed;

	void Update () {
		transform.Rotate (new Vector3(0, 0, angularSpeed * Time.deltaTime));
	}
}
