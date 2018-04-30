using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controller : MonoBehaviour {
	Vector3 pos;
	int count = 0;

	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		count++;

		transform.localPosition = pos;

		if (Input.GetKey (KeyCode.W)) {
			pos.y += 0.2f;
		}
		if (Input.GetKey (KeyCode.S)) {
			pos.y -= 0.2f;
		}
		if (Input.GetKey (KeyCode.D) && count >= 30) {
			GameObject missile = (GameObject) Resources.Load ("Prefabs/missile2");
			Instantiate (missile, pos, Quaternion.identity);
			count = 0;
		}

		if (pos.y <= -5.5f || pos.y >= 5.5f) {
			pos.y = -pos.y;
		}
	}
}