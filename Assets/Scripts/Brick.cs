﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	
	private LevelManager levelManager;
	private int timesHit;
	public bool isBreakable; 

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable){
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.2f);
		if (isBreakable){
			HandleHits();
		}

	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length +1; 

		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit -1;
		// This if condition states, if the system checks the current spriteIndex and there is nothing, the sprite does not change
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites [spriteIndex];
		}

	}

	
}
