using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script created by Board To Bits Games https://www.youtube.com/watch?v=7KiK0Aqtmzc
public class BetterJump : MonoBehaviour {
	private Rigidbody2D rb;
	public float gravityMultiplier = 2f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		if (rb.velocity.y > 0 && !Input.GetButton("Up")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
}
