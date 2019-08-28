using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	bool left;
	bool right;
	public GameObject firePrefab;
	public GameObject player;

    // Update is called once per frame
    void Update() {
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		float x = Input.GetAxisRaw("Horizontal");
		if (x <= -1) {
			left = false;
			right = true;
		} else if (x >= 1) {
			left = true;
			right = false;
		}
		if (Input.GetButtonDown("Fire")) {


			if (left == true) {
				GameObject fireA = Instantiate(firePrefab) as GameObject;
				fireA.transform.position = new Vector2(playerX + 1, playerY);
			} else if (right == true) {
				GameObject fireA = Instantiate(firePrefab) as GameObject;
				fireA.transform.position = new Vector2(playerX - 1, playerY);
			}
		}
	}
}