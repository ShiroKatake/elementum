using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class JumpPad : MonoBehaviour {
	public enum Directions { Up, Left, Right };
	public Directions boostDirection;
	public float jumpForce = 22f;
	public float airControlDelay;
	private float airControlDelayLeft;
	public float boostedMovementSmoothing;
	private CharacterController2D playerController;
	private Rigidbody2D playerRb;
	private bool isTouched;
	private float defaultMovementSmoothing;

	private void Start() {
		playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
		defaultMovementSmoothing = playerController.m_MovementSmoothing;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTouched = true;
			playerRb.velocity = Vector2.zero;
		}
	}

	private void FixedUpdate() {
		playerController.m_AirControl = true;
		airControlDelayLeft -= Time.deltaTime;
		if (isTouched) {
			Boost();
		}
		if (airControlDelayLeft >= 0) {
			playerController.m_AirControl = false;
		} else if (airControlDelayLeft <= 0 && !playerController.m_Grounded) {
			playerController.m_MovementSmoothing = boostedMovementSmoothing;
		} else {
			playerController.m_MovementSmoothing = defaultMovementSmoothing;
		}
	}

	private void Boost() {
		switch (boostDirection) {
			case Directions.Up:
				playerRb.velocity = Vector2.up * jumpForce;
				break;

			case Directions.Left:
				airControlDelayLeft = airControlDelay;
				playerRb.velocity = new Vector2(-1, 1) * jumpForce;
				break;

			case Directions.Right:
				airControlDelayLeft = airControlDelay;
				playerRb.velocity = new Vector2(1, 1) * jumpForce;
				break;
		}
		isTouched = false;
	}
}
