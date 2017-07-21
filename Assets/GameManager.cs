using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int selectedZombiePosition = 0;
	private int score = 0;
	public Text scoreText;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	// Vector3 is your x,y and z axis
	public Vector3 selectedSize;
	public Vector3 defaultSize;

	// Use this for initialization
	void Start () {
		// Call SelectZombie and pass in selectedZombie
		SelectZombie (selectedZombie);
		scoreText.text = "Score: " + score;

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("left")) {
			GetZombieLeft ();
		}

		if (Input.GetKeyDown ("right")) {
			GetZombieRight ();
		}

		if (Input.GetKeyDown ("up")) {
			PushUp ();
		}

	}

	void SelectZombie(GameObject newZombie) {
		// reset currently selected zombies dimensions to default
		selectedZombie.transform.localScale = defaultSize;
		selectedZombie = newZombie;
		// Make new selectedZombies size different than default (bigger)
		newZombie.transform.localScale = selectedSize;
	}

	// when left key pressed
	// select next zombie to the left unless at position 0
	// if so then select the far right zombie
	void GetZombieLeft() {
		if (selectedZombiePosition == 0) {
			selectedZombiePosition = 3;
			SelectZombie (zombies [3]);
		} else {
			selectedZombiePosition = selectedZombiePosition - 1;
			SelectZombie (zombies [selectedZombiePosition]);
		}
	}

	// if right key pressed
	// select next zombie to the right unless at the end of row
	// if so then select the first zombie
	void GetZombieRight() {
		if (selectedZombiePosition == 3) {
			selectedZombiePosition = 0;
			SelectZombie (zombies [0]);
		} else {
			selectedZombiePosition = selectedZombiePosition + 1;
			SelectZombie (zombies [selectedZombiePosition]);
		}
	}

	// if up key pressed
	// push zombie up the screen
	void PushUp() {
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 10, ForceMode.Impulse);
	}


	public void AddPoint() {
		score += 1;
		scoreText.text = "Score: " + score;

	}
}
