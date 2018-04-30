using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour {
	Vector3 pos;
	int count = 0;

	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		//ミサイルを一定間隔での発射
		count++;

		transform.localPosition = pos;

		if (Input.GetKey (KeyCode.UpArrow)) {
			pos.y += 0.2f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			pos.y -= 0.2f;
		}
		if (Input.GetKey (KeyCode.LeftArrow) && count >= 30) {
			GameObject missile = (GameObject) Resources.Load ("Prefabs/missile1");
			Instantiate (missile, pos, Quaternion.identity);
			count = 0;
		}

		if (pos.y <= -5.5f || pos.y >= 5.5f) {
			pos.y = -pos.y;
		}
	}
}