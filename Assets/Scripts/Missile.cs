using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    public int id;
    float speed = 10.0f;
    int[] directions = { 1, -1 };

    // Use this for initialization
    void Start()
    {
        Quaternion q = Quaternion.Euler(directions[id] * new Vector3(0, 0, 90));
        transform.rotation = q * transform.rotation;
        GetComponent<Rigidbody>().AddForce(directions[id] *new Vector3(-1, 0, 0) * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        //画面外でのkill
        if (transform.localPosition.x <= -12 || transform.localPosition.x >= 12)
        {
            Destroy(this.gameObject);
        }
    }
}
