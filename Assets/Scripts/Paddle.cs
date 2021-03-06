﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float maxX = 15.108f;
	public float minX = 0.892f;


	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutomatedPlay();
		}
	}

	void MoveWithMouse() {
		// On every frame, we move with mouse

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,minX,maxX);		
		this.transform.position = paddlePos;
	}

	void AutomatedPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
