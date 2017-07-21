﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public GameManager gamemanager;
	public AudioClip hit;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	// calll add point method  when zombie collides with buffer
	void OnTriggerEnter(Collider other) {
		gamemanager.AddPoint();
		// play sound effect 
		source.PlayOneShot (hit);
	}
}
