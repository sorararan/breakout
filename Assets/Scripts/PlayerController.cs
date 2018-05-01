using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int id;
    int[] up_keys = { (int)KeyCode.UpArrow, (int)KeyCode.W };
    int[] down_keys = { (int)KeyCode.DownArrow, (int)KeyCode.S };
    int[] attack_keys = { (int)KeyCode.LeftArrow, (int)KeyCode.D };

    Vector3 position;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //ミサイルを一定間隔での発射
        count++;

        transform.localPosition = position;

        move();

        if (Input.GetKey((KeyCode)attack_keys[id]) && count >= 30)
        {
            MissileManager.getInstance().CreateMissile(id, position);
            count = 0;
        }

        if (position.y <= -5.5f || position.y >= 5.5f)
        {
            position.y = -position.y;
        }
    }

    void move()
    {
        if (Input.GetKey((KeyCode)up_keys[id]))
        {
            position.y += 0.2f;
        }
        if (Input.GetKey((KeyCode)down_keys[id]))
        {
            position.y -= 0.2f;
        }
    }
}
