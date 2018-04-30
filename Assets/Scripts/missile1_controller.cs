using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile1_controller : MonoBehaviour {
	float speed = 10.0f;

	// Use this for initialization
	void Start () {
		Quaternion q = Quaternion.Euler(0, 0, 90);
		this.transform.rotation = q * this.transform.rotation;
		this.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * speed, ForceMode.VelocityChange);
	}

	// Update is called once per frame
	void Update () {
		if(this.transform.localPosition.x <= -12){
			Destroy(this.gameObject);
		}
	}
}