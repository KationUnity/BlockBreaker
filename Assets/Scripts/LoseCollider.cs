using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;


	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		LevelManager.currentLevel = Application.loadedLevel;
	}

	void OnTriggerEnter2D (Collider2D colider) {
		levelManager.LoadLevel ("Lose Screen");
		//Brick.breakableCount = 0;
	}
}
