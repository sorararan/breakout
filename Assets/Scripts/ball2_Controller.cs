using System.Collections;
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
		//縦の跳ね返り
		if ((pos.y <= -5f || pos.y >= 5f) && !outflug) {
			rb.velocity = new Vector3 (rb.velocity.x, -rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		//横の跳ね返り
		if (pos.x >= 10f && !outflug) {
			rb.velocity = new Vector3 (-rb.velocity.x, rb.velocity.y, rb.velocity.z);
			outflug = true;
		}
		//画面外でのkill
		if(pos.x <= -15){
			Destroy(this.gameObject);
		}
		//outflugは画面外に飛び出て跳ね返りがうまくいかないときの対処
		if (!(pos.y <= -5f || pos.y >= 5f) && !(pos.x <= -10f || pos.x >= 10f)) {
			outflug = false;
		}
	}

	void OnCollisionEnter (Collision collision) {
		//スコアをつけてブロックを消す
		if (collision.gameObject.tag == "block") {
			stext.GetComponent<score_text2> ().score++;
			Destroy (collision.gameObject);
		}
	}

	void OnTriggerEnter (Collider collider) {
		//ミサイルが当たったボールはランダムに動く
		if (collider.gameObject.tag == "missile1") {
			Destroy (collider.gameObject);
			System.Random r = new System.Random();
			float r1 = (float)r.Next(2);
			float r2 = (float)r.Next(2);
			rb.AddForce(new Vector3(r1, r2, 0) * speed, ForceMode.VelocityChange);
		}
	}
}