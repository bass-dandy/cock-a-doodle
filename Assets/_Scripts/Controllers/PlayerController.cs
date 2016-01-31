using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] private GameObject eggPrefab;
	[SerializeField] private float groundSpeed;
	[SerializeField] private float angularSpeed;
	[SerializeField] private float jumpForceGround;
	[SerializeField] private float jumpForceAir;
	[SerializeField] private GameObject peckTrigger;

	private Rigidbody rb;
	private GameManager gm;

	// Stored inputs from update
	private float strafe;
	private float walk;
	private float yaw;
	private bool isJumpDown;
	private bool isEggDown;
	private bool isPeckDown;

	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	void Update () {
		// Get inputs
		strafe     = Input.GetAxis ("Strafe");
		walk       = Input.GetAxis ("Walk");
		yaw        = Input.GetAxis ("Yaw");
		isJumpDown = Input.GetButtonDown ("Jump");
		isEggDown  = Input.GetButtonDown ("Egg");
		isPeckDown = Input.GetButtonDown ("Peck");
	}

	void FixedUpdate() {
		// Move
		Vector3 strafeVec = transform.right * strafe * groundSpeed;
		Vector3 walkVec   = transform.forward * walk * groundSpeed;

		Vector3 groundVel = Vector3.ClampMagnitude (strafeVec + walkVec, groundSpeed);
		Vector3 currentGroundVel = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
		groundVel = Vector3.Lerp (currentGroundVel, groundVel, 0.1f);

		// Change planar velocity while preserving jump velocity
		rb.velocity = groundVel + new Vector3(0, rb.velocity.y, 0);

		// Turn
		float turnVel = Mathf.Lerp(rb.angularVelocity.y, yaw * angularSpeed, 0.2f);
		rb.angularVelocity = new Vector3 (0, turnVel, 0);

		// Jump
		if (isJumpDown && rb.velocity.y <= 0.01f) {
			// Jump from ground
			rb.AddRelativeForce (0, jumpForceGround, 0);
		} else if (isJumpDown) {
			// Flap frantically in air
			rb.AddRelativeForce (0, jumpForceAir, 0);
		}
		// Lay eggs
		if (isEggDown) {
			Instantiate (eggPrefab, transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
		}
		// Peck
		if (isPeckDown && gm.CanEnterCar) {
			gm.ToggleCar ();
		} else if (Input.GetButton("Peck")) {
			peckTrigger.SetActive (true);
		} else {
			peckTrigger.SetActive (false);
		}
	}
}
