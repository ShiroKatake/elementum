using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour {
	public float crumbleTime;
	public float respawnTime;
	private Rigidbody2D rb;
	private Collider2D[] cols;
	private SpriteRenderer sr;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
		cols = GetComponents<Collider2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	private void Start() {
		rb.bodyType = RigidbodyType2D.Static;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine(StartCrumble(crumbleTime, respawnTime));
		}
	}

	IEnumerator StartCrumble(float crumbleTime, float respawnTime) {
		yield return new WaitForSeconds(crumbleTime);
		Crumble();
		yield return new WaitForSeconds(respawnTime);
		Respawn();
	}

	private void Crumble() {
		//Drop
		//rb.bodyType = RigidbodyType2D.Dynamic;

		//Or disappear
		sr.enabled = false;
		foreach (Collider2D col in cols) {
			col.enabled = false;
		}
	}

	private void Respawn() {
		sr.enabled = true;
		foreach (Collider2D col in cols) {
			col.enabled = true;
		}
	}
}