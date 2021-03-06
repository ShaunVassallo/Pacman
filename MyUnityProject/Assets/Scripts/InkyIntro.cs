﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkyIntro : MonoBehaviour {
	public Transform[] introWaypoints;
	public Transform[] startWaypoints;

	Vector2 dest = Vector2.zero;
	int cur = 0;
	int phase = 0;

	public float speed = 0.2f;

	void Start()
	{
		Invoke ("ToPhaseOne", 6f);
	}

	void FixedUpdate () {
		if (phase == 0)
		{
			if (transform.position.Equals (introWaypoints [cur].position))
			{
				// if condition on one line - switch between 1 and 0.
				cur = (cur == 0) ? 1 : 0;
			}
			transform.position = Vector2.MoveTowards (transform.position, introWaypoints [cur].position, speed);
		}

		if (phase == 1)
		{
			if (transform.position.Equals (startWaypoints [cur].position)) {
				cur++;
				if (cur == 2) {
					this.enabled = false;
					GetComponent<GhostMovement> ().enabled = true;
				}
			} else {
				transform.position = Vector2.MoveTowards (transform.position, startWaypoints [cur].position, speed);
			}

			// Animation Parameters
			Vector2 dir = dest - (Vector2)transform.position;
			GetComponent<Animator>().SetFloat("DirX", dir.x);
			GetComponent<Animator>().SetFloat("DirY", dir.y);
		}
	}

	void ToPhaseOne()
	{
		phase = 1;
		cur = 0;
	}
}
