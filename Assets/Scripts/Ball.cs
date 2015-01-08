using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		// Once we click the mouse, we start the game and get the ball movin' !

		if (Input.GetMouseButtonDown (0) && !hasStarted) {
			hasStarted = true;
			this.rigidbody2D.velocity = new Vector2(2f, 10f);
		}
	}

	// Play boing sounds on collision
	void OnCollisionEnter2D() {

		Vector2 tweak = new Vector2 (Random.Range (-0.1f, 0.2f), Random.Range (-0.1f, 0.2f));

		// Ball does no trigger sound when brick is destroyed.
		// Not a 100% sure why, possibly because brick isn't there.

		if (hasStarted) {
			audio.Play ();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
