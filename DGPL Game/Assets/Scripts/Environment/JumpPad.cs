using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class JumpPad : MonoBehaviour {
	public enum Directions { Up, Left, Right };
	public Directions boostDirection;
	public float jumpForce;
	private Rigidbody2D playerRb;
	private bool isTouched;

	private void Start() {
		playerRb = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTouched = true;
		}
	}

	private void Boost() {
		switch (boostDirection) {
			case Directions.Up:
			playerRb.velocity += Vector2.up * jumpForce;
			break;

			case Directions.Left:
			Debug.Log(playerRb.velocity);
			playerRb.velocity += new Vector2(-1, 1) * jumpForce;
			break;
		}
		playerRb.GetComponent<PlayerMovement>().wallJumped = true;
		isTouched = false;
	}

	private void FixedUpdate() {
		if (isTouched) {
			playerRb.velocity = Vector2.zero;
			Boost();
		}
	}
}
