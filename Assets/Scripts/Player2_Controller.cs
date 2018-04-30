using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controller : MonoBehaviour {
	Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		transform.localPosition = pos;

		if (Input.GetKey (KeyCode.W)) {
			pos.y += 0.2f;
		}
		if (Input.GetKey (KeyCode.S)) {
			pos.y -= 0.2f;
		}

		if (pos.y <= -5.5f || pos.y >= 5.5f) {
			pos.y = -pos.y;
		}
	}
}