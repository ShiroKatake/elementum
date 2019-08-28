using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Respawn Manager: used to contain respawn point for player to respawn from

public class RespawnManager : MonoBehaviour {
	static RespawnManager instance;	
	public static List<Vector3> currentRespawn = new List<Vector3>();
	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start() {
		//Clear list of respawn points at the start of every scene
		//and set it to the player's current position
		currentRespawn.Clear();
		Vector3 playerPos = FindObjectOfType<PlayerMovement>().gameObject.transform.position;
		currentRespawn.Add(playerPos);
	}
}