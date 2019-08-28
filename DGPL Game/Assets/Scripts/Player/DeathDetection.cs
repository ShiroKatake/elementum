using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetection : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Death") {
			Respawn();
		}
	}

	void Respawn() {
		if (RespawnManager.currentRespawn.Count > 0) {
			//DieAnimation()
			transform.position = RespawnManager.currentRespawn[0];
		}
	}
}
