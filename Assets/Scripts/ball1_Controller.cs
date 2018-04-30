using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball1_Controller : MonoBehaviour {
	float speed = 10.0f;
	Vector3 pos;
	Rigidbody rb;
	bool outflug = false;
	public score_text1 stext;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.right * speed, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.transform.localPosition;
		if ((pos.y <= -5f || pos.y >= 5f) && !outflug) {
			rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		if(pos.x <= -10f && !outflug){
			rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		if(!(pos.y <= -5f || pos.y >= 5f) && !(pos.x <= -10f || pos.x >= 10f)){
			outflug = false;
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "block"){
			stext.GetComponent<score_text1>().score++;
			Destroy(collision.gameObject);
		}
	}
}
