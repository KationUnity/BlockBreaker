﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		// Once we click the moouse, we start the game and get the ball movin' !

		if (Input.GetMouseButtonDown (0)) {
			print ("Mouse clicked, launch ball!");
			hasStarted = true;
			this.rigidbody2D.velocity = new Vector2(2f, 10f);
		}
	}
}