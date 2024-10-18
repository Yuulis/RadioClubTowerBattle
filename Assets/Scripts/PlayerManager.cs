using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int score = -1;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        
    }

    private void Update()
    {
        UpDateScoreText();
    }

    public void UpDateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
