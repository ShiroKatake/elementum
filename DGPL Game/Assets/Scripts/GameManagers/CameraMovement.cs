using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float transitionSpeed;
	public bool isChanging;
	private BoxCollider2D col;
	private Transform mainCam;

	void Awake() {
		isChanging = false;
		col = GetComponent<BoxCollider2D>();
		mainCam = Camera.main.transform;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isChanging = true;
		}
	}

	private void Update() {
		if (isChanging) {
			mainCam.position = Vector2.MoveTowards(mainCam.position, transform.position, transitionSpeed * Time.deltaTime);
		}
		if (new Vector3(mainCam.position.x, mainCam.position.y, 0) == transform.position) {
			isChanging = false;
		}
		mainCam.position = new Vector3(mainCam.position.x, mainCam.position.y, -10);
	}
}
