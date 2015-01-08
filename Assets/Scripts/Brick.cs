using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;

	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");

		// Keep track of breakable blocks
		if (isBreakable) {
			breakableCount++;
		}
	}

	
	// Update is called once per frame
	void Update () {

	}

	// Handle collisions
	void OnCollisionEnter2D(Collision2D collision) {
		if (isBreakable) {
			// Spawn a audio source at the point where brick was hit, so it can play even if the Object is destroyed destroyed
			AudioSource.PlayClipAtPoint(crack, transform.position);
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		
		// Maximum hits is the number of hit sprites + 1, since we have the initial sprite.

		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breakableCount--;
			Destroy (gameObject); // Destroy the brick
			GameObject puff = Instantiate(smoke, transform.position,Quaternion.identity) as GameObject; // Spawn smoke where the brick was before
			puff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			levelManager.BrickDestroyed(); // Check if we already won!
		} else {
			LoadSprites();	
		}
	}

	// Load 1 hit and 2 hit sprites! Log an error if sprite doesn't exist.

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError("Btick.cs: Brick sprite missing");
		}
	}
}
