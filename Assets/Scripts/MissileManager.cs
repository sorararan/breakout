using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MissileManager : MonoBehaviour {

    GameObject[] missile_prehabs;

    static MissileManager instance;

    public static MissileManager getInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType(typeof(MissileManager)) as MissileManager;
            if (instance == null)
            {
                throw new Exception("MissileManagerが見つかりません");
            }
        }
        return instance;
    }

    // Use this for initialization
    void Start () {
        missile_prehabs = new GameObject[2];
		missile_prehabs[0] = (GameObject)Resources.Load("Prefabs/missile0");
        missile_prehabs[1] = (GameObject)Resources.Load("Prefabs/missile1");
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void CreateMissile(int id, Vector3 position)
    {
        Instantiate(missile_prehabs[id], position, Quaternion.identity);
    }

}
