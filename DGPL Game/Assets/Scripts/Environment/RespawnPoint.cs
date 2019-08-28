using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {

	//If the player walks through a respawn point, replaces the existing respawn point with this one
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (RespawnManager.currentRespawn.Count > 0) {
				RespawnManager.currentRespawn.Clear();
			}
			RespawnManager.currentRespawn.Add(transform.position);
		}
	}
}
