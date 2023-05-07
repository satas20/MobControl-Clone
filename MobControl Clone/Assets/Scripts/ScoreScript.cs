using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] private TextMeshProUGUI score;

    void Start()
    {
        scoreValue = PlayerPrefs.GetInt("score");


    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();
    }
}
