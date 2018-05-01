using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    Text[] score_texts;
    int[] scores = { 0, 0 };

    static ScoreManager instance;

    public static ScoreManager getInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
            if (instance == null)
            {
                throw new Exception("ScoreManagerが見つかりません");
            }
        }
        return instance;
    }

    public void setScore(int id, int score)
    {
        score_texts[id].text = ScoreUtils.FixedScoreString(id, score);
        scores[id] = score;
    }

    public int getScore(int id)
    {
        return getInstance().scores[id];
    }
}

public class ScoreUtils
{
    public static string FixedScoreString(int id, int score)
    {
        return "player" + id.ToString() + ":" + score.ToString() + "点";
    }
}
