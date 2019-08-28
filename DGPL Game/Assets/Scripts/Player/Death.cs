using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
	[SerializeField] private Transform player; //player object
	[SerializeField] private Transform respawnPoint; //respawn empty object


	//when the player touches the kill object
	private void OnTriggerEnter2D(Collider2D collision) {
		//changes the players position to the respawn empty object
		player.transform.position = respawnPoint.transform.position;
	}
}
