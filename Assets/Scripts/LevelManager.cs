﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static int currentLevel;

	public void LoadLevel(string name) {
		//Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel (name);

	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void ReloadLevel() {
		Application.LoadLevel (currentLevel);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount == 0) {
			LoadNextLevel();
		}
	}

	public void QuitRequest() {
		Debug.Log ("Quit level?");
		Application.Quit();
	}
}
