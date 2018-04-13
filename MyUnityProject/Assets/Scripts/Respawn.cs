﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform player;
    public Transform respawn;

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            GameControlScript.lives -= 1;
			player.position = respawn.position;
            FindObjectOfType<PointsController>().AddScore(-50);
        }


    }
}
