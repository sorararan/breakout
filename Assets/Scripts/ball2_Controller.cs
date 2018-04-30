﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball2_Controller : MonoBehaviour {
	float speed = 10.0f;
	Vector3 pos;
	Rigidbody rb;
	bool outflug = false;
	public score_text2 stext;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (-0.5f, -0.2f, 0) * speed, ForceMode.VelocityChange);
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.localPosition;
		if ((pos.y <= -5f || pos.y >= 5f) && !outflug) {
			rb.velocity = new Vector3 (rb.velocity.x, -rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		if (pos.x >= 10f && !outflug) {
			rb.velocity = new Vector3 (-rb.velocity.x, rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		if (!(pos.y <= -5f || pos.y >= 5f) && !(pos.x <= -10f || pos.x >= 10f)) {
			outflug = false;
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "block") {
			stext.GetComponent<score_text2> ().score++;
			Destroy (collision.gameObject);
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "missile1") {
			Destroy (collider.gameObject);
			System.Random r = new System.Random(1000);
			float r1 = (float)r.Next(2);
			float r2 = (float)r.Next(2);
			rb.AddForce(new Vector3(r1, r2, 0) * speed, ForceMode.VelocityChange);
		}
	}
}