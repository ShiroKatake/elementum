using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	private CharacterController2D controller;
	public float runSpeed;
	private float horizontalMove;
	private bool jump;

	private void Start() {
		controller = GetComponent<CharacterController2D>();
	}

	// Update is called once per frame
	void Update() {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Up")) {
			jump = true;
		}
	}

	void FixedUpdate() {
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
