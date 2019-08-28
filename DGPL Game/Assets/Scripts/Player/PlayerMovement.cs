using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Sprite fireSprite;
	public Sprite waterSprite;
	private Collision col;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public float speed = 5f;
	public float jumpForce = 5f;
	public bool wallJumped;
	public float wallJumpLerp = 10f;
	private bool _facingRight = true;

	void Start() {
		col = GetComponent<Collision>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	void Update() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		if (col.onGround) {
			wallJumped = false;
		}
		if (x != 0 || y != 0) {
			Vector2 dir = new Vector2(x, y);
			Walk(dir);
		}
		if (Input.GetButtonDown("Up")) {
			if (col.onGround) {
				Jump(Vector2.up);
			}
		}

		//Change player's elements
		if (Input.GetButtonDown("Fire")) {
			ChangeToFire();
		}
		if (Input.GetButtonDown("Water")) {
			ChangeToWater();
		}

		//Flip character depending on where they're facing (assuming the sprite faces right first)
		if (x < 0 && _facingRight) {
			Flip();
		} else if (x > 0 && !_facingRight) {
			Flip();
		}
	}

	private void Flip() {
		_facingRight = !_facingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void Walk(Vector2 dir) {
		if (!wallJumped) {
			rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
		} else {
			rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
		}
	}

	private void Jump(Vector2 dir) {
		Debug.Log("jumped");
		rb.velocity = new Vector2(rb.velocity.x, 0);
		rb.velocity += dir * jumpForce;
	}

	private void ChangeToFire() {
		//Enable Fire actions
		//Disable Water actions
		sr.sprite = fireSprite;
	}

	private void ChangeToWater() {
		//Enable Water actions
		//Disable Fire actions
		sr.sprite = waterSprite;
	}
}
