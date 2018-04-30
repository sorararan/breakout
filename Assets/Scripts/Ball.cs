using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public int id;
    private float speed = 13.0f;
    // trueがどちらなのかすぐにわかる命名が良いです
    bool is_out = false;
    // 基本的に短縮した変数名は使わない方が良いです(パッと見で何なのかわかる名前で)
    Rigidbody rigid_body;
    Vector3[] initial_speed = { new Vector3(0.5f, 0.2f, 0), new Vector3(-0.5f, -0.2f, 0) };

	// Use this for initialization
	void Start () {
        rigid_body = GetComponent<Rigidbody>();
        rigid_body.AddForce(initial_speed[id] * speed, ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	void Update () {
        Bound();
    }

    void Bound()
    {
        Vector3 position = transform.localPosition;
        //縦の跳ね返り
        if ((position.y <= -5f || position.y >= 5f) && !is_out)
        {
            rigid_body.velocity = new Vector3(rigid_body.velocity.x, -rigid_body.velocity.y, rigid_body.velocity.z);
            is_out = true;
        }
        //横の跳ね返り
        if (position.x <= -10f && !is_out)
        {
            rigid_body.velocity = new Vector3(-rigid_body.velocity.x, rigid_body.velocity.y, rigid_body.velocity.z);
            is_out = true;
        }
        //画面外でのkill
        if (position.x >= 15)
        {
            Destroy(this.gameObject);
        }
        //outflugは画面外に飛び出て跳ね返りがうまくいかないときの対処
        if (!(position.y <= -5f || position.y >= 5f) && !(position.x <= -10f || position.x >= 10f))
        {
            is_out = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //スコアをつけてブロックを消す
        if (collision.gameObject.tag == "block")
        {
            ScoreManager.getInstance().setScore(id, ScoreManager.getInstance().getScore(id) + 1);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //ミサイルが当たったボールはランダムに動く
        if (collider.gameObject.tag == "missile")
        {
            Debug.Log(collider.gameObject.GetComponent<Missile>().id.ToString() + " " + id.ToString());
            if (collider.gameObject.GetComponent<Missile>().id != id) { 
                Destroy(collider.gameObject);
                System.Random r = new System.Random();
                float r1 = (float)r.Next(2);
                float r2 = (float)r.Next(2);
                rigid_body.AddForce(new Vector3(r1, r2, 0) * speed, ForceMode.VelocityChange);
            }
        }
    }
}
